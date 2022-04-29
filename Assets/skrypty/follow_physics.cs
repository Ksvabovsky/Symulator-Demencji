using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_physics : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    public bool czy = false;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

   public void podozaj()
    {
        czy = true;
    }
    public void niePodozaj()
    {
        czy = false;
    }
    void FixedUpdate()
    {
        if(czy)
            rb.MovePosition(target.transform.position);
    }
}
