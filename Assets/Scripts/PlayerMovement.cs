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
    //[SerializeField] private GravityChange _gravityChange;

    public TMP_Text gravityText;

    //Benjamin code

    [SerializeField]
    bool rotating = false;

    [SerializeField]
    private RotationPointScript rotationPoint;

    float rotationSpeed = 0.3f; //0.01f;
    float timeCount = 0.0f;

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

        gravityText.text = "You are falling down";
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

        float yRotation;
        

        //Normal gravity
        if (Input.GetKeyDown(KeyCode.E) && GetComponent<GravityComponent>().gravityStatus != 0)
        {
            gravityText.text = "You are falling down";

            GetComponent<GravityComponent>().gravityStatus = 0;

            //yRotation = transform.eulerAngles.y;

            //yRotation = transform.rotation.y;

            //transform.localRotation = Quaternion.Euler(0, yRotation, 0f);

            //pCamera.Flip(new Vector3(0, yRotation, 0f));

            StartRotation();
        }
        //Up gravity
        if (Input.GetKeyDown(KeyCode.R) && GetComponent<GravityComponent>().gravityStatus != 1)
        {
            gravityText.text = "You are falling up";

            GetComponent<GravityComponent>().gravityStatus = 1;

            //yRotation = transform.eulerAngles.y;

            //yRotation = transform.rotation.y;

            //transform.localRotation = Quaternion.Euler(0f, yRotation, -180f);

            //pCamera.Flip(new Vector3(-180f, yRotation, 0f));

            StartRotation();
        }
        //North gravity
        if (Input.GetKeyDown(KeyCode.T) && GetComponent<GravityComponent>().gravityStatus != 2)
        {
            gravityText.text = "You are falling north";

            GetComponent<GravityComponent>().gravityStatus = 2;

            //yRotation = transform.eulerAngles.y;

            //yRotation = transform.rotation.y;

            //transform.localRotation = Quaternion.Euler(-90, yRotation, 0f);

            //pCamera.Flip(new Vector3(-90, yRotation, 0f));

            StartRotation();
        }
        //South gravity
        if (Input.GetKeyDown(KeyCode.Y) && GetComponent<GravityComponent>().gravityStatus != 3)
        {
            gravityText.text = "You are falling south";

            GetComponent<GravityComponent>().gravityStatus = 3;

            //yRotation = transform.eulerAngles.y;

            //yRotation = transform.rotation.y;

            //transform.localRotation = Quaternion.Euler(90, yRotation, 0f);

            //pCamera.Flip(new Vector3(90, yRotation, 0f));

            StartRotation();
        }
        //West gravity
        if (Input.GetKeyDown(KeyCode.U) && GetComponent<GravityComponent>().gravityStatus != 4)
        {
            gravityText.text = "You are falling west";

            GetComponent<GravityComponent>().gravityStatus = 4;

            //yRotation = transform.eulerAngles.y;

            //yRotation = transform.rotation.y;

            //transform.localRotation = Quaternion.Euler(0f, yRotation, -90f);

            //pCamera.Flip(new Vector3(0, yRotation, -90f));

            StartRotation();
        }
        //East gravity
        if (Input.GetKeyDown(KeyCode.I) && GetComponent<GravityComponent>().gravityStatus != 5)
        {
            gravityText.text = "You are falling east";

            GetComponent<GravityComponent>().gravityStatus = 5;

            //yRotation = transform.eulerAngles.y;

            //yRotation = transform.rotation.y;

            //transform.localRotation = Quaternion.Euler(0f, yRotation, 90f);

            //pCamera.Flip(new Vector3(0, yRotation, 90f));

            StartRotation();
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
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

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

    private void StartRotation()
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
            yield return null;
        }
        rotating = false;
    }
}
