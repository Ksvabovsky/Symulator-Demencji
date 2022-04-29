using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class ContinousMovment : MonoBehaviour
{
    public XRNode inputSource;
public LayerMask groundLayer;
    private Vector2 inputAxis;
    private bool inputTouch;
    public float additionalHeight=0.2f;
    public float speed=1;
    public float gravity=-9.81f;
    private float fallingSpeed;
    private XRRig rig;
    private bool inputClick;


    public bool freeze=false;
    private CharacterController character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig= GetComponent<XRRig>();
    }
    
    public void FreezeT()
        {
           freeze=true;
        }
          public void FreezeF()
        {
           freeze=false;
        }
    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        device.TryGetFeatureValue(CommonUsages.primary2DAxisTouch,out inputTouch);
        device.TryGetFeatureValue(CommonUsages.primary2DAxisClick,out inputClick);
       
        if(freeze==false)
        {
             if(inputClick)
        {
            speed=6;
        }else
            speed=3;
        }else
        speed=0;

            
    }
    private void FixedUpdate()
    {
        capsuleFollowHeadset();
        if(inputTouch==true)
        {
            Quaternion headYaw = Quaternion.Euler(0,rig.cameraGameObject.transform.eulerAngles.y,0);
            Vector3 direction = headYaw * new Vector3(inputAxis.x,0,inputAxis.y);
            character.Move(direction*Time.fixedDeltaTime*speed);
            
            
        }
        bool isGrounded=ChceckIfGrounded();
            if(isGrounded)
            {
                fallingSpeed=0;
            }else
            {
                fallingSpeed+=gravity*Time.fixedDeltaTime;
                character.Move(Vector3.up*fallingSpeed*Time.fixedDeltaTime);
            }
        void capsuleFollowHeadset()
        {
            character.height=rig.cameraInRigSpaceHeight + additionalHeight;
            Vector3 capsulecenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
            character.center=new Vector3(capsulecenter.x,character.height/2+character.skinWidth,capsulecenter.z);
        }
        bool ChceckIfGrounded()
        {
            Vector3 rayStart =transform.TransformPoint(character.center);
            float rayLength = character.center.y + 0.01f;
            bool hasHit = Physics.SphereCast(rayStart,character.radius, Vector3.down,out RaycastHit hitInfo ,rayLength,groundLayer);
            return hasHit;
        }
        
    }
    public void stop()
    {
        {
            fallingSpeed=0;
        }
    }
}
