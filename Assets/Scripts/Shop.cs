using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    List<Item> buyableItems = new List<Item>();

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        buyableItems = gameManager.ItemManager.ItemsWithData<bool>("isBuyable");
        foreach(Item buyable in buyableItems)
        {
            Debug.Log($"Name: {buyable.name} | Price: {buyable.data.GetData<int>("price")}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
