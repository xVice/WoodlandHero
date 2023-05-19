using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<Tuple<Item, Item>> treeTypes = new List<Tuple<Item, Item>>();

    private void Awake()
    {
        WarmItems();
    }

    void WarmItems()
    {
        int itemId = 1;
        Item rawWood;
        Item LogWood;

        foreach (TreeType treeType in Enum.GetValues(typeof(TreeType)))
        {
            string treeTypeName = treeType.ToString();
            string seedName = treeTypeName + " Seed";
            string description = "A simple " + treeTypeName.ToLower() + " seed, you might find some in your local forest!";

            Item seedToAdd = new Item(new ItemData(this),Resources.Load<Sprite>("Sprites/DefaultItem"), itemId, seedName, description);
            seedToAdd.data.AddData("type", treeType);
            seedToAdd.data.AddData("isSeed", true);

            items.Add(seedToAdd);

            itemId++;

            string logName = treeTypeName + " Log";
            string logdescription = $"A simple " + treeTypeName.ToLower() + " piece of wood!";

            Item logToAdd = new Item(new ItemData(this), Resources.Load<Sprite>("Sprites/DefaultItem"), itemId, logName, logdescription);
            logToAdd.data.AddData("type", treeType);
            logToAdd.data.AddData("isLog", true);
            logToAdd.data.AddData("sellPrice", itemId * 5);

            items.Add(logToAdd);

            itemId++;

            treeTypes.Add(new Tuple<Item, Item>(seedToAdd, logToAdd));
        }

        foreach (TreeType treeType in Enum.GetValues(typeof(TreeType)))
        {

        }

        Item itemToAdd = new Item(new ItemData(this), Resources.Load<Sprite>("Sprites/DefaultItem"), itemId, "TestTool", "The Debug tool though");
        itemToAdd.data.AddData("isTool", true);
        itemToAdd.data.AddData("breakRange", 5f);

        items.Add(itemToAdd);
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
