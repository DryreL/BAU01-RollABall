using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPoolerImproved : MonoBehaviour
{
    [Serializable]
    public struct PoolObject
    {
        public string name;
        public GameObject prefab;
        public int size;
    }
    public PoolObject[] objects;

    private Dictionary<string, GameObject[]> _objectPool;

    /// <summary>
    /// "Muz" : [muz0,muz1,muz2,muz3,muz4]
    /// "Armut" : [armut0, armut1, armut2]
    /// 
    /// _objectPool["Armut"] : [armut0, armut1, armut2]
    /// _objectPool["Armut"][0] : armut0
    /// </summary>
    private void Start()
    {
        CreatePool();
    }
    
    private void CreatePool()
    {
        _objectPool = new Dictionary<string, GameObject[]>();

        for (int i = 0; i < objects.Length; i++)
        {
            GameObject[] arrayOfObjects = new GameObject[objects[i].size]; // We Created our array of one prefab type

            for (int j = 0; j < arrayOfObjects.Length; j++)
            {
                GameObject poolObject = Instantiate(objects[i].prefab);
                poolObject.SetActive(false);
                arrayOfObjects[j] = poolObject;
            }
            // After array instantiated and assigned
            _objectPool.Add(objects[i].name, arrayOfObjects);
        }
    }

    private void FixedUpdate()
    {
        SpawnRandomObject();
    }

    public void SpawnObjectWithName(string name)
    {
        GameObject[] currentPool = _objectPool[name];

        for (int i = 0; i < currentPool.Length; i++)
        {
            if (!currentPool[i].activeInHierarchy)
            {
                currentPool[i].transform.position = Random.insideUnitSphere + transform.position;
                currentPool[i].SetActive(true);
                return;
            }
        }
    }

    #region helperfunctions

    public void SpawnObjectWithIndexNumber(int index)
    {
        SpawnObjectWithName(objects[index].name);
    }

    public void SpawnRandomObject()
    {
        SpawnObjectWithIndexNumber(Random.Range(0, objects.Length));
    }

    #endregion

}
