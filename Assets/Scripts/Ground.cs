using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 screenPoint = camera.WorldToViewportPoint(gameObject.transform.position);
        bool isInView = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        if (transform.position.x < player.transform.position.x && !GetComponent<Renderer>().isVisible)
        {
            Debug.Log("NotVisible" + gameObject.name);
        }*/

    }
    private void OnBecameInvisible()
    {
        Debug.Log("Invisible");
        var bc = GetComponent<BoxCollider2D>();
        float width = bc.bounds.size.x;
        Debug.Log(width);
        transform.position = new Vector3(transform.position.x + width * 3, transform.position.y, transform.position.z);
    }
}
