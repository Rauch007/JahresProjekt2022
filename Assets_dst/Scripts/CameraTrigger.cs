using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera cam;
    public GameObject point;
    Vector2 center;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(center);
        Debug.Log("Passed Trigger");
        //GameEvents.current.CameraTrigger();
             
        center = point.transform.position;
        
        cam.transform.position = new Vector2(0, 0);
        cam.transform.Translate(center);
        Debug.Log(cam.transform.position);       
    }
}
