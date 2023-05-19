using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        WarmItems();
    }

    void WarmItems()
    {
        int itemId = 0;

        foreach (TreeType treeType in Enum.GetValues(typeof(TreeType)))
        {
            string treeTypeName = treeType.ToString();
            string seedName = treeTypeName + " Seed";
            string description = "A simple " + treeTypeName.ToLower() + " seed, you might find some in your local forest!";

            Item seedToAdd = new Item(Resources.Load<Sprite>("Sprites/DefaultItem"), itemId, seedName, description);
            seedToAdd.data.AddData("type", treeType);

            items.Add(seedToAdd);

            itemId++;
        }
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
