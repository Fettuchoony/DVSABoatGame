using System;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
 private Keyboard curKeyboard = Keyboard.current;
 private Rigidbody rb;
 public float speed = 0; 
 public float maxSpeed = 10;
//  public float rotationSpeed = 0;
 public float drag = 0f;
 public Transform front;
 private int isGoingForward;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    void Update(){
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
    private void FixedUpdate(){
        rb.linearVelocity =  drag*rb.linearVelocity;
    }
}