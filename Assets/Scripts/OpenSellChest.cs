using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSellChest : MonoBehaviour
{
    public GameObject player;
    public float range = 5f;

    bool isInSellMode;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, range + 10f);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // Check if the distance is within the specified range
        if (distance <= range)
        {
            if (Input.GetKey(KeyCode.F))
            {
                isInSellMode = true;
                gameManager.SetSellModeAlert(true);
            }
        }
        else if (isInSellMode && distance <= range + 10f)
        {
            gameManager.SetSellModeAlert(false);
            isInSellMode = false;
        }

        if (isInSellMode)
        {
            Item selectedItem = gameManager.Inventory.selectedItem;
            if (selectedItem != null && selectedItem.data.ContainsData("sellPrice"))
            {
                gameManager.MoneyManager.AddCoins(selectedItem.data.GetData<int>("sellPrice") * selectedItem.amount);
                gameManager.Inventory.RemoveItem(selectedItem);
            }
        }
    }
}
