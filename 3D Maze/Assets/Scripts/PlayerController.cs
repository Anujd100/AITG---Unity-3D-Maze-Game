using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float moveSpeed = 1.0f;
    public float walkSpeed = 0.1f;
    public float runSpeed = 0.2f;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 2;

    //Guns
    public GameObject AR;
    public GameObject Handgun;

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
        //Make sure AR is not locked and disabled at the start of the first level
        if(SceneManager.GetActiveScene().name == "3D Maze Level 1")
        {
            ARCollectionDetector.ARUnlocked = false;
            AR.SetActive(false);
            Handgun.SetActive(true);
        }
        

        Time.timeScale = 1;
        PlayerHUD.levelScore = 0;
        ProjectileGun.shootingEnabled = true;

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

        //Disable AR if it is not unlocked
        if(ARCollectionDetector.ARUnlocked == false) 
        {
            AR.SetActive(false);
            Handgun.SetActive(true);
        }

        // Camera rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * SettingsMenuScript.mouseSensitivity;
        float verticalRotationInput = Input.GetAxis("Mouse Y") * SettingsMenuScript.mouseSensitivity;
        
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
