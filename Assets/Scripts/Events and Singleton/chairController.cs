using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chairController : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance.onChair();
    }
}
