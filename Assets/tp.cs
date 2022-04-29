using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class tp : MonoBehaviour
{
    public GameObject obiekt;
    // Start is called before the first frame update
    public void tepujNieDoTegoObiektu() 
      {
          transform.position=obiekt.transform.position;
          //transform.rotation=new Quaternion(0,90,0,0);
      }
      public void tepujDoTegoObiektu()
      {
          obiekt.transform.position=transform.position;
      }
  

}
