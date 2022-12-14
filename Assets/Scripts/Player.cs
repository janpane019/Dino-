using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed;
    public Camera camera;
    public GameObject deathScreen;

    private Animator animControler;
    private Rigidbody2D rb;
    private PolygonCollider2D[] pc;
    private bool isDead;
    
    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;

    private bool crouching;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animControler = GetComponent<Animator>();
        pc = GetComponents<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);
        camera.transform.position = new Vector3(transform.position.x + 12, camera.transform.position.y, -10);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isDead)
            {
                Reset();
            }

            if (!jumping || rb.velocity.y == 0)
            {
                float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                jumping = true;
                jumpCancelled = false;
                jumpTime = 0;
            }
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animControler.SetBool("IsCrouching", true);
            pc[0].enabled = false;
            pc[1].enabled = true;
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            animControler.SetBool("IsCrouching", false);
            pc[0].enabled = true;
            pc[1].enabled = false ;
        }

        if (Input.GetKey(KeyCode.R))
        {
            Reset();
        }

        if (!isDead) Speed = Math.Max(Math.Min(Speed + Time.deltaTime * 0.55f, 65), 8);
    }
    private void FixedUpdate()
    {
        if(jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        deathScreen.SetActive(false);
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        isDead = true;
        Speed = 0;
        deathScreen.SetActive(true);
    }
}
