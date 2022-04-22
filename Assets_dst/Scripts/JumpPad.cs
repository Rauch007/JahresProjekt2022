using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float force;
    Collider2D col;

    private void Awake()
    {
        col = playerRB.GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      
           if (collision.gameObject.tag == "Player")
           {
                Debug.Log("JumpPad");
                playerRB.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
           }       
    }
}
