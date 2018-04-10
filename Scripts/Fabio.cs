using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabio : MonoBehaviour {

    public float speed = 5;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private Animator animator;

    public bool facingRight = true;

    public float jumpingSpeed = 5f;

    bool isJumping = false;

    private float rayCastLength = 0.005f;

    private float width;
    private float height;

    private float jumpButtonPressTime;

    private float maxJumpTime = 0.2f;

    private void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");
        Vector2 vect = rb.velocity;
        rb.velocity = new Vector2(horzMove * speed, vect.y);
        

        if(horzMove > 0 && ! facingRight)
        {
            Flipfabio(); // still need to create
        }
        else if(horzMove < 0 && facingRight)
        {
            Flipfabio();
        }

        float vertMove = Input.GetAxis("Jump");


        if (IsOnGround())
        {
            animator.SetFloat("speed", Mathf.Abs(horzMove));
            animator.SetBool("isJumping", false);
        }

        if(IsOnGround() && isJumping == false)
        {
            if(vertMove> 0f)
            {
                isJumping = true;
            }
        }
        if (jumpButtonPressTime > maxJumpTime)
        {
            vertMove = 0f;
        }

        if (isJumping && (jumpButtonPressTime < maxJumpTime))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingSpeed);
        }

        if (vertMove >= 1F)
        {
            jumpButtonPressTime += Time.deltaTime;
        }

        else
        {
            isJumping = false;
            jumpButtonPressTime = 0f;
        }
        // returns false if not on ground
        Debug.Log(IsOnGround());
    }
    public bool IsOnGround()
    {
        bool groundCheck1 = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - height),
            -Vector2.up,
            rayCastLength);
        return groundCheck1;
    }

    void Flipfabio()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<Collider2D>().bounds.extents.y + 0.2f;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
