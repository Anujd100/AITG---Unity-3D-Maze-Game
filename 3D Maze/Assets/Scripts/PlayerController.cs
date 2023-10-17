using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float walkSpeed = 0.1f;
    public float runSpeed = 0.2f;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 2;

    public static float mouseSensitivity = 2.0f;

    private bool playerMovementEnabled = true;
    public static bool isWalking;
    public static bool isSprinting;

    private Camera mainCamera;
    private CharacterController cc;
    private float verticalRotation = 0;
    
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        PlayerHUD.levelScore = 0;

        mainCamera = GetComponentInChildren<Camera>();
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        EnablePlayerMovement();
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += DisablePlayerMovement;
        EndLevelManager.OnLevelCompleted += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= DisablePlayerMovement;
        EndLevelManager.OnLevelCompleted -= DisablePlayerMovement;
    }

    void Update()
    {
        if (playerMovementEnabled != true) return;

        // Camera rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        float verticalRotationInput = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        verticalRotation -= verticalRotationInput;
        verticalRotation = Mathf.Clamp(verticalRotation, -80, 80);

        transform.Rotate(0, horizontalRotation, 0);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        float forwardInput = Input.GetAxis("Vertical") * moveSpeed;
        float sideInput = Input.GetAxis("Horizontal") * moveSpeed;

        //Player movement
        if (cc.isGrounded)
        {
            //Movement Velocities
            moveVelocity = transform.forward * moveSpeed * forwardInput;
            turnVelocity = transform.right * moveSpeed * sideInput;

            //Jumping
            if (Input.GetKey("space"))
            {
                moveVelocity.y = jumpSpeed;
            }
        }

        //Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Increase the player's move speed
            moveSpeed = runSpeed;
        }
        //Walking
        else
        {
            // Decrease the player's move speed
            moveSpeed = walkSpeed;
        }

        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;

        Vector3 movement = transform.forward * forwardInput + transform.right * sideInput + moveVelocity;

        cc.Move(movement * Time.deltaTime);
    }

    private void DisablePlayerMovement()
    {
        playerMovementEnabled = false;
    }

    private void EnablePlayerMovement()
    {
        playerMovementEnabled = true;
    }
}
