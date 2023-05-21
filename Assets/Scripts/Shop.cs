using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject ShopUIItemPrefab;
    public GameObject ShopHolder;
    public GameObject ShopHolderUIItems;
    public GameObject player;

    List<Tuple<int,Item>> buyableItems = new List<Tuple<int,Item>>();

    GameManager gameManager;


    bool shopIsOpen;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 3);
        Gizmos.DrawWireSphere(transform.position, 13f);
    }

    // Start is called before the first frame update
    void Start()
    {
        List<Item> buyables = gameManager.ItemManager.ItemsWithData<bool>("isBuyable");
        foreach(Item buyable in buyables)
        {
            Tuple<int, Item> buyableTuple = new Tuple<int, Item>(buyable.data.GetData<int>("price"), buyable);
            buyableItems.Add(buyableTuple);
            BuyPanelUI uiPanel = Instantiate(ShopUIItemPrefab, ShopHolderUIItems.transform).GetComponent<BuyPanelUI>();
            uiPanel.SetupUI(buyableTuple);
        }
        ShopHolder.SetActive(false);
        
    }

    public bool BuyItems(int id, int ammount)
    {
        Tuple<int,Item> itemToBuy = buyableItems.Find(x => x.Item2.id == id);
        if (gameManager.MoneyManager.HasEnoughCoins(itemToBuy.Item1 * ammount))
        {
            gameManager.MoneyManager.RemoveCoins(itemToBuy.Item1 * ammount);
            gameManager.Inventory.AddItemsWithID(itemToBuy.Item2.id, ammount);
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // Check if the distance is within the specified range
        if (distance <= 3f)
        {
            if (Input.GetKey(KeyCode.F))
            {
                ShopHolder.SetActive(true);
            }
        }
        else if (ShopHolder != null && ShopHolder.activeInHierarchy && distance <= 13f)
        {
            ShopHolder.SetActive(false);
        }
    }
}
