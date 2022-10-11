using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Game
{
    // player variables
    public int coins;
    // events
    public event Action CoinChange;

    // add amount to coins
    public void AddCoins(int amount)
    {
        coins += amount;
        CoinChange();
    }

    // remove amount from coins (but not below 0)
    public void RemoveCoins(int amount)
    {
        if (coins - amount < 0)
            coins = 0;
        else
            coins -= amount;
    }
}
