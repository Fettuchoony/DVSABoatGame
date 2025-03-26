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
 public float speed = 0; 
 public float maxSpeed = 10;
 public float drag = 0f;
 
 private Keyboard curKeyboard = Keyboard.current;
 private Rigidbody rb;
 private bool isPaused = false;
 private bool isMoving = false;
 private float frequencyIncrement = 0;

 private float lastPause;
    void Start(){
        rb = GetComponent<Rigidbody>();
        canvas.SetActive(false);
    }

    void Update(){
        if(!isPaused){
            if(curKeyboard.wKey.isPressed){
                isMoving = true;
                if(Mathf.Pow(rb.linearVelocity.x,2f)+Mathf.Pow(rb.linearVelocity.z,2f) <= Mathf.Pow(maxSpeed,2)){
                    rb.AddForce(1 * transform.forward * speed);
                }
            }else if(curKeyboard.sKey.isPressed){
                rb.AddForce(0.5f*transform.forward*-speed/4);
                isMoving = false;
            }else{
                isMoving = false;
            }
            if(curKeyboard.aKey.isPressed){
                transform.eulerAngles += Vector3.down;
            }
            if(curKeyboard.dKey.isPressed){
                transform.eulerAngles += Vector3.up;
            }
        }
        if(curKeyboard.escapeKey.isPressed && (Time.realtimeSinceStartup - lastPause > 0.2f)){
            lastPause = Time.realtimeSinceStartup;
            escapeMenu();
        }
     
    }
    private void FixedUpdate(){
        if (motorSpray != null) {
            float x = rb.linearVelocity.x;
            float z = rb.linearVelocity.z;
            var emission = motorSpray.emission;
            emission.rate = Mathf.Sqrt(x*x + z*z);
        // motorSpray.transform.position = propeller.position;
        // motorSpray.transform.rotation = propeller.rotation;
        if(isMoving){
            frequencyIncrement = MathF.Round(frequencyIncrement);
            frequencyIncrement += 1f;
        }else{
            frequencyIncrement -= 0.75f;
        }
        rb.linearVelocity =  drag*rb.linearVelocity;
        Vector3 newXRotation = Vector3.left * (5.5f*Mathf.Sin((frequencyIncrement-30.5f)/100*Mathf.PI)+4.5f);
        Vector3 newYRotation = Vector3.up * transform.eulerAngles.y;
        mesh.transform.eulerAngles = newXRotation + newYRotation;
        // if(isMoving){
        //     frequencyIncrement += 1;
        //     Vector3 newXRotation = Vector3.left * (6*Mathf.Sin(frequencyIncrement/100*Mathf.PI)+4);
        //     Vector3 newYRotation = Vector3.up * transform.eulerAngles.y;
        //     transform.eulerAngles = newXRotation + newYRotation;
        //     // if(frequencyIncrement >= 110){
        //     //     frequencyIncrement = 0;
        //     // }
        // }else{
        //     if(frequencyIncrement != 0 && frequencyIncrement != 110){
        //         frequencyIncrement -= 0.75f;
        //         Vector3 newXRotation = Vector3.left * (6*Mathf.Sin(frequencyIncrement/100*Mathf.PI)+4);
        //         Vector3 newYRotation = Vector3.up * transform.eulerAngles.y;
        //         transform.eulerAngles = newXRotation+newYRotation;
        //     }
        }
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