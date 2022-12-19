using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float StartingSpeed; // The starting speed when game starts
    public float Speed; // Actual dino speed
    public Camera Camera;
    public GameObject DeathScreen;
    public GameObject StartUI;
    public GameObject OneUpAnimation;

    private Animator animControler;
    private Rigidbody2D rb;
    private PolygonCollider2D[] pc;
    private bool isDead;
    public int oneUps = 1;
    private int cameraZ = -10;
    
    
    private bool started;
    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    bool canReset;

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
        Camera.transform.position = new Vector3(transform.position.x + 12, Camera.transform.position.y, cameraZ);
        
        if (Input.GetButtonDown("Jump"))
        {
            if (isDead && canReset)
            {
                Reset();
            }

            if (!started)
            {
                StartRunning();
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
            if (Input.GetButtonUp("Jump"))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            animControler.SetBool("IsCrouching", true);
            pc[0].enabled = false;
            pc[1].enabled = true;
        }
        
        if (Input.GetAxis("Vertical") >= 0)
        {
            animControler.SetBool("IsCrouching", false);
            pc[0].enabled = true;
            pc[1].enabled = false ;
        }

        if (Input.GetButtonDown("Reset"))
        {
            Reset();
        }

        if (!isDead && started) Speed = Math.Max(Math.Min(Speed + Time.deltaTime * 0.55f, 65), 8);
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
            if(oneUps == 0)
            {
                Die();
            }
            else
            {
                oneUps--;
                Destroy(col.gameObject);
            }
        }
    }

    public void StartRunning()
    {
        started = true;
        Speed = StartingSpeed;
        StartUI.SetActive(false);
        animControler.SetBool("IsIdle", false);
    }

    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        DeathScreen.SetActive(false);
        StartUI.SetActive(true);
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        isDead = true;
        Speed = 0;
        DeathScreen.SetActive(true);
        StartCoroutine(AllowReset());
    }
    
    public void AddOneUp()
    {
        oneUps++;
        OneUpAnimation.SetActive(true);
        StartCoroutine(RemoveOneUpAnimation());
    }

    private IEnumerator RemoveOneUpAnimation()
    {
        yield return new WaitForSeconds(1);
        OneUpAnimation.SetActive(false);
    }

    private IEnumerator AllowReset()
    {
        yield return new WaitForSeconds(1);
        canReset = true;
    }
    
    public void FlipCamera()
    {
        Debug.Log("JIDJSD");
        return;
        // Nefuguje, zkusit něco jinýho
        var rot = Quaternion.Euler(0, 180, 0);
        Camera.transform.rotation = rot;
        cameraZ = 10;
        StartCoroutine(FlipCameraBack());
    }

    private IEnumerator FlipCameraBack()
    {
        yield return new WaitForSeconds(5);
        var rot = Quaternion.Euler(0, 0, 0);
        Camera.transform.rotation = rot;
        cameraZ = -10;
    }
}
