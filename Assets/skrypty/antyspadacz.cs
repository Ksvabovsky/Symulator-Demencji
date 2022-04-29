using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antyspadacz : MonoBehaviour
{
    public GameObject canvas;
    private sciemnaj scm;
    // Start is called before the first frame update
    void Start()
    {
        scm=canvas.GetComponent<sciemnaj>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-0.3&&transform.position.y>-0.4)
        {
            scm.ciemno();

        }
         if(this.transform.position.y<-10)
        {
            scm.jasno();
            this.transform.position=new Vector3(transform.position.x,0.5f,transform.position.z);
            ContinousMovment obiekt = GetComponent<ContinousMovment>();
            obiekt.stop();
        }
    }
}
