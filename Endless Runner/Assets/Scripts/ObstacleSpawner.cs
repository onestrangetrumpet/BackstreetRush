using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{ 
    public Transform[] spawners;
    public Obstacle[] obstacles;
    public Transform[] envSpawners;
    public Obstacle[] environments;
    public float spawnRate;
    public int obstacleCount = 0;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
       timer = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else 
        {
            SpawnObstacles();
            SpawnEnvironments();
            timer = spawnRate;
            obstacleCount += 1;
        }  

        if (obstacleCount == 10) 
        {
            obstacleCount = 0;
            spawnRate = spawnRate *= 0.9f;  
        }

        spawnRate = Mathf.Max(spawnRate, 1f);
    }

    public void SpawnObstacles()
    {
        int tallObstacles = 0;

        foreach(Transform spawner in spawners)
        {
            if(Random.value > 0.5f)
            {
                int randNumber = 0;
                if (tallObstacles < 2)
                {
                    randNumber = Random.Range(0, obstacles.Length);
                }
   
                Obstacle newObstacle = Instantiate(obstacles[randNumber], spawner.position, spawner.rotation);

                if (newObstacle.transform.localScale.y == 3)
                {
                    tallObstacles ++;
                    newObstacle.transform.position += new Vector3(0, 2f, 0);
                }

                if (newObstacle.transform.localScale.y == 2)
                {
                    newObstacle.transform.position += new Vector3(0, 1.5f, 0);
                }

                if (newObstacle.transform.localScale.y == 1.25)
                {
                    newObstacle.transform.position += new Vector3(0, 1.125f, 0);
                }
            }     
        }
    }

    public void SpawnEnvironments()
    {
        foreach(Transform spawner in envSpawners)
        {
            Instantiate(environments[0], spawner.position, spawner.rotation);
        }
    }
}
