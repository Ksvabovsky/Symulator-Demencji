using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;

public class LightSwitch : MonoBehaviour
{
    //public GameObject lightParent;
    public bool isActive;
    private BoxCollider switchCollider;
    private int cooldown;
    public List<GameObject> lights = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //isActive = true;
        Debug.Log("The light is now " + isActive);
        switchCollider = GetComponent<BoxCollider>();
    }

    public void Update()
    {
        
    }

    // Update is called once per frame
    public void changeLight()
    {
        isActive = !isActive;
        Debug.Log("Nice click, the light is now " + isActive);
        foreach (GameObject l in lights) {
            l.SetActive(isActive);
        }
    }
}
