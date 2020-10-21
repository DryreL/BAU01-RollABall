using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private float _moveHorizontal, _moveVertical;
    public float forceMultiplier = 10;
    public bool _isJumping;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _isJumping = true;
            _rigidbody.AddForce(0, 5f, 0, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _moveHorizontal = Input.GetAxis("Horizontal") * forceMultiplier;
        _moveVertical = Input.GetAxis("Vertical") * forceMultiplier;


        _rigidbody.AddForce(_moveHorizontal, 0, _moveVertical, ForceMode.Acceleration);

    }

    private void OnTriggerEnter(Collider other)
    {
        _isJumping = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Coin"))
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
