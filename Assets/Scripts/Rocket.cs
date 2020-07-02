using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    bool right = false; //Movement condition to ensure there isn't a prioritised direction when both arrow (left & right) keys are down at once
    Rigidbody rb;

    AudioSource audioSourceEngine;
    AudioSource audioSourceSuccess;
    AudioSource audioSourceDeath;


    [SerializeField] float rotationSpeed = 250f; //Rotation speed (250f original)    
    [SerializeField] float mainThrust = 10f; //Rotation speed (10f original)
    
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;


    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //--audio sources needed:
        audioSourceEngine = gameObject.AddComponent<AudioSource>();
        audioSourceEngine.clip = mainEngine;
        audioSourceSuccess = gameObject.AddComponent<AudioSource>();
        audioSourceSuccess.clip = success;
        audioSourceSuccess.volume = 0.3f;
        audioSourceDeath = gameObject.AddComponent<AudioSource>();
        audioSourceDeath.clip = death;
        audioSourceDeath.volume = 0.2f;
    }


    // Update is called once per frame
    void Update()
    {
        if (state == State.Transcending)    //changing level
        {
            rb.angularVelocity = Vector3.zero;  //less likely to die while scene is changing
            audioSourceEngine.Stop();
            mainEngineParticles.Stop();
        }
        else if (state == State.Alive)  //still playing
        {            
            RespondToThrustInput();
            RespondToRotateInput();
        }
        else     //died
        {
            audioSourceEngine.Stop();
        }
    }


    //Rocket thrust button
    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))  //Boosting
        {
            ApplyThrust();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(FadeAudioSource.StartFade(audioSourceEngine, 0.5f, 0.0f)); //Starts a coroutine to start volume fade as long as Space hasn't been presses for x amount of time otherwise the volume will reset and stop fading.
            if (mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Stop();
            }
        }
    }

    private void ApplyThrust()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust);
        if (!audioSourceEngine.isPlaying) //So the audio doesn't layer itself
        {
            audioSourceEngine.volume = 1.0f;
            audioSourceEngine.Play();
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }


    //Rocket movement buttons
    private void RespondToRotateInput()
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
        if (state != State.Alive) { return; }   //ignore collisions when dead

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //do nothing
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:                    //CHANGE THIS TO REDUCE THE HEALTH SLIDER
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSourceSuccess.Play();
        successParticles.Play();
        Invoke("LoadNextScene", 1f);        
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        audioSourceDeath.Play();
        Invoke("Dying", 1f);
        if (mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Stop();
        }
        deathParticles.Play();
    }

    private void Dying()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Stops the y rotation from changing on collisions (even though the rb rotation contraint has been set)
    private void OnCollisionStay(Collision collision)
    {  
        float z = transform.eulerAngles.z;
        float x = transform.eulerAngles.x;        
        transform.rotation = Quaternion.Euler(x, 0, z);
    }
}