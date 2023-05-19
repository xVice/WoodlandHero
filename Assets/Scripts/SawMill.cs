using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TickSubscriber))]
public class SawMill : MonoBehaviour, ITickable
{
    public int tickToProcess = 15;
    
    Item itemsInTopSlot;
    Item itemsInBottomSlot;

    GameManager gameManager;
    int currentTick;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.Inventory.selectedItem.data.ContainsData("type"))
        {
            Tuple<Item, Item> treeType = gameManager.ItemManager.GetWoodTypeTuple(gameManager.Inventory.selectedItem.data.GetData<TreeType>("type"));
            Item rawWood = gameManager.Inventory.GetItem(treeType.Item1.id);
        }
    }

    public void Tick()
    {

    }

}
