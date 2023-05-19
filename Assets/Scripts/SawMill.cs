using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TickSubscriber))]
public class SawMill : MonoBehaviour, ITickable
{
    public int tickToProcess = 15;
    public GameObject SawmillUIPrefab;

    public GameObject TopHolder;
    public GameObject BottomHolder;

    public UIPreviewSawmill topPreview;
    public UIPreviewSawmill bottomPreview;

    Item itemsInTopSlot;
    Item itemsInBottomSlot;

    GameManager gameManager;
    int currentTick;
    bool isProcessing;

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
            itemsInTopSlot = gameManager.Inventory.GetItem(treeType.Item1.id);
            itemsInBottomSlot = gameManager.ItemManager.GetItemByID(treeType.Item2.id);

            SetTopItem(itemsInTopSlot);

        }
    }

    public void SetTopItem(Item item)
    {
        topPreview.SetItem(item);
        topPreview.ReDraw();
    }

    private void SetBottomPreview(Item item)
    {
        bottomPreview.SetItem(item);
        bottomPreview.ReDraw();
    }



    public void Tick()
    {
        if(itemsInBottomSlot.data.GetData<TreeType>("type") == itemsInTopSlot.data.GetData<TreeType>("type") | itemsInBottomSlot == null)
        {
            if (itemsInTopSlot.amount < 0)
            {
                currentTick++;
                
                if(currentTick <= tickToProcess)
                {
                    itemsInTopSlot.amount--;
                    itemsInBottomSlot.amount++;
                    topPreview.ReDraw();
                    bottomPreview.ReDraw();
                }
            }
        }
    }

}
