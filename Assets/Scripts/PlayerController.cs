using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RaycastHit _rayHit;
    private Rigidbody _rigidbody;
    public LineRenderer line;
    private Vector3 _direction;
    private float xrotation, yrotation = 0f;
    private float rotateSpeed = 5f;
    int pullPower = 2000;
    bool isTouching = false;

    // Start is called before the first frame update
    void Start()
    {
        //Input.simulateMouseWithTouches = true;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;
            _rigidbody.AddForce(_direction * -pullPower, ForceMode.Acceleration);
        }

        if (Input.GetMouseButton(0))
        {
            //isTouching = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out _rayHit))
            {
                /*
                xrotation += Input.GetAxis("Mouse X") * rotateSpeed;
                //yrotation += Input.GetAxis("Mouse Y") * rotateSpeed;
                transform.rotation = Quaternion.Euler(xrotation, yrotation, 0f);
                */

                _direction = _rayHit.point - transform.position;
                _direction = _direction.normalized;

                //_rayHit.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * pullPower, ForceMode.Impulse);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, transform.position + _direction);
            }
        }
        else
        {
            line.enabled = false;
            //isTouching = false;
        }


    }

    private void FixedUpdate()
    {
        if (isTouching)
        {
            //_rigidbody.AddForce(_direction.x, 0, _direction.z, ForceMode.Acceleration);
        }
    }
}
