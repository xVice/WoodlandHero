using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject planePrefab;
    public float spawnOffset = 10f;


    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameManager.Inventory.selectedItem != null)
        {
            Item selectedItem = gameManager.Inventory.selectedItem;
            if (selectedItem.name == "Call Aerial firefighters.")
            {
                
                if(selectedItem.amount <= 0)
                {
                    gameManager.Inventory.RemoveItem(selectedItem);
                    gameManager.Inventory.RenderItemsInInventory();
                }
                selectedItem.amount--;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                GameObject plane = Instantiate(planePrefab, transform.position + direction.normalized * spawnOffset, rotation);
                
                Destroy(plane, 10f);
            }

        }

    }
}
