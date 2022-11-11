using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpHeight;
    private Rigidbody2D rb;
    private bool canJump = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Speed * Time.deltaTime, 0, 0);
       if (Input.GetKey(KeyCode.Space) && canJump)
       {
           canJump = false;
           rb.AddForce(new Vector2(0, JumpHeight));
           Debug.Log("Jump");
       }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            Debug.Log("Can jump = true");
        }
    }
}
