using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private bool stoppedJumpig;
    

    private Rigidbody2D rb;
    // private Collider2D myCollider;
    public GameManager theGameManager;

    private bool canDoubleJump;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
       // myCollider = GetComponent<Collider2D>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumpig = true;
        
 
    }
	
	void Update ()
    {
        // grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x>speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) 
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                stoppedJumpig = false;
            }
            if(!grounded &&canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stoppedJumpig = false;
                canDoubleJump = false;
            }
        }
        if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumpig)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
       if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumpig = true;
        } 
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }
	}

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag =="DeathBox")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }

}
