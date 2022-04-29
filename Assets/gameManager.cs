using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    //<------ regiony sie rozwija z tamtej strony, tak jak klamry
        #region klasy

    [System.Serializable]
    public class GameTime
    {
    public int hour=0;
    public int minute=0;
    public float second=0;
    }
    public enum SpawnOption{
        SpawnStart,
        SpawnSalon
    };

        #endregion

        #region zmienne

    [Header("Time")]
    public float hour;
    public float minute;
    public float second;
    [Header("Game Time")]
    public GameTime GT;

    [Header("Spawn")]
    public GameObject SpawnSalon;
    public GameObject SpawnStart;
    public SpawnOption SpawnPoint;

    [Header("Script")]
    public bool Paczka1;

    string HourS,MinS,SecS;

        #endregion

    void Awake()
    {
        hour = hour % 12;
        minute = minute % 60;
        second = second % 60;
    }

    void FixedUpdate()
    {
            #region czas
        second += Time.deltaTime;
        if(second>=60)
            {
                minute++;
                second=0;
            }
        if(minute>=60)
        {
            hour++;
            minute=0;
        }
        if(hour>=24)
        {
            hour=0;
        }

        GT.second += Time.deltaTime;
        if(GT.second>=60)
        {
            GT.minute++;
            GT.second=0;
        }
        if(GT.minute>=60)
        {
            GT.hour++;
            GT.minute=0;
        }
        
                #region Czas Gry|Debug
                
            HourS = GT.hour.ToString();

            if(GT.minute<10){
            MinS = "0" + GT.minute.ToString();
            }
            else{
            MinS = GT.minute.ToString();
            }

            if(GT.second<10f){
            SecS = "0" + Mathf.Round(GT.second).ToString();
            }
            else{
            SecS = Mathf.Round(GT.second).ToString();
            }
            
            //Debug.Log(HourS + ":"+ MinS + ":" + SecS);

                #endregion

            #endregion
    }
    public void Paczka1Odebrana()
    {
        Paczka1=true;
    } 
}
