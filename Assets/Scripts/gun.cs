using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gun : MonoBehaviour
{
    
public float speed=40;
public float speedLuska=1;

public GameObject bullet;
public Transform barrel;
public Transform wypadacz;
public AudioSource audioSource;
public AudioClip audioClip;

public float cooldown=0;
    public void FixedUpdate()
    {
        

    }
    // Start is called before the first frame update
    public void Fire()
    {

        
        GameObject spawnedBullet= Instantiate(bullet,barrel.position,barrel.rotation);
        GameObject spawnedShell= Instantiate(bullet,wypadacz.position,wypadacz.rotation);
        spawnedShell.GetComponent<Rigidbody>().velocity = speedLuska *wypadacz.right ;

        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet,2);
        Destroy(spawnedShell,5);
        
    }


}
