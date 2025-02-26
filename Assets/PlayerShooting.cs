using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectileprefab;
    public bool istriggeredown;
    public float timeuntilreloaded = 0;
    public float firerate = 3;// shots every second

    public ShootModes shootMode = ShootModes.Basic;

    //public GameObject spreadPowerup;

    public enum ShootModes
    {
        Basic = 0,
        Spread,
        Rapid
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
      
             powerUp powerup = collision.GetComponent<powerUp>();// GetComonet is a function that will return the component of the type I selected
                                                                 // powerup is a name ,it is vatiety :when the player collides with the things,
                                                                 // it will get the powerup component

        if (powerup != null) //if the player get the powerup component

        {
               shootMode = powerup.powerupShootMode;// the shootmode of player will be the powerupshootmode I selected in Unity.

               Destroy(collision.gameObject);
            }
      
    }

/*if(timeuntilreloaded <= 0)
{
    timeuntilreloaded = 0;
}*/


// Update is called once per frame
void Update()
{

        // 
        // test distance between player and powerup ,then destory the bullet far tha 0.5 meter

        /*Vector3 PowerupPos = spreadPowerup.transform.position ;
        Vector3 PlayerPos = transform.position;

        float distance = Vector3.Distance(PlayerPos,PowerupPos);

        if (distance < 0.5f)
        {
            // we touched the powerup
            // do something
            shootMode = ShootModes.Spread;
            Destroy(spreadPowerup);
            spreadPowerup = null;
        }
        */




        /* if (Input.GetButton ("shoot")) ;
         Instantiate(projectileprefab,transform.position,transform.rotation);*/

        istriggeredown = Input.GetButton("shoot");

    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
            shootMode = ShootModes.Basic;
    }
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
            shootMode = ShootModes.Spread;
    }
    if (Input.GetKeyDown(KeyCode.Alpha3))
    {
            shootMode = ShootModes.Rapid;
    }


    if (shootMode == ShootModes.Basic)
    {
            BasicShootingBehaviour();
    }
    else if (shootMode == ShootModes.Spread)
    {
            SpreadShootingBehaviour();
    }
    else if (shootMode == ShootModes.Rapid)
    {
            RapidShootingBehaviour();
    }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    ShootingMode = 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    ShootingMode = 2;
        //}

        //if (ShootingMode == 1)
        //{
        //    BasicShootingBehaviour();
        //}
        //else if (ShootingMode == 2)
        //{
        //    SpreadShootingBehaviour();
        //}


    }
    void RapidShootingBehaviour()
    {
        if (istriggeredown && timeuntilreloaded <= 0)
        {
            Instantiate(projectileprefab, transform.position, transform.rotation);
            float secondsPerShot = 1 / firerate/5;
            timeuntilreloaded = secondsPerShot;
        }
        timeuntilreloaded -= Time.deltaTime;
        if (timeuntilreloaded <= 0)
        {
            timeuntilreloaded = 0;
        }
    }
    void BasicShootingBehaviour()
    {
        if (istriggeredown && timeuntilreloaded <= 0)
        {
            Instantiate(projectileprefab, transform.position, transform.rotation);
            float secondsPerShot = 1 / firerate;
            timeuntilreloaded = secondsPerShot;
        }
        timeuntilreloaded -= Time.deltaTime;
        if (timeuntilreloaded <= 0)
        {
            timeuntilreloaded = 0;
        }
    }
    void SpreadShootingBehaviour ()
    {
        if (istriggeredown && timeuntilreloaded <= 0)
        {
            Instantiate(projectileprefab, transform.position, transform.rotation);
            Instantiate(projectileprefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 10));
            Instantiate(projectileprefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, -10));
            float secondsPerShot = 1 / firerate;
            timeuntilreloaded = secondsPerShot;
        }
        timeuntilreloaded -= Time.deltaTime;
        if (timeuntilreloaded <= 0)
        {
            timeuntilreloaded = 0;
        }
    }
}
