using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementBasicScroll : MonoBehaviour
{
    public float speed = 1f;
    public float range = 18;

    Vector3 StartPos;

    // Start is called before the first frame update
    private void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {    //how long did last frame take?at 60 fps =0.01666 ?????????
        float DT = Time.deltaTime;
        //move every frame by x units
        //if 60 fps ,the rock movement 1m/s *1/60s * 60 =1m
        transform.position = transform.position+new Vector3(speed, 0,0)*DT;

        Vector3 Currentpos = transform.position;
        Vector3 displacement = Currentpos - StartPos;

        if(displacement.magnitude > range )
        {
            Destroy(gameObject);
        }
        /*if(transform.position.x > 10 || transform.position.x <-10)
        {
            Destroy(gameObject);
        }*/


    }
}
