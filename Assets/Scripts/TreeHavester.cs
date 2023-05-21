using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHavester : MonoBehaviour
{

    GameManager GameManager;
    Inventory Inventory;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
        Inventory = GameManager.Inventory;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & Inventory.selectedItem != null && Inventory.selectedItem.data.ContainsData("isTool")) // Check for left mouse button click
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            Debug.Log("Mouse Clicked tool");
            

            if (hit.collider != null && Inventory.selectedItem.data.GetData<int>("usesLeft") >= 0)
            {
                Debug.Log($"{hit.transform.gameObject.tag}");
                if (Inventory.selectedItem != null & hit.transform.gameObject.CompareTag("Tree")) // Check if the clicked object is the TreePlanter
                {
                    Debug.Log("Is Tree");
                    Vector2 playerPosition = transform.position;
                    Vector2 clickPosition = hit.point;

                    float distance = Vector2.Distance(playerPosition, clickPosition);

                    if (distance <= Inventory.selectedItem.data.GetData<float>("breakRange"))
                    {
                        Debug.Log("Is in break range");
                        Tree targetTree = hit.transform.gameObject.GetComponent<Tree>();
                        targetTree.HarvestTree();

                    }
                }
            }
            else if (Inventory.selectedItem.data.GetData<int>("usesLeft") <= 0)
            {
                Inventory.selectedItem.data.AddData("usesLeft", 20);
                Inventory.selectedItem.amount--;
                if (Inventory.selectedItem.amount >= 0)
                {
                    Inventory.RemoveItem(Inventory.selectedItem);
                }

            }
        }
    }
}
