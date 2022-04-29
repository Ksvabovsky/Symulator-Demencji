using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Climber : MonoBehaviour
{
private CharacterController character;
public static XRController climbingHand;
private ContinousMovment continousMovment;
    void Start()
    {
        character=GetComponent<CharacterController>();
        continousMovment = GetComponent<ContinousMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        if(climbingHand)
        {
            continousMovment.enabled = false;
            Climb();
        }
        else
        {
            continousMovment.enabled=true;
        }
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        character.Move(transform.rotation * -velocity*Time.fixedDeltaTime);
    }
}
