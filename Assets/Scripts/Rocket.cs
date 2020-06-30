using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    bool right = false; //Movement condition to ensure there isn't a prioritised direction when both arrow (left & right) keys are down at once
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float rotationSpeed = 250f; //Rotation speed (250f original)    
    [SerializeField] float mainThrust = 10f; //Rotation speed (10f original) 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }


    //Rocket thrust button
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))  //Boosting
        {
            rb.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying) //So the audio doesn't layer itself
            {
                audioSource.volume = 1.0f;
                audioSource.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(FadeAudioSource.StartFade(audioSource, 0.5f, 0.0f)); //Starts a coroutine to start volume fade as long as Space hasn't been presses for x amount of time otherwise the volume will reset and stop fading.
        }
    }


    //Rocket movement buttons
    private void Rotate()
    {        
        float rotationThisFrame = rotationSpeed * Time.deltaTime;   //DeltaTime added to the rotation speed

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))    //Both right and left
        {
            rb.angularVelocity = Vector3.zero;  //Stops collision rotation 
            if (right)  //Checks bool of first arrow pressed
            {
                transform.Rotate(Vector3.back * rotationThisFrame);
            }
            else
            {
                transform.Rotate(Vector3.forward * rotationThisFrame);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))  //Just right
        {
            rb.angularVelocity = Vector3.zero;  //Stops collision rotation 
            right = true;
            transform.Rotate(Vector3.back * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))  //Just left
        {
            rb.angularVelocity = Vector3.zero;  //Stops collision rotation 
            right = false;
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("ok");
                break;
            default:
                print("dead");
                break;
        }
    }

    //Stops the y rotation from changing on collisions (even though the rb rotation contraint has been set)
    private void OnCollisionStay(Collision collision)
    {
        float z = transform.eulerAngles.z;
        float x = transform.eulerAngles.x;        
        transform.rotation = Quaternion.Euler(x, 0, z);
    }
}