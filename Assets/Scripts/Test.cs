using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Game
{
    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            //game.dayNight.Spawn();
        }

        if (Input.GetKeyDown("c"))
        {
            game.player.AddCoins(5);
        }

        if (Input.GetKeyDown("t"))
        {
            game.time.PauseTime();
        }

        if (Input.GetKeyDown("s"))
        {
            game.spawn.SpawnHuman();
        }
    }
}
