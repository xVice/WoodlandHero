using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryHolder;
    public GameObject InventoryHolderUIItems;
    public GameObject UiItemPrefab;

    public Item selectedItem;

    public List<Item> items = new List<Item>();

    GameManager gameManager;
    ItemManager itemManager;

    bool invIsOpen = false;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        itemManager = gameManager.ItemManager;
        itemManager.WarmItems();
        Item selectedItem = AddItemsWithID(1, 1, 64);
        this.selectedItem = selectedItem;
        AddItemsWithID(2, 2);
        AddItemsWithID(3, 5);
    }

    private void Update()
    {
        // Check for Tab key press to close the inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            invIsOpen = !invIsOpen;
            DisplayInventory();
        }


    }

    private void Start()
    {
        DisplayInventory();
    }

    private void DisplayInventory()
    {
        // Hide the inventory UI or perform any necessary actions to close the inventory
        InventoryHolder.SetActive(invIsOpen);
        if (invIsOpen)
        {
            RenderItemsInInventory();
        }
    }

    public void SetSelectedItem(Item item)
    {
        selectedItem = item;
        // TODO: Display selected item in the bottom-left corner -> RenderItemInInventory for ref
    }

    public void RenderItemsInInventory()
    {
        if (InventoryHolder.activeInHierarchy)
        {
            UIItem[] uiitems = InventoryHolderUIItems.GetComponentsInChildren<UIItem>();

            foreach (UIItem item in uiitems)
            {
                Destroy(item.gameObject);
            }

            foreach (Item item in items)
            {
                UIItem uiitem = Instantiate(UiItemPrefab, InventoryHolderUIItems.transform).GetComponent<UIItem>();
                uiitem.SetItem(item);
            }
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        selectedItem = items[0];
        RenderItemsInInventory();
    }

    public Item AddItemsWithID(int id = 0, int amount = 1, int usesLeft = 64)
    {
        Item referenceItem = itemManager.GetItemByID(id);

        if (items.Find(x => x.id == referenceItem.id) == null)
        {
            Item itemToAdd = new Item(new ItemData(this), referenceItem.previewImage, referenceItem.id, referenceItem.name, referenceItem.description, amount, usesLeft);
            referenceItem.data.SetContext(this);
            itemToAdd.data = referenceItem.data;
            items.Add(itemToAdd);
            RenderItemsInInventory();
            return itemToAdd;
        }
        else
        {
            Item inInvItem = items.Find(x => x.id == referenceItem.id);
            inInvItem.amount += amount;
            inInvItem.usesLeft = usesLeft;
            RenderItemsInInventory();
            return inInvItem;
        }
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
