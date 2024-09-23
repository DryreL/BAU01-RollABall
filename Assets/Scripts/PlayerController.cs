using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 60;
    public float rotationSpeed = 70;

    private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _trail;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        speed *= .02f;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        // Rotation
        _rigidbody.angularVelocity = Input.GetAxis("Horizontal") * rotationSpeed;
        
        // Acceleration
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(transform.up * speed);
            _trail.enabled = true;
        }
        else
        {
            if (_rigidbody.velocity.magnitude > 0.1f)
            {
                _rigidbody.velocity *= .99f;
            }
            _trail.enabled = false;
        }
    }
}
