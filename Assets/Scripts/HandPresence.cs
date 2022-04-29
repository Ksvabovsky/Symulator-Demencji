using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private Animator handAnimator;
    public bool showController = false;
    public GameObject handModelPrefab;
    public GameObject spawnedHandModel;
    public InputDeviceCharacteristics controllerCharacteristics;
    private GameObject spawnedController;
    private InputDevice TargetDevice;
    public List<GameObject> controllerPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        TryInitialiaze();
        
    }
    void TryInitialiaze()
    {
List<InputDevice> devices = new List<InputDevice>();
       
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics,devices);
        
        foreach(var item in devices)
        {
           Debug.Log(item.name); 
        } 
        if(devices.Count > 0)
        {
            TargetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == TargetDevice.name);
        if(prefab)
        {
            spawnedController = Instantiate(prefab,transform);
            Debug.Log("dziala");
        }else
        {
            Debug.Log("Nie ma pasujace kontrollera");
            spawnedController = Instantiate(controllerPrefabs[0],transform);
        }
        spawnedHandModel = Instantiate(handModelPrefab,transform);
        handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }
    void UpdateHandAnimation ()
    {
        if(TargetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger",triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger",0);
        }
        if(TargetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip",gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip",0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!TargetDevice.isValid)
        {
            TryInitialiaze();
        }
        if(showController)
        {
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true);
        }
        else
        {
            spawnedHandModel.SetActive(true);
            spawnedController.SetActive(false);
            UpdateHandAnimation();
        }   
        }
            
    }

