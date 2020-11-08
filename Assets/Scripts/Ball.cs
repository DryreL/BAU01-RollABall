using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontal = 0;
    private float vertical = 0;
    private float speed = 20.0f;
    public Camera _camera;
    public Vector3 touch_pos;
    public Joystick _Joystick;
    Vector3 direction = Vector3.zero;
    bool isTouching = false;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        Input.simulateMouseWithTouches = true;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }

        Vector3 rotation = _camera.transform.rotation.eulerAngles;
        rotation = rotation + Vector3.up * _Joystick.Horizontal + Vector3.right * _Joystick.Vertical;
        _camera.transform.rotation = Quaternion.Euler(rotation);

        //touch_pos = Input.GetTouch(0).position;
        touch_pos = Input.mousePosition;
        Debug.Log(touch_pos.ToString() + " touch_pos");
        var point = _camera.ScreenToWorldPoint(new Vector3(touch_pos.x, touch_pos.y, _camera.transform.position.y));
        Debug.Log(point.ToString() + " point");

        direction = (point - transform.position).normalized * speed;
        Debug.Log(direction.ToString() + " direction");

        //Rotasyon(_Joystick.Horizontal, _Joystick.Vertical, 0);
    }

    private void FixedUpdate()
    {
        if (isTouching)
        {
            rb.AddForce(direction.x, 0.0f, direction.z, ForceMode.Acceleration);
        }
    }

    public void Rotasyon(float x, float y, float z)
    {
        Vector3 rotation = _camera.transform.rotation.eulerAngles;

        rotation += Vector3.up * x;
        rotation += Vector3.left * y;
        rotation += Vector3.forward * z;

        _camera.transform.rotation = Quaternion.Euler(rotation);

    }
}
