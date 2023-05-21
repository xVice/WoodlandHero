using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanelUI : MonoBehaviour
{
    public TextMeshProUGUI ShopItemName;
    public TextMeshProUGUI ShopItemNameShadow;
    public TextMeshProUGUI ShopItemDesc;
    public TextMeshProUGUI ShopItemDescShadow;
    public TextMeshProUGUI PriceLabel;
    public TextMeshProUGUI PriceLabelShadow;
    public Image PreviewImage;

    public TMP_InputField amountField;

    public Button BuyButton;


    Tuple<int, Item> buyable;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SetupUI(Tuple<int, Item> buyable)
    {
        BuyButton.onClick.RemoveAllListeners();
        this.buyable = buyable;
        ShopItemName.text = buyable.Item2.name;
        ShopItemNameShadow.text = buyable.Item2.name;
        ShopItemDesc.text = buyable.Item2.description;
        ShopItemDescShadow.text = buyable.Item2.description;
        PriceLabel.text = $"Price:{buyable.Item1}$";
        PriceLabelShadow.text = $"Price:{buyable.Item1}$";
        PreviewImage.sprite = buyable.Item2.previewImage;
        BuyButton.onClick.AddListener(BuyButtonAction);
    }

    void BuyButtonAction()
    {
        if(int.TryParse(amountField.text, out int amount))
        {
            if (gameManager.Shop.BuyItems(buyable.Item2.id, amount))
            {
                Debug.Log("Bought!");
            }
        }
        else if(gameManager.Shop.BuyItems(buyable.Item2.id, 1))
        {
            Debug.Log("Bought!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
