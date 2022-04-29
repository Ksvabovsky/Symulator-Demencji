using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    //<------ regiony sie rozwija z tamtej strony, tak jak klamry
        #region zmienne
    gameManager GM;

    public float hour;
    public float minute;
    public float second;

    public GameObject hourpointer;
    public GameObject minpointer;
    public GameObject secpointer;

        #endregion

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();

        hour = GM.hour;
        minute = GM.minute;
        second = GM.second;

        secpointer.transform.Rotate(0f,0f,second * 6f);
        minpointer.transform.Rotate(0f,0f,minute * 6f + second * 0.1f);
        hourpointer.transform.Rotate(0f,0f,hour *30f  + minute *0.5f + second/120f);
    }

    void FixedUpdate()
    {
        secpointer.transform.Rotate(0f,0f,6f * Time.deltaTime );
        minpointer.transform.Rotate(0f,0f,6f * Time.deltaTime / 60f);
        hourpointer.transform.Rotate(0f,0f,6f * Time.deltaTime / 60f /12f);
        second += Time.deltaTime;

        if(second>= 60f){
            second = second % 60f;
            minute++;
        }
        if (minute >=60f){
            minute = minute % 60f;
            hour++;
        }
        if (hour >= 12){
            hour = hour % 12;
        }

    }
}
