using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleEvent : MonoBehaviour
{

    public GameObject[] particles;
    //Light _light;
    //ParticleSystem _particleSystem;
    bool lightisOn;

    // Start is called before the first frame update
    void Awake()
    {
        EventController.onCandle += LightsOut;
        //_light = GetComponent<Light>();
        //_particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LightsOut()
    {
        //this._light.enabled = false;
        //this._particleSystem.gameObject.SetActive(false);

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(false);
        }
        lightisOn = false;
        Debug.Log("Candle lights gone!");
    }

    void LightsOn()
    {
        //this._light.enabled = false;
        //this._particleSystem.gameObject.SetActive(false);

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(true);
        }
        lightisOn = true;
        Debug.Log("Candle lights gone!");
    }

    private void OnMouseDown()
    {
        if(lightisOn == true)
        {
            LightsOut();
        }
        else if(lightisOn == false)
        {
            LightsOn();
        }
    }
}
