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
    [SerializeField] private float speed;

    private GameObject goal;
    private Rigidbody2D rb;
    [HideInInspector]
    public bool facingRight = false;
    [HideInInspector]
    public bool inAttack = false;

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
            if (distance < 0 && speed < 0)
            {
                speed *= -1;
            }
            else if (distance > 0 && speed > 0)
            {
                speed *= -1;
            }

            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (distance < 0.2 && distance > -0.2)
            {
                rb.velocity = Vector3.zero;
                turnAround();
            }        
        }
    }

    private void turnAround()
    {
        if (goal == Patrollpoint1) goal = Patrollpoint2;
        else if (goal == Patrollpoint2) goal = Patrollpoint1;

        var temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
        facingRight = !facingRight;
    }
}
