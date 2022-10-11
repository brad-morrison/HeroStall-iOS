using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetText : Game
{
    TextMesh textMesh;

    // what to display?
    public bool display_Time;
    public bool display_Coins;

    private void Start()
    {
        textMesh = this.GetComponent<TextMesh>(); // get text component
        game.time.Ticked += UpdateText; // sub to time tick event
        game.player.CoinChange += UpdateText; // sub to coin change event
    }

    private void UpdateText()
    {
        // update text according to selection (default to null)
        if (display_Time)
            textMesh.text = game.time.TimeString();
        else if (display_Coins)
            textMesh.text = game.player.coins.ToString();
        else
            textMesh.text = "null";
    }
}
