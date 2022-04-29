using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb3d;
    // Start is called before the first frame update
    void Start()
    {
        rb3d = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb3d != null && rb3d.IsSleeping()) {
            rb3d.WakeUp();
        }
    }
}
