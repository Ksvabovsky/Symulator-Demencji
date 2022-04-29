using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject button;
    public LightSwitch targetlight;
    public AudioClip switchsound;
    public AudioSource switchsource;

    // Start is called before the first frame update
    void Start()
    {
        if(targetlight.isActive == true){
            button.transform.Rotate(6f,0,0);
        }else{
            button.transform.Rotate(-6f,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void MoveButton()
    {
        if(targetlight.isActive == true)
        {
            button.transform.Rotate(12f,0,0);
            
        }
        else
        {
            button.transform.Rotate(-12f,0,0);
        }
        switchsource.PlayOneShot(switchsound);
        Debug.Log("y:" + button.transform.rotation.y + " z:" + button.transform.rotation.z);
    }
}
