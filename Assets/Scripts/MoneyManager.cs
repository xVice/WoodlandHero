using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private int coins = 0;

    // Add a specific amount of coins
    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log($"Added {amount} coins, new total is {coins}!");
    }

    // Remove a specific amount of coins
    public void RemoveCoins(int amount)
    {
        coins -= amount;
        if (coins < 0)
        {
            coins = 0;
        }
        Debug.Log($"Removed {amount} coins, new total is {coins}!");
    }

    // Get the current number of coins
    public int GetCoins()
    {
        return coins;
    }

    // Check if the player has enough coins
    public bool HasEnoughCoins(int amount)
    {
        return coins >= amount;
    }

    // Reset the number of coins to zero
    public void ResetCoins()
    {
        coins = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}