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

    void ChairEvent()
    {
        onChair.Invoke();
    }

    void CandleEvent()
    {
        onCandle.Invoke();
    }

    void CabinetEvent()
    {
        onCabinet.Invoke();
    }

    void ChestEvent()
    {
        onChest.Invoke();
    }

}
