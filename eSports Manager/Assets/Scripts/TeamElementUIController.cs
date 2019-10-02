using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TeamElementUIController : MonoBehaviour
{
    public Team teamData = null;

    // Start is called before the first frame update
    void Start()
    {
        //playerData = GetComponent<Player>();
        PopulateUIWithPlayerData();
        setupButton();

    }

    private void setupButton()
    {
        Button playerButton = GetComponent<Button>();
        playerButton.onClick.AddListener(clickSelectTeam);
    }

    public void clickSelectTeam()
    {
        FindObjectOfType<OrgTeamOverviewCanvasUIController>().SelectTeam(this.gameObject);
        FindObjectOfType<TeamOverviewCanvasUIController>().currentSelectedTeam = teamData;
    }

    private void PopulateUIWithPlayerData()
    {
        foreach (Transform child in transform)
        {
            //if (child.name == "Name")
            //{
            //    child.GetComponent<TextMeshProUGUI>().text = teamData.vorname.ToString() + " " + teamData.nachname.ToString();
            //}

            //if (child.name == "Nickname")
            //{
            //    child.GetComponent<TextMeshProUGUI>().text = teamData.nickname.ToString();
            //}

            //if (child.name == "Age")
            //{
            //    child.GetComponent<TextMeshProUGUI>().text = teamData.age.ToString();
            //}

            //if (child.name == "Position")
            //{
            //    child.GetComponent<TextMeshProUGUI>().text = teamData.role.ToString();
            //}
        }
    }
}
