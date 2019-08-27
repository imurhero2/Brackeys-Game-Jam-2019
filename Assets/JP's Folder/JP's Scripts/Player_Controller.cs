using UnityEngine;
using UnityEngine.Events;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float jumpForce = 400f;
    [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [Range(0, 10f)][SerializeField] private float climbSpeed = 1;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private Collider2D crouchDisableCollider;
    [SerializeField] private Animator myAnimator;



    const float ceilingRadius = 1f;
    const float groundedRadius = .2f;
    private bool grounded;
    private Rigidbody2D playerRigidBody;
    private bool facingRight = true;
    private Vector3 playerVelocity = Vector3.zero;

    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool wasCrouching = false;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    public void FixedUpdate()
    {
        ClimbLadder();
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
            {
                crouch = true;
            }
        }

        if (grounded)
        {
            if (crouch)
            {
                if (!wasCrouching)
                {
                    wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                move *= crouchSpeed;

                if (crouchDisableCollider != null)
                {
                    crouchDisableCollider.enabled = false;
                }
            }
            else
            {
                if (crouchDisableCollider != null)
                {
                    crouchDisableCollider.enabled = true;
                }
                if (wasCrouching)
                {
                    wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }
        }

        if (!crouch)
        {
            myAnimator.SetFloat("run", Mathf.Abs(move));
        }

        Vector3 targetVelocity = new Vector2(move * 10f, playerRigidBody.velocity.y);
        playerRigidBody.velocity = Vector3.SmoothDamp(playerRigidBody.velocity, targetVelocity, ref playerVelocity, movementSmoothing);

        if (move > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if (move < 0 && facingRight)
        {
            FlipSprite();
        }

        if (grounded && jump)
        {
            grounded = false;
            playerRigidBody.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void FlipSprite()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void ClimbLadder()
    {
        if(!crouchDisableCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"))) { return; }

        float climb = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(playerRigidBody.velocity.x, climb * climbSpeed);
        playerRigidBody.velocity = climbVelocity;
        if (climb != 0)
        {
            myAnimator.SetBool("isClimbing", true);
        } else
        {
            myAnimator.SetBool("isClimbing", false);
        }
    }
}
