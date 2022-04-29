using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class RadioScript : MonoBehaviour
{
    //<------ regiony sie rozwija z tamtej strony, tak jak klamry
        #region klasy
        
    [System.Serializable]
    public class Time
    {
    public float hour;
    public float minute;
    }

    [System.Serializable]
    public class screenController
    {
        public Color colorOn = new Color(153, 255, 204);
        public Color colorOff = new Color(0, 0, 0);
    }

    [System.Serializable]
    public class soundController
    {
        public bool isVolume = false;
        public bool OnOff;
        public GameObject frequencyRotor;
        public AudioSource metin;
        public int trzy;
        public Quaternion startingRotation;
    }

    [System.Serializable]
    public class frequencyController
    {
        public bool isFrequency = false;
        public int frequency = 100;
        public Quaternion startingRotation;

        public GameObject frequencyRotor;
    }

        #endregion
    
        #region zmienne
    gameManager GM;
    public XRDirectInteractor LHand;
    public XRDirectInteractor RHand;
    public static XRDirectInteractor activeHand;
    public GameObject button;
    public GameObject screen;
    public TMP_Text clockText;

    string s;
    private Renderer screenRenderer;
    public Time time;
    public screenController Screen;
    public soundController Sound;
    public frequencyController Frequency;

    public float diff;
    public Quaternion lastRotation;
    public Quaternion angleDiff;
    Vector4 colorEmOff;
    Vector4 colorEmOn;
    
        #endregion

    void Start()
    {   
            #region czas z game managera

        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();
        time.hour = GM.hour;
        time.minute = GM.minute;

            #endregion

            #region kolor ekranu

        screenRenderer = screen.GetComponent<MeshRenderer>();
        colorEmOff = new Vector4(Screen.colorOff.r/255f, Screen.colorOff.g/255f, Screen.colorOff.b/255f, 0);
        colorEmOn = new Vector4(Screen.colorOn.r/255f, Screen.colorOn.g/255f, Screen.colorOn.b/255f, 0);
        screenRenderer.material.SetVector("_EmissionColor", colorEmOff);
        Sound.OnOff = false;

            #endregion
        activeHand = null;
    }

    void FixedUpdate()
    {
        if(Frequency.isFrequency) {
            //angleDiff = activeHand.transform.localRotation * Quaternion.Inverse(lastRotation);
            //Frequency.frequencyRotor.transform.Rotate(angleDiff.x*100f,0.0f,0.0f);
            diff = activeHand.transform.rotation.x - lastRotation.x;
            Frequency.frequencyRotor.transform.Rotate(diff,0.0f,0.0f);
            lastRotation = activeHand.transform.localRotation;
        }
        if(Sound.isVolume) {
            lastRotation = activeHand.transform.rotation;
        }
    }

    public void controlRadio()
    {
        Sound.OnOff = !Sound.OnOff;
        if (Sound.OnOff == true)
        {
            Sound.metin.Play();
            Debug.Log("Turn em on");
            screenRenderer.material.SetVector("_EmissionColor", colorEmOn);
        }
        else
        {
            Sound.metin.Stop();
            Debug.Log("Turn em off");
            screenRenderer.material.SetColor("_EmissionColor", colorEmOff);
        }
    }


    XRDirectInteractor getHand(string tag) {
        if(LHand.selectTarget) {
            if(LHand.selectTarget.tag == tag) {
                return LHand;
            } else {
                return null;
            }
        } else if(RHand.selectTarget) {
            if(RHand.selectTarget.tag == tag) {
                return RHand;
            } else {
                return null;
            }
        } else {
            return null;
        }
    }

    public void controlFrequency()
    {
        Debug.Log("Frequency Grabbed");
        Frequency.isFrequency = true;
        activeHand = getHand("FreqRotor");
        lastRotation = activeHand.transform.rotation;
    }

    public void controlFrequencyExit(){
        Debug.Log("Frequency Dropped");
        Frequency.isFrequency = false;
        activeHand = null;
    }

    public void controlVolume(){
        Debug.Log("Volume Grabbed");
        Sound.isVolume = true;
        activeHand = getHand("VolumeRotor");
        lastRotation = activeHand.transform.rotation;
    }

    public void controlVolumeExit(){
        Debug.Log("Volume Dropped");
        Sound.isVolume = false;
        activeHand = null;
    }

    void Update(){

            #region zmiana czasu na wyswietlaczu

        time.hour = GM.hour;
        time.minute = GM.minute;
        if (time.minute <10){
            s = "0"+ time.minute.ToString();
        }
        else{
            s = time.minute.ToString();
        }
        clockText.text = time.hour.ToString() +":"+ s;

            #endregion
    }
}
