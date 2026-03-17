using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{ 
    public Transform[] spawners;
    public Obstacle[] obstacles;
    public float spawnRate;
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
            foreach(Transform spawner in spawners)
            {
                int randNumber = Random.Range(0, obstacles.Length);      
                Instantiate(obstacles[randNumber], spawner.position, spawner.rotation);
                timer = spawnRate;
            }
        }        
    }
}
