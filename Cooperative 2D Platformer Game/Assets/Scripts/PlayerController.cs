using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float jumpSpeed = 30.0f;
    [SerializeField]
    private GroundCheck groundCheck = null;
    [SerializeField]
    private Animator animator = null;

    private Rigidbody2D rigidBody = null;
    private PlayerInput playerInput = null;
    private InputAction moveAction = null;
    private InputAction jumpAction = null;
    private float direction = 1.0f;
    private bool isJumping = false;
    private bool isFalling = false;
    // private Vector3 startingPosition = Vector3.zero;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInput = new PlayerInput();
        if (gameObject.name.Contains ("Penguin1"))
        {
            moveAction = playerInput.Player.Move;
            jumpAction = playerInput.Player.Jump;
        }
        else if (gameObject.name.Contains ("Penguin2"))
        {
            moveAction = playerInput.Player2.Move;
            jumpAction = playerInput.Player2.Jump;
        }

        jumpAction.performed += OnJump;

        // startingPosition = transform.position;
    }

    private void OnEnable()
    {
        playerInput.Enable();
        moveAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
        moveAction.Disable();
        jumpAction.Disable();
    }

    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        rigidBody.linearVelocityX = moveInput.x * moveSpeed;

        if (Mathf.Abs(moveInput.x) > 0.1f)
        {
            direction = (moveInput.x > 0) ? 1.0f : -1.0f;
        }

        float speed = Mathf.Abs(rigidBody.linearVelocityX);
        if (!groundCheck.isGrounded && rigidBody.linearVelocityY <= 1.0f)
        {
            isFalling = true;
            isJumping = false;
        }
        else if (groundCheck.isGrounded)
        {
            isFalling = false;
        }

        animator.SetFloat("Direction", direction);
        animator.SetFloat("Speed", speed);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);

        //if (isfalling && transform.position.y < -20.0f)
        //{
        //    transform.position = startingposition;
        //}
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (groundCheck.isGrounded && rigidBody.linearVelocityY <= 0.1f)
        {
            rigidBody.linearVelocityY = jumpSpeed;
            isJumping = true;
            isFalling = false;
        }
    }
}