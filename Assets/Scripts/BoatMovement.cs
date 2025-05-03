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
 public float drag = 0f;

 private Keyboard curKeyboard = Keyboard.current;
 private bool isPaused = false;
 private float frequencyIncrement = 0;
 private PlayerInventory pInventory;

 private float lastPause;
    void Start(){
        rb = GetComponent<Rigidbody>();
        canvas.SetActive(false);
        pInventory = GetComponent<PlayerInventory>();
        rb.maxLinearVelocity = 10f;
    }

    void Update(){
        if(!isPaused){
            if(curKeyboard.wKey.isPressed){
                rb.AddForce(1 * transform.forward * speed);
            }else if(curKeyboard.sKey.isPressed){
                rb.AddForce(0.5f*transform.forward*-speed/4);
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
        Debug.Log(rb.linearVelocity);
     
    }
    private void FixedUpdate(){
        // return;
        if (motorSpray != null) {
            float x = rb.linearVelocity.x;
            float z = rb.linearVelocity.z;
            var emission = motorSpray.emission;
            emission.rate = Mathf.Sqrt(x*x + z*z);
        }
        // motorSpray.transform.position = propeller.position;
        // motorSpray.transform.rotation = propeller.rotation;

        float frequencyIncrementIncrement = Mathf.Sqrt(rb.linearVelocity.x*rb.linearVelocity.x+rb.linearVelocity.z*rb.linearVelocity.z)/10f;
        frequencyIncrement += Mathf.Clamp(frequencyIncrementIncrement,0.5f,10f);

        rb.linearVelocity =  drag*rb.linearVelocity;
        //5.5*sin(x/100*pi)+4.5
        Vector3 newZRotation = Vector3.back * (5.5f*Mathf.Sin((frequencyIncrement-30.50178f)/100*Mathf.PI)+4.5f);

        Vector3 newYRotation = Vector3.up * (transform.eulerAngles.y+90);
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