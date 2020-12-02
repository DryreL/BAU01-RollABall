using UnityEngine;

public class ObjectDespawn : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Disable", 2f);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}