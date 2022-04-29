using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class locomotionController : MonoBehaviour
{
    public XRController lTpRay;
    public XRController rTpRay;
    public InputHelpers.Button tpActButton;
    public float actThreshold=0.1f;

    public bool enableRightController{get;set;}=true;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    { 
        
        if(lTpRay)
        {
            lTpRay.gameObject.SetActive(CheckIfActivated(lTpRay)); 
        }
        if(rTpRay&&enableRightController)
        {
            rTpRay.gameObject.SetActive(CheckIfActivated(rTpRay)); 
        }else
        rTpRay.gameObject.SetActive(false);
    }
    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice,tpActButton,out bool isActivated,actThreshold);
        return isActivated;
    }
}
