using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPooler : MonoBehaviour
{
    public GameObject prefab;
    public int size;

    private GameObject[] objectPool;
    
    void Start() // Created my pool
    {
        objectPool = new GameObject[size];

        for (int i = 0; i < size; i++)
        {
            objectPool[i] = Instantiate(prefab);
            objectPool[i].SetActive(false);
        }
    }

    /*
    private void FixedUpdate() // 50 FPS
    {
        SpawnObject();
    }
    */

    public void SpawnObject()
    {
        for (int i = 0; i < size; i++) // search for disabled object
        {
            if (!objectPool[i].activeInHierarchy) // we ve found our first disabled object
            {
                objectPool[i].transform.position = Random.insideUnitSphere + transform.position;
                objectPool[i].SetActive(true); // Activate our object
                return; // Finish the function
            }
        }
    }
}