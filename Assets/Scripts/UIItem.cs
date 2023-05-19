using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;

    public Image displayImage;
    public TextMeshProUGUI ItemNameLabel;
    public TextMeshProUGUI ItemAmountLabel;

    GameManager GameManager;
    Inventory Inventory;

    public void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
        Inventory = GameManager.Inventory;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        ItemNameLabel.text = item.name;
        ItemAmountLabel.text = item.amount.ToString();
        displayImage.sprite = item.previewImage;
    }

    public void OnItemClick()
    {
        Inventory.SetSelectedItem(item);
        Debug.Log("Selected item: " + item.name);
    }
}
