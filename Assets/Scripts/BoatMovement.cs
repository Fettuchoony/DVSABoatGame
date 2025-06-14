using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

 public ParticleSystem motorSpray;
 public GameObject mesh;
 public GameObject canvas;
 public Rigidbody rb;
 public float speed = 0; 
 public float maxSpeed = 10;
 public float drag = 0.97f;

private float boatMovementVector;
private float boatRotationVector;
private Keyboard curKeyboard = Keyboard.current;
 private bool isPaused = false;
 private float frequencyIncrement = 0;
 private PlayerInventory pInventory;

 private float lastPause;
    void Start(){
        rb = GetComponent<Rigidbody>();
        canvas.SetActive(false);
        pInventory = GetComponent<PlayerInventory>();
    }

    // void Update(){
    //     Scene scene = SceneManager.GetActiveScene();
    //     if(!isPaused && scene.name.Equals("MainGame")){
    //         if(curKeyboard.wKey.isPressed){
    //             float currVelocity = MathF.Sqrt(Mathf.Pow(rb.linearVelocity.x,2)+Mathf.Pow(rb.linearVelocity.z,2));
    //             if(currVelocity <= maxSpeed){
    //                 rb.AddForce(transform.forward * speed);
    //             }
    //         }else if(curKeyboard.sKey.isPressed){
    //             rb.AddForce(0.5f*transform.forward*-speed/4);
    //         }
    //         if(curKeyboard.aKey.isPressed){
    //             transform.eulerAngles += Vector3.down;
    //         }
    //         if(curKeyboard.dKey.isPressed){
    //             transform.eulerAngles += Vector3.up;
    //         }
    //     }
    //     if(curKeyboard.escapeKey.isPressed && (Time.realtimeSinceStartup - lastPause > 0.2f)){
    //         lastPause = Time.realtimeSinceStartup;
    //         escapeMenu();
    //     }
    // }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        boatRotationVector = movementVector.x;
        boatMovementVector = movementVector.y;    
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }
    private void FixedUpdate()
    {
        // return;
        if (motorSpray != null)
        {
            float x = rb.linearVelocity.x;
            float z = rb.linearVelocity.z;
            var emission = motorSpray.emission;
            emission.rate = Mathf.Sqrt(x * x + z * z);
        }
        // motorSpray.transform.position = propeller.position;
        // motorSpray.transform.rotation = propeller.rotation;

        //For the player input part of the boat
        Scene scene = SceneManager.GetActiveScene();
        if (!isPaused && scene.name.Equals("MainGame"))
        {
            float currVelocity = MathF.Sqrt(Mathf.Pow(rb.linearVelocity.x, 2) + Mathf.Pow(rb.linearVelocity.z, 2));
            if (currVelocity <= maxSpeed)
            {
                rb.AddForce(transform.forward * boatMovementVector * speed);
            }
            transform.eulerAngles += Vector3.up * boatRotationVector;
        }




        //For the wave simulation of the boat.
        float frequencyIncrementIncrement = Mathf.Sqrt(rb.linearVelocity.x * rb.linearVelocity.x + rb.linearVelocity.z * rb.linearVelocity.z) / 10f;
        frequencyIncrement += Mathf.Clamp(frequencyIncrementIncrement, 0.5f, 10f);

        rb.linearVelocity = drag * rb.linearVelocity;
        //5.5*sin(x/100*pi)+4.5
        Vector3 newZRotation = Vector3.back * (5.5f * Mathf.Sin((frequencyIncrement - 30.50178f) / 100 * Mathf.PI) + 4.5f);
        Vector3 newYRotation = Vector3.up * (transform.eulerAngles.y + 90);
        mesh.transform.eulerAngles = newZRotation + newYRotation;
    }

    public void onResume(){
        if(Time.realtimeSinceStartup-lastPause > 0.5f){
            lastPause = Time.realtimeSinceStartup;
            escapeMenu();
        }
    }

    public void onMainMenu(){
        Time.timeScale = 1;
        isPaused = false;
        canvas.SetActive(false);
        SceneManager.LoadScene(1);
    }
    private void escapeMenu(){
        if(isPaused){
            Time.timeScale = 1;
        }else{
            Time.timeScale = 0;
        }
        isPaused = !isPaused;
        canvas.SetActive(isPaused);
    }
}