using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetEvent : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        EventController.onCabinet += Cabinet;
    }

    void Cabinet()
    {
        rb.AddForce(this.gameObject.transform.up * 55);
        this.audioSource.Play();
        Debug.Log("Cabinet Moved!");
    }

    private void OnMouseDown()
    {
        Cabinet();
    }

}
