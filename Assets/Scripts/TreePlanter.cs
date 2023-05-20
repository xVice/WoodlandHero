using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePlanter : MonoBehaviour
{
    public GameObject TreePrefab;
    public float placeRange = 5f;

    GameManager GameManager;
    Inventory Inventory;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
        Inventory = GameManager.Inventory;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, placeRange);
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Inventory.selectedItem != null && Inventory.selectedItem.data.ContainsData("isSeed") && Inventory.selectedItem.amount > 0) // Check for left mouse button click
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            Debug.Log("Mouse Clicked");

            if (hit.collider != null)
            {
                Debug.Log($"{hit.transform.gameObject.tag}");
                if (hit.transform.gameObject.CompareTag("Plantable")) // Check if the clicked object is the TreePlanter
                {
                    Debug.Log("Is plantable");
                    Vector2 playerPosition = transform.position;
                    Vector2 clickPosition = hit.point;

                    float distance = Vector2.Distance(playerPosition, clickPosition);

                    if (distance <= placeRange)
                    {
                        Debug.Log("Is in place range");
                        Tree tree = Instantiate(TreePrefab, clickPosition, Quaternion.identity).GetComponent<Tree>();
                        tree.SetupTree(GameManager.Inventory.selectedItem.data.GetData<TreeType>("type"), Inventory.selectedItem);
                        Inventory.selectedItem.amount--;
                        if (Inventory.selectedItem.amount >= 0)
                        {
                            Inventory.RemoveItem(Inventory.selectedItem);
                        }
                    }
                }
            }
        }
    }

}
