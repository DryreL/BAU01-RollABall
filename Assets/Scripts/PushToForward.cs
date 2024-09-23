using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushToForward : MonoBehaviour
{

    RaycastHit _rayHit;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _rayHit))
            {
                if (_rayHit.transform.CompareTag("Touchable"))
                {
                    _rayHit.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 3, ForceMode.Impulse);
                }
            }
        }
    }
}
