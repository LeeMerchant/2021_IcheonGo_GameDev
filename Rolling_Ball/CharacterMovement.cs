using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10;
    public float jump = 20;
    public float windpower = 50;

    public GameObject timer;
    public GameObject Camera;
    public GameObject Win;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    private bool IsJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void Move()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        Quaternion v3Rotation = Quaternion.Euler(0f, Camera.transform.eulerAngles.y, 0f);
        
        movement = v3Rotation * movement;

        rb.AddForce(movement * speed);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsJumping)
            {
                IsJumping = true;
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            IsJumping = false;
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            timer = GameObject.FindWithTag("Timer");
            timer.GetComponent<Timer>().win();
        }
    }

    public void Respawn()
    {
        transform.position = new Vector3(25.0f, 25.0f, -10.0f);
    }
}