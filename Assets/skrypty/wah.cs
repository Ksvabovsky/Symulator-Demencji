using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class wah : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
     private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();     
    }
    
        
    

}
