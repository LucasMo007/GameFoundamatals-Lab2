using System.Collections;
using System.Collections.Generic;
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
        float XInput = Input.GetAxis("Horizontal");
        float YInput = Input.GetAxis("Vertical");
        float DT= Time.deltaTime;
        inputvector = new Vector3(XInput, YInput, 0);
        
        transform.position = transform.position + inputvector * DT;
    }
}
