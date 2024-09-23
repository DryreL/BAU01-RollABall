using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairEffect : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        EventController.onChair += Chair;
    }

    void Chair()
    {
        rb.AddForce(this.gameObject.transform.forward * 35);
        this.audioSource.Play();
        Debug.Log("Chair Moved!");
    }

    private void OnMouseDown()
    {
        Chair();
    }

}
