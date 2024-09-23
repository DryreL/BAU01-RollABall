using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{

    public delegate void Events();
    public static event Events onCandle;
    public static event Events onChair;
    public static event Events onCabinet;
    public static event Events onChest;

    public void ChairEvent()
    {
        onChair.Invoke();
    }

    public void CandleEvent()
    {
        onCandle.Invoke();
    }

    public void CabinetEvent()
    {
        onCabinet.Invoke();
    }

    public void ChestEvent()
    {
        onChest.Invoke();
    }

}
