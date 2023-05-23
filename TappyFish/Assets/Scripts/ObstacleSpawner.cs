using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject obstacle;
    public float maxTime;
    public float maxY;
    public float minY;
    private float randomY;
     float timer;
     
     

     private void Start()
     {
         
     }

     void Update()
    {
        if (GameManager.gameOver == false&& GameManager.gameStarted==true)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }
       
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }
}
