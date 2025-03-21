using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
 private Keyboard curKeyboard = Keyboard.current;
  public GameObject canvas;
 private Rigidbody rb;
 public float speed = 0; 
 public float maxSpeed = 10;
 public float drag = 0f;
 private bool isPaused = false;
 public ParticleSystem motorSpray;
 private Transform propeller;

 private float lastPause;
    void Start(){
        rb = GetComponent<Rigidbody>();
        canvas.SetActive(false);
        Transform propObj = transform.Find("Propeller");
        if (propeller != null) {
            propeller = propObj.transform;
        }
    }
    void Update(){
        if(!isPaused){
            if(curKeyboard.wKey.isPressed){
                if(math.abs(rb.linearVelocity.x)+math.abs(rb.linearVelocity.z) <= maxSpeed){
                    rb.AddForce(1 * transform.forward * speed);
                }
            }else if(curKeyboard.sKey.isPressed){
                rb.AddForce(0.5f*transform.forward*-speed/4);
            }
            if(curKeyboard.aKey.isPressed){
                transform.eulerAngles += UnityEngine.Vector3.down;
            }
            if(curKeyboard.dKey.isPressed){
                transform.eulerAngles += UnityEngine.Vector3.up;
            }
        }
        if(curKeyboard.escapeKey.isPressed && (Time.realtimeSinceStartup - lastPause > 0.2f)){
            lastPause = Time.realtimeSinceStartup;
            escapeMenu();
        }
     
    }
    private void FixedUpdate(){
        motorSpray.transform.position = propeller.position;
        motorSpray.transform.rotation = propeller.rotation;
        rb.linearVelocity =  drag*rb.linearVelocity;
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