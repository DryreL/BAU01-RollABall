using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDie : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Debug.Log("Game Over!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("YouDie"))
        {
            gameObject.SetActive(false);
            Debug.Log("Game Over!");
        }
    }
}
