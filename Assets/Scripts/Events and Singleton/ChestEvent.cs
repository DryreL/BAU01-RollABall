using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestEvent : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        EventController.onChest += Chest;
    }

    void Chest()
    {
        rb.AddForce(this.gameObject.transform.forward * 25);
        this.audioSource.Play();
        Debug.Log("Chest Moved!");
    }

    private void OnMouseDown()
    {
        Chest();
    }

}
