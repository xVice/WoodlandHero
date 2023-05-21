using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TickSubscriber))]
public class Tree : MonoBehaviour, ITickable
{
    public TreeType type = TreeType.Oak;
    public int tickToGrow = 2000;
    public int currentTick = 0;
    public int moneyReward = 25;

    public float growthRate = 0.01f; // The rate at which the tree grows per tick

    private Vector3 initialScale;
    private Vector3 targetScale;
    private bool isGrowing = false;
    private bool isGrown = false;

    GameManager gameManager;
    Item item;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        initialScale = transform.localScale;
        targetScale = initialScale * 10f; // Increase the scale to twice the initial size
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x + 5f);
    }

    public void SetupTree(TreeType type, Item item)
    {
        this.type = type;
        this.item = item;
        // Retrieve tree properties based on the tree type
        TreeProperties properties = gameManager.TreeProperties[type];
        moneyReward = properties.moneyReward;
        tickToGrow = properties.tickToGrow;
        gameObject.GetComponent<SpriteRenderer>().sprite = item.previewImage;
        Debug.Log($"Tree is now a {type}, and rewards {moneyReward} coins, grow time is {tickToGrow} ticks");

        // Start growing the tree
        StartGrowing();
    }

    public void HarvestTree()
    {
        if (isGrown)
        {
            isGrown = false;
            gameManager.Inventory.AddItemsWithID(gameManager.ItemManager.GetWoodTypeTuple(type).Item2.id, 3);
            gameManager.MoneyManager.AddCoins(moneyReward);
            Destroy(gameObject);
        }
    }

    public void Tick()
    {
        if (isGrowing)
        {
            if (currentTick < tickToGrow)
            {
                currentTick++;
                // Update the scale of the tree
                float t = (float)currentTick / tickToGrow;
                transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            }
            else
            {
                Debug.Log("Tree fully grown");
                isGrowing = false;
                isGrown = true;
            }
        }
    }

    private void StartGrowing()
    {
        isGrowing = true;
        currentTick = 0;
    }
}


public class TreeProperties
{
    public int moneyReward;
    public int tickToGrow;

    public TreeProperties(int moneyReward, int tickToGrow)
    {
        this.moneyReward = moneyReward;
        this.tickToGrow = tickToGrow;
    }
}


