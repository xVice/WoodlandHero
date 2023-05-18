using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    private void Awake()
    {
        WarmItems();
    }

    void WarmItems()
    {
        items.Add(new Item(Resources.Load<Sprite>("Sprites/DefaultItem"), 0, "TestItem", "Lorem Ipsum Dolor Sit Amet Constitutor käse"));
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
