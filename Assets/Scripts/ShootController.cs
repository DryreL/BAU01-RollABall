using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float shootDelay = 0.1f;
    public GameObject bulletPrefab;

    public int size;
    public GameObject[] objectPool;

    private float delay = 0;

    private void Start()
    {
        objectPool = new GameObject[size];

        for (int i = 0; i < size; i++)
        {
            objectPool[i] = Instantiate(bulletPrefab);
            objectPool[i].SetActive(false);
        }
    }

    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            delay = shootDelay;
            //Shoot();
            ShootwithPool();
        }
    }

    // TODO: Apply Object Pooling
    public void Shoot()
    {
        Debug.Log("Pew pew!");

        Instantiate(bulletPrefab, transform.position + transform.up, transform.rotation);
    }
    
    public void ShootwithPool()
    {
        Debug.Log("Piuv Piuv!");

        for (int i = 0; i < size; i++) // search for disabled object
        {
            if (!objectPool[i].activeInHierarchy) // we ve found our first disabled object
            {
                objectPool[i].transform.position = transform.position + transform.up;
                objectPool[i].transform.rotation = transform.rotation;
                objectPool[i].SetActive(true); // Activate our object
                return; // Finish the function
            }
        }
    }
}
