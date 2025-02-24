using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{       public GameObject projectileprefab;
        public bool istriggeredown;
        public float timeuntilreloaded;
        public float firerate =1;// shots every second



    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetButton ("shoot")) ;
        Instantiate(projectileprefab,transform.position,transform.rotation);*/
      
            istriggeredown = Input.GetButton ("shoot");

        if (istriggeredown && timeuntilreloaded <= 0)
        {
            Instantiate(projectileprefab, transform.position, transform.rotation);
            float secondsPerShot = 1 / firerate;
            timeuntilreloaded = secondsPerShot;
        }

        timeuntilreloaded -= Time.deltaTime;
        /*if(timeuntilreloaded <= 0)
        {
            timeuntilreloaded = 0;
        }*/


    }
}
