using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    public Vector3 snakeDirection;
    public bool grounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float JumpForce = 7.5f;
    private float posMaxDistance = 3f;

    private Rigidbody snakeRB;
    private Animator snakeAnimator;
    private SwipeManager swipeManager;
    private bool m_Started;


    private void Awake()
    {
        swipeManager = SwipeManager.Instance;
        snakeRB = GetComponent<Rigidbody>();
        snakeAnimator = GetComponent<Animator>();

        snakeDirection = transform.localPosition;
        m_Started = true;

    }

    private void Update()
    {
        DetectInput();
        //Boundaries();
    }

    private void FixedUpdate()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, snakeDirection, posMaxDistance * Time.deltaTime);
        IsGrounded();
        Jump();  
           
    }

    private void IsGrounded()
    {

        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, groundLayer);

        if (hitColliders.Length != 0)
        {
            grounded = true;
            snakeAnimator.SetBool("isJumping", false);
        }
        else
        {
            grounded = false;
            snakeAnimator.SetBool("isJumping", true);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (m_Started)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    private void Jump()
    {
        if (swipeManager.SwipeUp && grounded)
        {
            snakeRB.AddForce(Vector3.up * JumpForce * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void DetectInput()
    {
        if (swipeManager.SwipeLeft)
            snakeDirection += Vector3.left;
        if (swipeManager.SwipeRight)
            snakeDirection += Vector3.right;
        if (swipeManager.SwipeDown)
            snakeDirection += Vector3.down;
    }

    private void Boundaries()
    {
        float xRange = Mathf.Clamp(transform.position.x, -1f, 1f);
        float yRange = Mathf.Clamp(transform.position.y, 0f, 4f);
        transform.position = new Vector3(xRange, 0, transform.position.z);
       

        if(snakeDirection.x <= -1f)
            snakeDirection.x = -1f;
        else if (snakeDirection.x >= 1f)
            snakeDirection.x = 1f;
    }

}
