using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] _lights;
    public GameObject jumpscare1;
    bool jumpscare = false;
    bool lightisOn = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Button Events
    public void WindowLeftEvent()
    {
        lightisOn = !lightisOn;

        if (lightisOn)
        {
            _lights[0].gameObject.SetActive(false);
            _lights[1].gameObject.SetActive(false);
            _lights[2].gameObject.SetActive(false);
            _lights[3].gameObject.SetActive(false);
            _lights[4].gameObject.SetActive(false);
        }
        else
        {
            _lights[0].gameObject.SetActive(true);
            _lights[1].gameObject.SetActive(true);
            _lights[2].gameObject.SetActive(true);
            _lights[3].gameObject.SetActive(true);
            _lights[4].gameObject.SetActive(true);
        }
    }

    public IEnumerator WindowRightEvent()
    {
        if (jumpscare == false)
        {
            jumpscare1.SetActive(true);
        }
        else if (jumpscare == true)
        {
            jumpscare1.SetActive(false);
        }

        yield return new WaitForSeconds(5);
        jumpscare1.SetActive(false);
    }

    public void WindowRightEventRun()
    {
        StartCoroutine(WindowRightEvent());
    }
}
