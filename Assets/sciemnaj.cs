using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sciemnaj : MonoBehaviour
{
    private Image ekran;
    private int counter;
    private int tryb=0;

    void Start()
    {

        ekran=GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if(tryb!=0)
        {
            counter=counter+tryb*2;
        }

        if(counter==0||counter==100)
            tryb=0;
       // if(tryb!=0)
        ekran.color= new Color(0,0,0,(float)counter/100);
    }
    public void ciemno()
    {
        //counter=0;
        tryb=1;
    }
    public void jasno()
    {
        //counter=100;
        tryb=-1;
    }
}
