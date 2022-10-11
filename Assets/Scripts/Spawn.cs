using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : Game
{
    public GameObject boundaryX;
    public GameObject boundaryYt;
    public GameObject boundaryYb;
    Vector3 boundX;
    Vector3 boundYt;
    Vector3 boundYb;
    public GameObject human;
    // Start is called before the first frame update
    void Start()
    {
        boundX = boundaryX.transform.position;
        boundYt = boundaryYt.transform.position;
        boundYb = boundaryYb.transform.position;
    }

    Vector3 RandomPosition()
    {
        Vector3 pos;
        pos.x = boundX.x;
        pos.y = Random.Range(boundYb.y, boundYt.y);
        pos.z = boundX.z;

        return pos;
    }    

    public void SpawnHuman()
    {
        GameObject humanInstance = Instantiate(human, RandomPosition(), Quaternion.identity);
    }


}
