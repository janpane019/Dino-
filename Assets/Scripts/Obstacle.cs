using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnBecameInvisible()
    {
        Debug.Log("Obstacle invisible");
        transform.position = new Vector3(player.transform.position.x + 25 + Random.Range(0, 10), transform.position.y, transform.position.z);
    }
}
