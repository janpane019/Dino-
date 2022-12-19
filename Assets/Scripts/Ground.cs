using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if (player.transform.position.x >= transform.position.x + 25.6)
        {
            OnInvisible();
        }
    }

    private void OnInvisible()
    {
        var bc = GetComponent<BoxCollider2D>();
        float width = bc.bounds.size.x;
        transform.position = new Vector3(transform.position.x + width * 3, transform.position.y, transform.position.z);
    }
}
