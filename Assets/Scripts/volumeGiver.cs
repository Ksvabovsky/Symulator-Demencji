using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeGiver : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Master;
    public AudioSource Slave;

    // Update is called once per frame
    void Update()
    {
        Slave.volume=Master.volume;
    }
}
