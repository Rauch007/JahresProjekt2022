using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;
    public int attackDamage;

    Controller controls;
    public Rigidbody2D rb;

    public Transform groundPoint;
    public LayerMask Ground;
    private bool isGrounded;
    bool canDoubleJump = true;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyMask; 

    Vector2 move;
    bool facingRight = true;
    bool facingLeft = false;
    int knockback = 5;

    public Animator animator;


    private void Awake()
    {       
        controls = new Controller();

        controls.PlayerControls.Jump.performed += ctx => Jump();

        controls.PlayerControls.ShortAttack.performed += ctx => Attack();

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
        //Debug.Log(move);
        //Turning
        if(move.x < 0 && facingRight)
        {
            Debug.Log("backward");
            var temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            facingLeft = true;
            facingRight = false;

            knockback *= -1;
        }
        else if(move.x > 0 && facingLeft)
        {
            Debug.Log("forward");
            var temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            facingLeft = false;
            facingRight = true;

            knockback *= -1;
        }
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

    void Attack()
    {
        animator.SetTrigger("Attack");
        
        //Debug.Log("attack");
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyMask);

        foreach(Collider2D enemy in hitenemies)
        {
            //Debug.Log("hit");
            //Enemy takes Damage
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);

            //Enemy gets knocked back
            enemy.GetComponent<EnemyMovement>().TakeDamage(knockback);
        }

        
    }

    //Draw Attackrange
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
