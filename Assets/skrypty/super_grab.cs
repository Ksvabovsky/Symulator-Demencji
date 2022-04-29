using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class super_grab : XRGrabInteractable
{
    private int countdown = 0;
    public GameObject obiektTP;
    private Rigidbody body;
    private Rigidbody bodyTp;

    LayerMask mask;
    // Start is called before the first frame update

    void Start()
    {
       body = GetComponent<Rigidbody>();
     bodyTp = obiektTP.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if(countdown!=0)
        {
            
            countdown--;
            if (countdown == 0)
            {
                interactionLayerMask = mask;

            }
        }
        if(Vector3.Distance(obiektTP.transform.position,transform.position)>0.4f)
        {
            pusc();
            tepuje();
        }
    }
    public void pusc()
    {
        mask = interactionLayerMask;
        interactionLayerMask = 0;
        countdown = 60;
    }
    public void tepuje()
    {
        transform.rotation = obiektTP.transform.rotation;
        transform.position = obiektTP.transform.position;
        transform.localScale = new Vector3(1f, 1f, 1f); ;


        
          body.velocity = new Vector3(0, 0, 0);
          body.angularVelocity = Vector3.zero;
      bodyTp.velocity = new Vector3(0, 0, 0);
          bodyTp.angularVelocity = Vector3.zero;
         transform.localScale = new Vector3(1f, 1f, 1f); ;

    }
 

}