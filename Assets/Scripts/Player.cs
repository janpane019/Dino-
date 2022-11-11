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
    private bool jumpKeyHeld = false;
    private float jumpForce;
    
    // Start is called before the first frame update
    void Start()
    {
        jumpForce = Mathf.Sqrt(2 * Physics2D.gravity.magnitude * JumpHeight);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Speed * Time.deltaTime, 0, 0);
        /*if (Input.GetKey(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(new Vector2(0, JumpHeight));
            Debug.Log("Jump");
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyHeld = true;
            if (canJump)
            {
                canJump = false;
                rb.AddForce(Vector2.up * jumpForce * rb.mass, ForceMode2D.Impulse);
                Debug.Log("Jump");
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpKeyHeld = false;
        }
    }
    private void FixedUpdate()
    {
        if (!canJump)
        {
            if (!jumpKeyHeld && Vector2.Dot(rb.velocity, Vector2.up) > 0)
            {
                rb.AddForce(new Vector2(0, -100) * rb.mass);
                Debug.Log("LongJump");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            Debug.Log("Can jump = true");
        }
    }
}
