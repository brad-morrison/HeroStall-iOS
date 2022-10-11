using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Game : MonoBehaviour
{
    public static Game game;

    public TimeClock    time { get { return GameObject.FindObjectOfType<TimeClock>(); } }
    public Player       player { get { return GameObject.FindObjectOfType<Player>(); } }
    public DayNight     dayNight { get { return GameObject.FindObjectOfType<DayNight>(); } }
    public Utilities    utilities { get { return GameObject.FindObjectOfType<Utilities>(); } }
    public Spawn        spawn { get { return GameObject.FindObjectOfType<Spawn>(); } }

    private void Awake()
    {
        game = this;

        // Make the game run as fast as possible
        Application.targetFrameRate = 300;
    }
}
