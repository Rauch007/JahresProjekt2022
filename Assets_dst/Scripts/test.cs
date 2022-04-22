using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;

    Controller controls;
    public Rigidbody2D rb;

    public Transform groundPoint;
    public LayerMask Ground;
    private bool isGrounded;
    bool canDoubleJump = true;

    Vector2 move;


    private void Awake()
    {       
        controls = new Controller();

        controls.PlayerControls.Jump.performed += ctx => Jump();
      
        //Everytime Joystick is moved, this is perfomed. 
        controls.PlayerControls.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        //When Joystick is stopped being moved, the movment is set to 0
        controls.PlayerControls.Move.canceled += ctx => move = Vector2.zero;
    }

    void Jump()
    {
        //If the player is on the Ground we make him jump
        if (isGrounded)
        {          
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            canDoubleJump = true;
        }
        else
        {
            if (canDoubleJump)
            {
                canDoubleJump = false;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }
        }
        //Debug.Log(isGrounded);  
        //Debug.Log("jump");           
    }

    void FixedUpdate()
    {
       //Moving only on the X axis
        Vector2 m = new Vector2(move.x, 0f) * movespeed * Time.deltaTime;
        transform.Translate(m, Space.World);

        //Checking if the player is on the Ground or not. In the player is a Object, that we are using for a refernce Point (Basically its feet).
        //Also for all Ground Elements there is a Layer called "Ground". This must be used, otherwise the player will not jump.
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .1f, Ground);

        
    }
    
    void OnEnable()
    {
        controls.PlayerControls.Enable();
    }

    void OnDisable()
    {
        controls.PlayerControls.Disable();
    }
}
