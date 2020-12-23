using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance.onChest();
    }
}
