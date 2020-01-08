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

    public Vector3 startPosition;
    public Quaternion startRotation;




    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
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

        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.right, Time.deltaTime * tiltSpeed);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.right, Time.deltaTime * -tiltSpeed);
        }

        checkOffRoad();
        checkOnSide();

    }

    public void checkOffRoad()
    {
        if (transform.position.y < 0)
        {
            resetPos();
        }
    }
    public void checkOnSide()
    {
        float xRot = transform.eulerAngles.x;
        Debug.Log(xRot);
        if ((xRot <= 93 && xRot >= 87) || (xRot >= 267 && xRot <= 273))
        {
            resetPos();
        }
    }

    public void resetPos()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Prop_Barrier01")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Now try it faster!");
            speed += 5;
            resetPos();
        }
    }



}
