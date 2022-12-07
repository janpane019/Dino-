using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public Player player;
    
    public GameObject[] Cactuses; // List of all cactus prefabs
    public GameObject Bird; // Bird prefab

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
            float spawnX = player.transform.position.x + 20 + Random.Range(4, 10);
            lastObstacleX = spawnX;
            Instantiate(Cactuses[Random.Range(0, Cactuses.Length)], new Vector3(spawnX, 1, 0), Quaternion.identity); // Spawn obstacle prefab
        }
    }
}
