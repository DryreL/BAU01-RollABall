using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5;
    [SerializeField] private Rigidbody2D rigidbody;
    
    void OnEnable()
    {
        rigidbody.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    // TODO: Apply Object Pooling
    private void OnBecameInvisible()
    {
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
