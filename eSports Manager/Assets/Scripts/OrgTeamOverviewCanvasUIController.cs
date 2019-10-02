using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using UnityEngine.UI;
using System;
using TMPro;

public class OrgTeamOverviewCanvasUIController : MonoBehaviour
{
    public TeamOverviewCanvasUIController teamOverviewCanvasUIController = null;

    GameDatabase gamedatabase;

    public GameObject currentSelectedTeamUI = null;
    public GameObject teamUIInstatiateParent = null;
    public GameObject teamElementInstatiatePrefab = null;

    private void Start()
    {
        gamedatabase = FindObjectOfType<GameDatabase>();
        //currentSelectedOrg = FindObjectOfType<GameDatabase>().teamsInGame[0];
    }

    public void SelectTeam(GameObject teamElement)
    {
        if (currentSelectedTeamUI == teamElement) { }
        else if (currentSelectedTeamUI != teamElement || currentSelectedTeamUI == null)
        {
            if (currentSelectedTeamUI != null)
            {
                UnselectCurrentTeam();
            }

            foreach (Transform child in teamElement.transform)
            {
                if (child.name == "Border")
                {
                    child.gameObject.SetActive(true);
                }
            }
            currentSelectedTeamUI = teamElement;
        }
        else
        {
            Debug.LogError("Selectteam is broken!");
        }
    }

    public void UnselectCurrentTeam()
    {
        foreach (Transform child in currentSelectedTeamUI.transform)
        {
            if (child.name == "Border")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ShowSelectedTeamDetails()
    {
        if (currentSelectedTeamUI != null)
        {
            teamOverviewCanvasUIController = GetComponent<TeamOverviewCanvasUIController>();
            teamOverviewCanvasUIController.InstantiatePlayerElementsForTeam(teamOverviewCanvasUIController.currentSelectedTeam);
        }
        else
        {
            Debug.Log("No Team selected!");
        }
    }

    public void InstantiateTeamElements()
    {
        //Debug.Log(currentSelectedTeam.playersOnTeam);

        foreach (Team team in gamedatabase.teamsInGame)
        {
            if (team != null)
            {
                teamElementInstatiatePrefab.GetComponent<TeamElementUIController>().teamData = team;
                Instantiate(teamElementInstatiatePrefab, teamUIInstatiateParent.transform);
            }
        }
    }

    public void DestroyAllTeamElementsWhenLeavingUI()
    {
        foreach (Transform child in teamUIInstatiateParent.transform)
        {
            Destroy(child.gameObject);
        }

        currentSelectedTeamUI = null;
    }
}
