using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    public Player player;
    
    private float lastPowerUpX = 100; // Position of last powerups
    private float spawnDistance = 25; // Minimal distance between powerups
    
    // Update is called once per frame
    void Update()
    {
        // Distance icreases with speed
        float additionalDistance = player.Speed / 2;
        
        // Is player far enough to spawn obstacle?
        if (lastPowerUpX + spawnDistance + additionalDistance < player.transform.position.x + 30) 
        {
            float spawnX = player.transform.position.x + 20 + Random.Range(4, 10);
            lastPowerUpX = spawnX;
            
            Instantiate(PowerUpPrefab, new Vector3(spawnX, 1, 0), Quaternion.identity); // Spawn obstacle prefab
        }
    }
}
