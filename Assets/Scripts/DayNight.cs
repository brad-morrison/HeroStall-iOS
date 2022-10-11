using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DayNight : Game
{
    // sun and moon objects
    public GameObject sunPrefab;
    public GameObject moonPrefab;
    GameObject sun; // the actual sun
    GameObject moon; // the actual moon
    // spawn position and targets
    public GameObject spawnPosition;
    public GameObject startMid;
    // control variables
    public float maxHeight; // height that the objects will reach
    float sunriseTime;
    float sunsetTime;
    float timeToTake;
    // current object
    GameObject currentObj;
    // flags
    bool phase1Started = false;
    bool phase2Started = false;
    bool phase3Started = false;
    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        // init variables
        sunriseTime = 7;
        sunsetTime = 7;
        maxHeight = 3.5f;
        timeToTake = 300; // 5mins

        // events
        game.time.Paused += PauseTweens;

        SpawnMoon(startMid.transform.position);
        PhaseOne();
    }

    public void PauseTweens()
    {
        if (!paused)
            DOTween.Pause("sunMoon"); // pause
        else
            DOTween.Play("sunMoon"); // play

        paused = !paused; // toggle bool
    }

    // spawn moon or sun at spawn position
    public void SpawnSun(Vector3 pos)
    {
        GameObject sun = Instantiate(sunPrefab, pos, Quaternion.identity);
        currentObj = sun;
    }

    public void SpawnMoon(Vector3 pos)
    {
        GameObject moon = Instantiate(moonPrefab, pos, Quaternion.identity);
        currentObj = moon;
    }

    public void PhaseOne()
    {
        phase1Started = true;
        // how many realtime seconds till sunrise?
        float secs = game.time.timeBreak * 60/game.time.timeInc;
        // move moon
        currentObj.transform.DOMoveY(spawnPosition.transform.position.y, secs).SetId("sunMoon"); ;
    }

    public void PhaseTwo()
    {
        phase2Started = true;
        // how many realtime seconds till sunset?
        float secs = game.time.timeBreak * (60/game.time.timeInc * 12);
        // spawn sun
        SpawnSun(spawnPosition.transform.position);
        // move sun
        Sequence pingPong = DOTween.Sequence().SetId("sunMoon");
        pingPong.Append(currentObj.transform.DOMoveY(spawnPosition.transform.position.y+maxHeight, secs / 2).SetEase(Ease.OutSine));
        pingPong.Append(currentObj.transform.DOMoveY(spawnPosition.transform.position.y, secs / 2).SetEase(Ease.InSine));

    }

    public void PhaseThree()
    {
        phase3Started = true;
        // how many realtime seconds till end of level?
        float secs = game.time.timeBreak * (60/game.time.timeInc * 12);
        // spawn moon
        SpawnMoon(spawnPosition.transform.position);
        // move moon
        currentObj.transform.DOMoveY(spawnPosition.transform.position.y+maxHeight, secs).SetId("sunMoon"); ;
    }

    private void Update()
    {
        // move sun to position by time percentage
        //float timePercentage = PercentageOfDay();
        //float distanceAsPercentage = (timePercentage * distanceBetweenTargets) / 100;
        //currentObj.transform.position = new Vector3(spawnPosition.transform.position.x + distanceAsPercentage, currentObj.transform.position.y, currentObj.transform.position.z);

        if (!phase2Started && game.time.timeHour == 7)
        {
            PhaseTwo();
        }

        if (!phase3Started && game.time.timeHour == 7 && game.time.timeExt == "pm")
        {
            PhaseThree();
        }
    }
}
