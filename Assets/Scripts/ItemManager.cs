using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<Tuple<Item, Item>> treeTypes = new List<Tuple<Item, Item>>();

    private void Awake()
    {
        WarmItems();
    }

    public void WarmItems()
    {
        items.Clear();
        treeTypes.Clear();

        int itemId = 1;

        Item itemToAdd = CreateItem(itemId, "Sprites/Items/Axe1", "Simple Axe", "A Simple axe, its not that good.", new ItemData(this));
        itemToAdd.data.AddData("usesLeft", 20);
        itemToAdd.data.AddData("isTool", true);
        itemToAdd.data.AddData("breakRange", 5f);

        items.Add(itemToAdd);

        itemId++;

        Item fireExting = CreateItem(itemId, "Sprites/Items/FireExtinguisher", "Extinguisher", "Its a fire extinguisher.", new ItemData(this));
        fireExting.data.AddData("usesLeft", 120);
        fireExting.data.AddData("isBuyable", true);
        fireExting.data.AddData("price", 20);

        items.Add(fireExting);

        itemId++;


        foreach (TreeType treeType in Enum.GetValues(typeof(TreeType)))
        {
            string treeTypeName = treeType.ToString();
            string seedName = treeTypeName + " Seed";
            string description = "A simple " + treeTypeName.ToLower() + " seed, you might find some in your local forest!";

            Debug.Log($"Sprites/Trees/{treeTypeName}");
            Item seedToAdd = new Item(new ItemData(this), Resources.Load<Sprite>($"Sprites/Trees/{treeTypeName}"), itemId, seedName, description);
            seedToAdd.data.AddData("type", treeType);
            seedToAdd.data.AddData("isBuyable", true);
            seedToAdd.data.AddData("price", itemId * 3); // what am I even doing?
            seedToAdd.data.AddData("isSeed", true);

            items.Add(seedToAdd);

            itemId++;

            string logName = treeTypeName + " Log";
            string logdescription = $"A simple " + treeTypeName.ToLower() + " piece of wood!";

            Item logToAdd = new Item(new ItemData(this), Resources.Load<Sprite>($"Sprites/Items/{treeTypeName}Log"), itemId, logName, logdescription);
            logToAdd.data.AddData("type", treeType);
            logToAdd.data.AddData("isLog", true);
            logToAdd.data.AddData("sellPrice", itemId * 4);

            items.Add(logToAdd);
            treeTypes.Add(new Tuple<Item, Item>(seedToAdd, logToAdd));

            itemId++;
        }

        /*
        Item callFireFighters = CreateItem(itemId, "Sprites/Items/Phone", "Phone.", "Call in a plane that extinguishes fire.", new ItemData(this));
        callFireFighters.data.AddData("isBuyable", true);
        callFireFighters.data.AddData("price", 75);

        items.Add(callFireFighters);
        
        itemId++;
        */
    }

    private Item CreateItem(int itemId, string resourcePath, string name, string desc, ItemData itemData)
    {
        Item itemToAdd = new Item(itemData, Resources.Load<Sprite>(resourcePath), itemId, name, desc);
        return itemToAdd;
    }

    public Tuple<Item,Item> GetWoodTypeTuple(TreeType type)
    {
        List<Tuple<Item, Item>> matchingtreeTypes = treeTypes.FindAll(x => x.Item1.data.ContainsData("type") & x.Item1.data.GetData<TreeType>("type") == type);
        foreach(Tuple<Item,Item> match in matchingtreeTypes)
        {
            Debug.Log($"{match.Item1.name} | {match.Item2.name}");
        }
        foreach (Tuple<Item,Item> tuple in treeTypes.FindAll(x => x.Item1.data.ContainsData("type") & x.Item1.data.GetData<TreeType>("type") == type))
        {
            return tuple;
        }
        throw new Exception("WoodTypeNotFound");
    }

    public List<Item> ItemsWithData<T>(string key)
    {
        List<Item> dataItems = new List<Item>();
        foreach(Item item in items)
        {
            if(item.data.ContainsData(key) && item.data.GetData<T>(key) != null)
            {
                dataItems.Add(item);
            }
        }
        if(dataItems.Count != 0)
        {
            return dataItems;
        }
        return null;
    }


    public Item GetItemByID(int id = 0)
    {
        return items.Find(x => x.id == id);
    }

    public Item GetItemByName(string name = "empty")
    {
        return items.Find(x => x.name == name);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
