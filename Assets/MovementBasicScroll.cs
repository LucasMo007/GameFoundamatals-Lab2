using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementBasicScroll : MonoBehaviour
{
    public float speed = 1f;
    public float range = 18;
    public float distancetravelled = 0;
    //Vector3 StartPos;

    // Start is called before the first frame update
    private void Start()
    {
        //StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {    //how long did last frame take?at 60 fps =0.01666 两帧时间的时间间隔是0.01666。


        float DT = Time.deltaTime;

        Vector3 ForwardVector = transform.up;
        

        //move every frame by x units
        //if 60 fps ,the rock movement 1m/s *1/60s * 60 =1m

        transform.position = transform.position + ForwardVector * speed * DT;

        distancetravelled += speed * DT;

        //Vector3 Currentpos = transform.position;
        //Vector3 displacement = Currentpos - StartPos;

        //First way to destroy the object
        if (distancetravelled > range)
        {
            Destroy(gameObject);
        }

        //Second way to destroy the object using the distance between the start position and the current position
        /*if(displacement.magnitude > range )
        {
            Destroy(gameObject);
        }*/

        //third way to destroy the object :useing the world position
        /*if(transform.position.x > 10 || transform.position.x <-10)
        {
            Destroy(gameObject);
        }*/


    }
}
