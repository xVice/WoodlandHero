using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguiser : MonoBehaviour
{
    public GameObject fireExtinguisherParticlesHolder;
    public ParticleSystem fireExitinguisherParticles;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && gameManager.Inventory.selectedItem != null)
        {
            Item selectedItem = gameManager.Inventory.selectedItem;
            if (selectedItem.name == "Extinguisher")
            {
                int usesLeft = selectedItem.data.GetData<int>("usesLeft");
                if (usesLeft > 0)
                {
                    usesLeft--;
                    selectedItem.data.AddData("usesLeft", usesLeft);
                    Debug.Log(usesLeft);

                    if (!fireExitinguisherParticles.isPlaying)
                    {
                        fireExitinguisherParticles.Play();
                    }

                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 direction = mousePosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    fireExtinguisherParticlesHolder.transform.rotation = rotation;

                    RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);

                    foreach (RaycastHit2D hit in hits)
                    {
                        Tree tree = hit.transform.GetComponent<Tree>();
                        if (tree != null)
                        {
                            // Do something with the tree component
                            // e.g., tree.DoSomething();
                            tree.Extinguish();
                        }
                    }
                }
                else
                {
                    selectedItem.amount--;
                    if (selectedItem.amount <= 0)
                    {
                        gameManager.Inventory.RemoveItem(selectedItem);
                    }
                    else
                    {
                        selectedItem.data.AddData("usesLeft", 120);
                    }
                    gameManager.Inventory.RenderItemsInInventory();
                    fireExitinguisherParticles.Stop();
                }
            }
        }
        else
        {
            fireExitinguisherParticles.Stop();
        }

    }

}
