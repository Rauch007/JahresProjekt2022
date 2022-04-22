using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //implementation of chasing would be nice but not my job
    [Header("Patrolling")]
    [SerializeField] private bool patrolling;

    [Header("Patrollpoints")]
    [SerializeField] private GameObject Patrollpoint1;
    [SerializeField] private GameObject Patrollpoint2;

    [Header("Other Variables")]
    private float speed = 0;
    [SerializeField] private float range;

    private GameObject goal;
    private Rigidbody2D rb;
    [HideInInspector]
    public bool facingRight = false;
    [HideInInspector]
    public bool inAttack = false;
    [HideInInspector]
    public bool CanTurn = true;
  

    private void Awake()
    {
        goal = Patrollpoint2;
        rb = this.GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (patrolling == true && inAttack == false)
        {
            float distance = transform.position.x - goal.transform.position.x;
            
            //Only start to move when player is in range once
            Collider2D[] collider = Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), range);
            foreach(var item in collider)
            {
                if(item.gameObject.tag == "Player")
                {
                    speed = 1.5f;
                }
            }

            //turning arround
            if (distance < 0 && speed < 0)
            {
                speed *= -1;
            }
            else if (distance > 0 && speed > 0)
            {
                speed *= -1;
            }
            
            Vector2 m = new Vector2(speed, 0f) * Time.deltaTime;
            transform.Translate(m, Space.World);

            //The enemy should only be able to turn in a small distance, otherwise enemy is in spain without the a
            if (distance < 0.2 && distance > -0.2)
            {              
                if(CanTurn)
                {
                    //rb.velocity = Vector3.zero;
                    turnAround();
                    CanTurn = false;
                }
                    
            }
            else
            {
                CanTurn = true;
            }
        }

        //Debug.Log(rb.velocity);
    }

    //Turn Sprite Around
    private void turnAround()
    {
        //if (goal == Patrollpoint1) goal = Patrollpoint2;
        //else if (goal == Patrollpoint2) goal = Patrollpoint1;

        var temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
        facingRight = !facingRight;
    }

    //Enemy Takes Damage, gets knocked bacl
    public void TakeDamage(int knockback)
    {   
        //Knockback
        rb.velocity = new Vector2(knockback, 2);
    }

    //Draw Range
    private void OnDrawGizmosSelected()
    {
        if (gameObject.transform.position == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(gameObject.transform.position, range);
    }
}
