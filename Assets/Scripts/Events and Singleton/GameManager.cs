using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Transform chest;
    public Transform dolap;
    public Transform[] candles;
    public Transform chair;

    // Start is called before the first frame update
    public void onChest()
    {
        if (chest)
        {
            chest.position = new Vector3(0, 0, -1);
        }
        Debug.Log("Clicked on chest!");
    }

    public void onDolap()
    {
        if (dolap)
        {
            dolap.position = new Vector3(0, 0, -1);
        }
        Debug.Log("Clicked on Dolap!");
    }

    public void onCandles()
    {
        if (candles.Length > 0)
        {
            candles[0].position = new Vector3(0, 0, -1);
            candles[1].position = new Vector3(0, 0, -1);
            candles[2].position = new Vector3(0, 0, -1);
            candles[3].position = new Vector3(0, 0, -1);
            candles[4].position = new Vector3(0, 0, -1);
            candles[5].position = new Vector3(0, 0, -1);
            candles[6].position = new Vector3(0, 0, -1);
            candles[7].position = new Vector3(0, 0, -1);
            candles[8].position = new Vector3(0, 0, -1);
        }
        Debug.Log("Clicked on Candle!");
    }

    public void onChair()
    {
        if (chair)
        {
            chair.position = new Vector3(0, 1, 0);
        }
        Debug.Log("Clicked on Chair!");
    }
}
