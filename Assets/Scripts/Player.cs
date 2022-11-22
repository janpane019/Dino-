using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpHeight;
    public Camera camera;
    
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
        camera.transform.position = new Vector3(transform.position.x, camera.transform.position.y, -10);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyHeld = true;
            if (canJump)
            {
                canJump = false;
                rb.AddForce(Vector2.up * jumpForce * rb.mass, ForceMode2D.Impulse);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpKeyHeld = false;
        }

        Speed = Math.Max(Math.Min(Speed + Time.deltaTime * 0.55f, 65), 8);
    }
    private void FixedUpdate()
    {
        if (!canJump)
        {
            if (!jumpKeyHeld && Vector2.Dot(rb.velocity, Vector2.up) > 0)
            {
                rb.AddForce(new Vector2(0, -100) * rb.mass);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
