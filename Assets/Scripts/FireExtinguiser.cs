using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguiser : MonoBehaviour
{

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
        if (gameManager.Inventory.selectedItem != null)
        {
            Item selectedItem = gameManager.Inventory.selectedItem;
            if (selectedItem.name == "Fire extinguisher")
            {
                int usesLeft = selectedItem.data.GetData<int>("usesLeft");
                if (usesLeft > 0)
                {
                    usesLeft--;

                    // Cast a ray from player to mouse position
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 playerPosition = gameManager.Player.transform.position;
                    Vector2 direction = mousePosition - playerPosition;

                    RaycastHit2D[] hits = Physics2D.RaycastAll(playerPosition, direction);

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
            }
        }
    }

}
