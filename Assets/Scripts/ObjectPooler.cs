using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPooler : MonoBehaviour
{
    public GameObject prefab;
    public int size;
    //private int pushTheObject = 10;

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

    private void FixedUpdate() // 50 FPS
    {
        //SpawnObject();
    }

    private void Update()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        for (int i = 0; i < size; i++) // search for disabled object
        {
            if (!objectPool[i].activeInHierarchy) // we ve found our first disabled object
            {
                objectPool[i].transform.position = Random.insideUnitSphere * 7 + transform.position;
                //objectPool[i].transform.position = this.gameObject.GetComponent<Rigidbody2D>().velocity * 2;
                objectPool[i].SetActive(true); // Activate our object
                return; // Finish the function
            }
        }
    }
}