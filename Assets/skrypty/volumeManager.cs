using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeManager : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] Slider volumeSlider; 
    public AudioSource muza;
    public void volume()
    {
        muza.volume=volumeSlider.value;
    }
}
