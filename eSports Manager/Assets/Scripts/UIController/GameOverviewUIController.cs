using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverviewUIController : MonoBehaviour
{
    GlobalGameParameters globalGameParameters;

    [SerializeField] public TextMeshProUGUI dayUI;
    [SerializeField] public TextMeshProUGUI monthUI;
    [SerializeField] public TextMeshProUGUI yearUI;

    public void UpdateDisplayDate()
    {
        globalGameParameters = FindObjectOfType<GlobalGameParameters>();

        dayUI.text = DateFormatterDay();
        monthUI.text = DateFormatterMonth();
        yearUI.text = globalGameParameters.gameTimeYear.ToString();
    }

    private string DateFormatterDay()
    {
        string dayFormatted = "";

        if (globalGameParameters.gameTimeDay < 10)
        {
            dayFormatted = "0" + globalGameParameters.gameTimeDay.ToString() + ".";
            return dayFormatted;
        }

        return globalGameParameters.gameTimeDay.ToString() + ".";
    }

    private string DateFormatterMonth()
    {
        string monthFormatted = "";

        if (globalGameParameters.gameTimeMonth < 10)
        {
            monthFormatted = "0" + globalGameParameters.gameTimeMonth.ToString() + ".";
            return monthFormatted;
        }

        return globalGameParameters.gameTimeMonth.ToString() + ".";
    }

    internal void DisplayGameOverview(Organization organization)
    {
        // display selected orgs details in gameoverview
        throw new NotImplementedException();
    }
}
