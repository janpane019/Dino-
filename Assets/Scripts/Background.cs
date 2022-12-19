using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Player player;
    private float width = 128;
    // Update is called once per frame
    void Update()
    {
        // parallax
        transform.Translate(player.Speed / 2 * Time.deltaTime, 0, 0);
        
        if (player.transform.position.x >= transform.position.x + 128)
        {
            OnInvisible();
        }
    }
    private void OnInvisible()
    {
        var bc = GetComponent<BoxCollider2D>();
        transform.position = new Vector3(transform.position.x + width * 2, transform.position.y, transform.position.z);
    }
}
