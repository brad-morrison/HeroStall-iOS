using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Game
{
    float speedMin = 0.5f;
    float speedMax = 1.2f;
    float speed;
    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedMin, speedMax);
        Move();
    }

    public void Move()
    {
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            float newX = transform.position.x + speed * Time.deltaTime;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
