using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryHolder;
    public GameObject UiItemPrefab;

    public Item selectedItem;

    public List<Item> items = new List<Item>();

    GameManager gameManager;
    ItemManager itemManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        itemManager = gameManager.ItemManager;
    }

    public void SetSelectedItem(Item item)
    {
        selectedItem = item;
        //TODO display selected item in bottomleft cornor -> RenderItemInInventory for ref
    }

    private void Start()
    {
        AddItemsWithID(0, 5, 64);
    }

    public void RenderItemsInInventory()
    {
        UIItem[] uiitems = InventoryHolder.GetComponentsInChildren<UIItem>();

        foreach (UIItem item in uiitems)
        {
            Destroy(item.gameObject);
        }

        foreach (Item item in items)
        {
            UIItem uiitem = Instantiate(UiItemPrefab, InventoryHolder.transform).GetComponent<UIItem>();
            uiitem.SetItem(item);
        }
    }



    public void AddItemsWithID(int id = 0, int amount = 1, int usesLeft = 64)
    {
        Item referenceItem = itemManager.GetItemByID(id);

        if (items.Find(x => x.id == referenceItem.id) == null)
        {
            Item itemToAdd = new Item(new ItemData(this),referenceItem.previewImage, referenceItem.id, referenceItem.name, referenceItem.description, amount, usesLeft);
            referenceItem.data.SetContext(this);
            itemToAdd.data = referenceItem.data;
            items.Add(itemToAdd);
            
        }
        else
        {
            Item inInvItem = items.Find(x => x.id == referenceItem.id);
            inInvItem.amount += amount;
            inInvItem.usesLeft = usesLeft;
        }
        RenderItemsInInventory();
    }

    public bool HasItem(int id)
    {
        Item inInvItem = items.Find(x => x.id == id);
        return inInvItem != null;
    }

    public Item GetItem(int id)
    {
        Item inInvItem = items.Find(x => x.id == id);
        return inInvItem ?? new Item(new ItemData(this));
    }
}
