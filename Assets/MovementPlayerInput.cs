using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementPlayerInput : MonoBehaviour
{
    public float speed = 5.0f;

    public Vector3 inputvector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float XInput = Input.GetAxisRaw("Horizontal");
        float YInput = Input.GetAxisRaw("Vertical");
        float DT= Time.deltaTime;
        inputvector = new Vector3 (XInput, YInput, 0);
        //if W is held alone,this vector will be (0,1,0),
        //for a velocity of (0,speed,0)
        //if W and D are held ,this vector will be(1, 1, 0),
        //for a velocity of(speed, speed, 0)
        if (inputvector.x == 0 && inputvector.y == 0)
        {

        }
        else
        {
            inputvector = inputvector / inputvector.magnitude;
        }
        //Debug.Log(inputvector.magnitude);
        transform.position = transform.position + inputvector * speed * DT;
    }
}
