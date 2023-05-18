using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ItemManager ItemManager;
    public Inventory Inventory;
    // Start is called before the first frame update
    void Awake()
    {
        ItemManager = FindObjectOfType<ItemManager>();
        Inventory = FindObjectOfType<Inventory>();
    }

}
