using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed=1f;
    [SerializeField] float jumpHeight=3f;
    float direction=0;
    bool isGrounded=false;
    int timesJumped=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction);
    }

    void OnMove(InputValue value) {
        float v = value.Get<float>();
        direction=v;
    }

    void Move(float dir) {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            rb.linearVelocity=new Vector2(dir*speed*3, rb.linearVelocity.y);
        }
        else {
            rb.linearVelocity=new Vector2(dir*speed, rb.linearVelocity.y);
        }
    }

    void OnJump() {
        if (isGrounded || timesJumped==1)
            Jump();        
        else 
            timesJumped=0;
        
    }

    void Jump() {
        timesJumped++;
        rb.linearVelocity=new Vector2(rb.linearVelocity.x, jumpHeight);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        
    }

    void OnCollisionStay2D(Collision2D collision ) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded=false; 
            for (int i=0;i<collision.contactCount;i++) {
            if (Vector2.Angle(collision.GetContact(i).normal, Vector2.up) <45f) {
                isGrounded=true;
            }
        }
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded=false;
        }
    }

    public void StartSpeedBoost(float boostAmount, float duration) {
        StartCoroutine(SpeedBoostRoutine(boostAmount, duration));
    }

    private IEnumerator SpeedBoostRoutine(float boostAmount, float duration) {
        float originalSpeed = speed;
        speed += boostAmount;
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
    }
}