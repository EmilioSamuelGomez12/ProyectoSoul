using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb;

    [Header("SPEED SETTINGS")]
    [SerializeField] float crouchSpeed = 3f;
    [SerializeField] float ogSpeed = 6f;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float rotationSpeed = 3f;

    [Header("JUMP SETTINGS")]
    [SerializeField] float jumpForce = 6f;


    [Header("CHECKs AND PARAMETERS")]
    bool wasGrounded;
    bool wasFalling;
    float startOfFall;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform pushCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask pushAbleObject;


    PlayerHealthManager theHealthMan;

    [Header("SHADOW STATES")]
    public static bool shadowState = false;

    [Header("ABILITIES COOLDOWN")]
    public float[] timeRemaining;
    public bool timerIsRunning = false;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        movementSpeed = ogSpeed;
        shadowState = false;
    }

    // Update is called once per frame
    void Update()
    {

        movementSpeed = ogSpeed;
        shadowState = false;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        

        if (Input.GetButton("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        //if (Input.GetButton("Fire1"))
        //{
        //    AbilityDuration();
        //}
   

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        Vector3 V = new Vector3(horizontalInput * movementSpeed, 0f, verticalInput * movementSpeed);
        rb.velocity.Normalize();
        V.Normalize();


        if (rb.velocity != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
            Quaternion toRotation = Quaternion.LookRotation( V );
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            if (Physics.CheckSphere(pushCheck.position, .1f, pushAbleObject))
            {
                GetComponent<BoxCollider>().enabled = true;
                animator.SetBool("isPushing", true);
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
                animator.SetBool("isPushing", false);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isPushing", false);
        }

    }

    private void FixedUpdate()
    {
        IsGrounded();

        if (!wasFalling && isFalling) startOfFall = transform.position.y;
        if (!wasGrounded && IsGrounded() && (startOfFall - transform.position.y) > 6.5f) rb.GetComponent<PlayerHealthManager>().Die();

    }

    bool isFalling { get { return (!IsGrounded() && rb.velocity.y < 0); } }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground) || Physics.CheckSphere(groundCheck.position, .1f, pushAbleObject);
    }

    public void AbilityDuration()
    {
        timerIsRunning = true;
            if (timerIsRunning)
            {
                if (timeRemaining[0] > 0)
                {
                    timeRemaining[0] -= Time.deltaTime;
                    ShadowState();
                }
                else
                {
                    timeRemaining[0] = 0;
                    timerIsRunning = false;
                    StartCoroutine(StartCooldown(10));
                }
            }
    }

    public IEnumerator StartCooldown(int time)
    {
        yield return new WaitForSeconds(time);
        timeRemaining[0] = time;
        timerIsRunning = true;
    }

    public void ShadowState()
    {
        movementSpeed = crouchSpeed;
        shadowState = true;
    }

}
