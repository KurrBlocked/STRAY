using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Attributes
    private Rigidbody rb;
    private Transform camera;
    public float speed = 5f;
    public float runningSpeed = 2f;
    private float isRunning = 1f;
    private bool hasJumped;
    private float smooth_time = 0.1f;
    private float ang_vel;
    public int PowerBanks = 0;
    public GameObject sensor_ui;
    private bool open = false;
    public bool win;
    public bool lose;
    public Animator anim;

    public AudioClip step;
    private AudioSource audioSource;
    public bool walking;
    public bool running;

    // Player Inputs
    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private InputAction move;
    private InputAction jump;
    public InputAction interact;
    public InputAction sensor;
    public InputAction sprint;
    public InputAction crouch;
    public InputAction menu;
    public InputAction quit;


    // AWAKE
    private void Awake()
    {
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        jump = playerInput.actions["Jump"];
        interact = playerInput.actions["Interact"];
        sensor = playerInput.actions["Sensor"];
        sprint = playerInput.actions["Sprint"];
        crouch = playerInput.actions["Crouch"];
        menu = playerInput.actions["Menu"];
        quit = playerInput.actions["Quit"];
    }

    // ENABLE
    private void OnEnable()
    {
        playerControls.Enable();

        // Subscribe to Player Input System
        interact.performed += Interact;
    }

    // DISABLE
    private void OnDisable()
    {
        playerControls.Disable();

        // Unsubscribe to Player Input System
        interact.performed -= Interact;
    }

    // START
    private void Start()
    {
        camera = Camera.main.transform;
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // UPDATE
    private void Update()
    {
        // bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.33f);
        // if (isGrounded && !audioSource.isPlaying) {
        //     audioSource.PlayOneShot(step);
            // anim.getBool("Run");
        // }
        // Jump Trigger
        if (jump.triggered)
        {
            //hasJumped = true;
        }

        // Sprint Trigger
        if (sprint.ReadValue<float>() != 0 && move.ReadValue<Vector2>().magnitude != 0)
        {
            isRunning = runningSpeed;
            anim.SetBool("Run", true);
        }
        else
        {
            isRunning = 1f;
            anim.SetBool("Run", false);
        }

        //// Crouch Trigger
        //if (crouch.ReadValue<float>() != 0)
        //{
        //    isRunning = 0.5f;
        //}
        //else
        //{
        //    //isRunning = 1f;
        //}

        //// Sensor Trigger
        //if (sensor.triggered)
        //{
        //    open = !open;
        //    sensor_ui.SetActive(open);
        //}

        //// Tab
        //if (menu.triggered)
        //{
        //    Debug.Log("MENU");
        //}

        //if (quit.triggered)
        //{
        //    Application.Quit();
        //}
    }

    // FIXED UPDATE
    private void FixedUpdate()
    {
        Vector2 move_value = move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(move_value.x, 0, move_value.y).normalized;

        // Rotation
        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref ang_vel, smooth_time);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Position
        Vector3 direction = Quaternion.Euler(0f, targetAngle, 0f) * (Vector3.forward * movement.magnitude);
        rb.velocity = (speed * (isRunning) * direction.normalized) + new Vector3(0f, rb.velocity.y, 0f);
        walking = false;
        running = false;
        if (move_value.magnitude == 0f)
        {
            rb.velocity = Vector3.zero;
        }
        if (move_value.magnitude > .33f){
            walking = true;
            running = false;
        }
        if (anim.GetBool("Run")){
            running = true;
            walking = false;
        }

        anim.SetFloat("Speed", rb.velocity.magnitude);

        //// Jump
        //if (hasJumped)
        //{
        //    rb.velocity += new Vector3(0, 5, 0);
        //    hasJumped = false;
        //}
    }

    // Interact
    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("INTERACTED :D");
    }
}
