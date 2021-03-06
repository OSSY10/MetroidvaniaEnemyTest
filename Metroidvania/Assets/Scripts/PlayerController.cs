using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float dashTime, dashSpeed;
    public float waitAfterDashing;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask whatIsLayer;
    [SerializeField] Animator anim;
    [SerializeField] Animator ballAnim;
    [SerializeField] BulletController bullet;
    [SerializeField] Transform bulletPosition;
    [SerializeField] SpriteRenderer theSR, afterImage;
    [SerializeField] float afterImageLifetime, timeBetweenAfterImage;
    [SerializeField] Color afterImageColor;
    [SerializeField] GameObject standing, ball;
    [SerializeField] float waitForBall;

    bool isOnGround;
    bool canDoubleJump;
    float horizontalInput;
    float dashCounter;
    float afterImageCounter;
    float dashRechargeCounter;
    float ballCounter;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animation();
        Flip();
        Shooting();
        BallMode();
    }
    void Movement()
    {
        if (dashRechargeCounter > 0)
        {
            dashRechargeCounter -= Time.deltaTime;
        }
        else
        {
            if (Input.GetButtonDown("Fire2") && standing.activeSelf)
            {
                dashCounter = dashTime;
                AfterImage();
            }
        }

        
        if(dashCounter > 0)
        {
            
            dashCounter = dashCounter - Time.deltaTime;
            rb.velocity = new Vector2(dashSpeed * transform.localScale.x, rb.velocity.y);
            afterImageCounter -= Time.deltaTime;
            if(afterImageCounter <= 0)
            {
                AfterImage();
            }
            dashRechargeCounter = waitAfterDashing;
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }
        

        isOnGround = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsLayer);

        if(Input.GetButtonDown("Jump") && (isOnGround || canDoubleJump))
        {
            if(isOnGround)
            {
                canDoubleJump = true;
            }
            else
            {
                canDoubleJump = false;
                anim.SetTrigger("doubleJump");
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void Animation()
    {
        if(standing.activeSelf)
        {
            anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
            anim.SetBool("isOnGround", isOnGround);
        }
        else
        {
            ballAnim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        }
        
    }
    void Flip()
    {
        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }

    }
    void Shooting()
    {
        if(Input.GetButtonDown("Fire1") && standing.activeSelf)
        {
            Instantiate(bullet, bulletPosition.position, bulletPosition.rotation).moveDirection = new Vector2(transform.localScale.x, 0);
            anim.SetTrigger("firedBullet");
        }
    }
    void AfterImage()
    {
        SpriteRenderer image = Instantiate(afterImage, transform.position, transform.rotation);
        image.sprite = theSR.sprite;
        image.transform.localScale = transform.localScale;
        image.color = afterImageColor;
        Destroy(image.gameObject, afterImageLifetime);
        afterImageCounter = timeBetweenAfterImage;
    }
    void BallMode()
    {
        if(!ball.activeSelf)
        {
            if(Input.GetAxisRaw("Vertical") < -.9f)
            {
                ballCounter -= Time.deltaTime;
                if(ballCounter <= 0)
                {
                    ball.SetActive(true);
                    standing.SetActive(false);
                }
                
            }
            else
            {
                ballCounter = waitForBall;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > .9f)
            {
                ballCounter -= Time.deltaTime;
                if (ballCounter <= 0)
                {
                    ball.SetActive(false);
                    standing.SetActive(true);
                }

            }
            else
            {
                ballCounter = waitForBall;
            }
        }
    }



}
