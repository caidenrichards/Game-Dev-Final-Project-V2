using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBikeControl : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed;
    public float wheelieSpeed = .8f;
    public float tiltSpeed = .8f;

    public float horizontalInput;
    public float verticalInput;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move vehicle forward
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(verticalInput >= 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * 1 * -1);
            //transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput * -1);
        }
        
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput * 1);
        transform.Rotate(Vector3.forward, Time.deltaTime * horizontalInput * tiltSpeed);

        //if (Input.GetKey("a"))
        //{
        //    transform.position = transform.position + turnSpeed;
        //}

        //if (Input.GetKey("w"))
        //{
        //    transform.Rotate(Vector3.forward * Time.deltaTime * wheelieSpeed);
        //}
        //else
        //{
        //    if(transform.position.z > 0)
        //    {
        //        transform.Rotate(Vector3.forward, Time.deltaTime * -wheelieSpeed);
        //    }
        //}
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.right, Time.deltaTime * tiltSpeed);
        }
        else
        {
            //if (transform.position.x > 0)
            //{
            //    transform.Rotate(Vector3.right, Time.deltaTime * -wheelieSpeed);
            //}
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.right, Time.deltaTime * -tiltSpeed);
        }
        else
        {
            //if (transform.position.x > 0)
            //{
            //    transform.Rotate(Vector3.right, Time.deltaTime * -wheelieSpeed);
            //}
        }
    }
}
