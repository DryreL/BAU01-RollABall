using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candleController : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance.onCandles();
    }
}
