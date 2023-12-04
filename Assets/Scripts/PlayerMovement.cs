using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = true;
    float jumpPower = 15f;
    bool isGrounded = false;

    Rigidbody2D rb;
    Animator animator;

    private int coinCounter = 0;
    public TMP_Text counterText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement and jumping code
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        //Jump animation code
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            //Flipping player sprite code
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Platfrom collision code
        if (collision.CompareTag("Platform"))
        {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
        }
        else if (collision.CompareTag("Coin") && collision.gameObject.activeSelf == true)
        {
            //Coin Code
            collision.gameObject.SetActive(false);
            coinCounter += 1;
            counterText.text = "Coins 16/ " + coinCounter;
        }

    }
}
