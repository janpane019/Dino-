using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public Player player;
    
    public GameObject[] GroundObstacles; // List of all ground obstacle prefabs
    public GameObject Bird; // Bird prefab
    public float minBirdSpawnPositionX = 300;

    private float lastObstacleX = 0; // Position of last obstacle
    private float spawnDistance = 15; // Minimal distance between cactuses
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Distance icreases with speed
        float additionalDistance = player.Speed / 2;
        
        // Is player far enough to spawn obstacle?
        if (lastObstacleX + spawnDistance + additionalDistance < player.transform.position.x + 30) 
        {
            float spawnX = player.transform.position.x + 35 + Random.Range(4, 10);
            lastObstacleX = spawnX;
            
            // 30% chance to spawn bird if player is 500 meters far
            if (player.transform.position.x > minBirdSpawnPositionX && Random.Range(0, 100) <= 20)
            {
                var bait = Random.Range(0, 100) < 35 ? 1.5f : 0; // 35% to spawn bird bait that can be avoided by doing nothing
                Instantiate(Bird, new Vector3(spawnX, 2.5f + bait, 0), Quaternion.identity); // Spawn obstacle prefab
            }
            else
            {
                Instantiate(GroundObstacles[Random.Range(0, GroundObstacles.Length)], new Vector3(spawnX, 1, 0), Quaternion.identity); // Spawn obstacle prefab
            }
        }
    }
}
