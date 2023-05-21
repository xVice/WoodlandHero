using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI money;
    public TextMeshProUGUI moneyShadow;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoney();
    }

    private void UpdateMoney()
    {
        money.text = $"Money:{gameManager.MoneyManager.GetCoins()}";
        moneyShadow.text = $"Money:{gameManager.MoneyManager.GetCoins()}";
    }
}
