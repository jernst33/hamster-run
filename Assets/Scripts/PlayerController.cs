using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float passedMilestoneCount;

    private float moveSpeedStore;
    private float passedMilestoneCountStore;
    private float speedIncreaseMilestoneStore;

    public float jumpForce;

    public float jumpDuration;
    public float jumpDurationCounter;
    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    //private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager gameManager;

	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();
       // myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        jumpDurationCounter = jumpDuration;
        passedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        passedMilestoneCountStore = passedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        stoppedJumping = true;
        canDoubleJump = true;
	}
	
	void Update () {

        // grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if(transform.position.x > passedMilestoneCount)
        {
            passedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed *= speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        // Player wants to JUMP!
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpSound.Play();
            }

            if (!grounded && canDoubleJump)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpDurationCounter = jumpDuration;
                canDoubleJump = false;
                stoppedJumping = false;
                jumpSound.Play();

            }
        }

        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if(jumpDurationCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpDurationCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpDurationCounter = 0;
            stoppedJumping = true;
        }

        if(grounded)
        {
            jumpDurationCounter = jumpDuration;
            canDoubleJump = true;
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            gameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            passedMilestoneCount = passedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            deathSound.Play();

        }
    }
}
