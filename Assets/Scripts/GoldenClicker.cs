using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldenClicker : MonoBehaviour
{
    // Texts
    public TextMeshProUGUI goldenGainedText;
    public TextMeshProUGUI workersCountText;
    public TextMeshProUGUI toolsCountText;
    public TextMeshProUGUI vehiclesCountText;

    // Amount (Money)
    public float goldenAmount = 0;

    // Count
    public int workersCount = 0;
    public int toolsCount = 0;
    public int vehiclesCount = 0;

    // Buttons
    public Button workersButton;
    public Button toolsButton;
    public Button vehiclesButton;

    public Button QuickSave;
    public Button QuickLoad;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 144;

        PlayerPrefs.DeleteAll();

        goldenAmount = PlayerPrefs.GetFloat("Golden", 0);

        workersCount = PlayerPrefs.GetInt("Workers", 0);
        toolsCount = PlayerPrefs.GetInt("Tools", 0);
        vehiclesCount = PlayerPrefs.GetInt("Vehicles", 0);

        workersButton.interactable = false;
        toolsButton.interactable = false;
        vehiclesButton.interactable = false;
    }

    // Update is called once per frame
    public void GoldenButtonClick()
    {
        goldenAmount++;
    }

    public void WorkersButtonClick()
    {
        workersButton.interactable = true;
        goldenAmount -= 100;
        workersCount++;
    }

    public void ToolsButtonClick()
    {
        toolsButton.interactable = true;
        goldenAmount -= 500;
        toolsCount++;
    }

    public void VehiclesButtonClick()
    {
        vehiclesButton.interactable = true;
        goldenAmount -= 2500;
        vehiclesCount++;
    }


    public void Update()
    {
        goldenGainedText.text = goldenAmount.ToString("#") + " Golden Gained!";
        workersCountText.text = "Workers Count: \n" + workersCount.ToString("#");
        toolsCountText.text = "Tools Count: \n" + toolsCount.ToString("#");
        vehiclesCountText.text = "Vehicles Count: \n" + vehiclesCount.ToString("#");

        // Quick Save
        if(Input.GetKeyDown(KeyCode.F5))
        {
            Save();
        }

        // Quick Load
        if (Input.GetKeyDown(KeyCode.F8))

        {
            Load();
        }

        if (goldenAmount >= 100)
        {
            workersButton.interactable = true;
        }
        else
        {
            Debug.Log("You don't have 100 gold!");
            workersButton.interactable = false;
        }

        if (goldenAmount >= 500)
        {
            toolsButton.interactable = true;
        }
        else
        {
            Debug.Log("You don't have 500 gold!");
            toolsButton.interactable = false;
        }

        if (goldenAmount >= 2500)
        {
            vehiclesButton.interactable = true;
        }
        else
        {
            Debug.Log("You don't have 2500 gold!");
            vehiclesButton.interactable = false;
        }

        for (int i = 1; i <= workersCount; i++)
        {
            goldenAmount += 0.5f * Time.deltaTime;
        }

        for (int i = 1; i <= toolsCount; i++)
        {
            goldenAmount += 2f * Time.deltaTime;
        }

        for (int i = 1; i <= vehiclesCount; i++)
        {
            goldenAmount += 4f * Time.deltaTime;
        }


    }
    public void Save()
    {
        PlayerPrefs.SetFloat("goldenAmount", goldenAmount);
        PlayerPrefs.SetInt("workersCount", workersCount);
        PlayerPrefs.SetInt("toolsCount", toolsCount);
        PlayerPrefs.SetInt("vehiclesCount", vehiclesCount);

        Debug.Log("Game Saved!");
    }

    public void Load()
    {
        goldenAmount = PlayerPrefs.GetFloat("goldenAmount", 0);
        workersCount = PlayerPrefs.GetInt("workersCount", 0);
        toolsCount = PlayerPrefs.GetInt("toolsCount", 0);
        vehiclesCount = PlayerPrefs.GetInt("vehiclesCount", 0);

        Debug.Log("Game Loaded!");
    }
}
