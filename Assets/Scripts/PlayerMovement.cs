using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    private bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    public bool canCrouch;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    private bool grounded;

    [Header("Slope handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    public MovementState state;

    //Benjamin code

    [SerializeField]
    bool rotating = false;

    [SerializeField]
    private RotationPointScript rotationPoint;

    float rotationSpeed = 0.3f; //0.01f;
    float timeCount = 0.0f;

    public int gravityNumber = 0;

    public AudioSource killSound;

    private bool paused;

    public GameObject pCamera;

    public GameObject pauseMenu;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }

    private void Start()
    {
        rotationPoint = FindObjectOfType<RotationPointScript>();
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        readyToJump = true;

        startYScale = transform.localScale.y;
        canCrouch = true;

        gravityNumber = 0;
    }

    private void Update()
    {
        //Ground check
        grounded = Physics.Raycast(transform.position, -1 * transform.up, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();

        //Handle drag
        if (grounded == true)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        

        //Normal gravity
        if (Input.GetKeyDown(KeyCode.E))
        {
            //gravityText.text = "Gravity: Down";

            GetComponent<GravityComponent>().gravityStatus = gravityNumber;

            StartRotation();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == false)
            {
                paused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                GetComponent<LazerScript>().enabled = false;
                pCamera.GetComponent<PlayerCamera>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                GetComponent<LazerScript>().enabled = true;
                pCamera.GetComponent<PlayerCamera>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("KillFloor"))
        {
            killSound.Play();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //When to jump
        if (Input.GetKeyDown(jumpKey) && readyToJump == true && grounded == true)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }


    }

    private void StateHandler()
    {
        //Sprinting mode
        if (grounded == true && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        //Walking mode
        else if (grounded == true)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        //Air mode
        else
        {
            state = MovementState.air;
        }


    }

    private void MovePlayer()
    {

        //Calculate the movement direction
        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        //On slope
        if (OnSlope() && exitingSlope == false)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        //On ground
        if (grounded == true)
        {
            rb.AddForce((moveDirection.normalized * moveSpeed * 10f), ForceMode.Force);
        }
        //In air
        else if (grounded == false)
        {
            rb.AddForce((moveDirection.normalized * moveSpeed * 10f * airMultiplier), ForceMode.Force);
        }

        //Turn gravity off while on slope
        //rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        //Limit speed on slope
        if (OnSlope() && exitingSlope == false)
        {
            if (rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }

        //Limiting speed on ground or in the air
        /*else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //Limit velocity if needed
            if (rb.velocity.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }*/
    }

    private void Jump()
    {
        exitingSlope = true;

        //Reset y velocity
        //rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    public void StartRotation()
    {
        if (!rotating)
        {
            rotationPoint.UpdateBallRotation(GetComponent<GravityComponent>().gravityStatus);
            StartCoroutine(RotatePlayer());
        }
    }

    

    private IEnumerator RotatePlayer()
    {
        rotating = true;
        timeCount = 0f;
        Quaternion endRot = rotationPoint.transform.rotation;

        while (timeCount < 0.15f)
        {
            timeCount += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, endRot, timeCount);
            yield return new WaitForEndOfFrame();
        }
        transform.rotation = endRot;
        rotating = false;
    }
}
