using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : Singleton<CanvasManager>
{
    public Button clickHereButton;
    public TextMeshProUGUI mText;
    [SerializeField] private int increasingNumber = 0;

    private void Start()
    {

    }

    public void onclickHereButton()
    {
        increasingNumber++;
    }

    private void Update()
    {
        mText.text = "Number: " + increasingNumber;
    }

}
