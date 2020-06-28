using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    bool right = false; //
    Rigidbody rb;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    //Rocket movement buttons
    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space)) //Both right and left down while boosting
        {
            if (right)  //Checks bool of first arrow pressed
            {
                print("Rotating right with thrust");
            }
            else
            {
                print("Rotating left with thrust");
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.Space))   //Both right and left down while NOT boosting
        {
            if (right)  //Checks bool of first arrow pressed
            {
                print("Rotating right");
            }
            else
            {
                print("Rotating left");
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space))   //Right down while boosting
        {
            right = true;            
            print("Rotating right with thrust");
        }
        else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space))   //Left down while boosting
        {
            right = false;            
            print("Rotating left with thrust");
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.Space))  //Right down
        {
            right = true;            
            print("Rotating right");
        }
        else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.Space))  //Left down
        {
            right = false;            
            print("Rotating left");
            //rb.AddRelativeForce
        }        
        else if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space))  //Boosting
        {
            print("Thrusting");
            rb.AddRelativeForce(Vector3.up);
        }
    }
}
