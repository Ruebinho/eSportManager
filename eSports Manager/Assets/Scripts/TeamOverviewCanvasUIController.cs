using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using UnityEngine.UI;
using System;
using TMPro;

public class TeamOverviewCanvasUIController : MonoBehaviour
{


    public Team currentSelectedTeam = null;
    public GameObject currentSelectedPlayerUI = null;
    public DotACanvasUIController dotaCanvasUI = null;
    
    public GameObject playerUIInstatiateParent = null;
    public GameObject playerElementInstatiatePrefab = null;

    private void Start()
    {
        currentSelectedTeam = FindObjectOfType<GameDatabase>().teamsInGame[0];
    }

    //private void setupButton()
    //{
    //    Button playerInstanciateButton = GetComponent<Button>();
    //    playerInstanciateButton.onClick.AddListener(clickSelectPlayer);
    //}

    //public void clickSelectPlayer()
    //{
    //    FindObjectOfType<TeamOverviewCanvasUIController>().SelectPlayer(this.gameObject);
    //}

    public void SelectPlayer(GameObject playerElement)
    {
        if (currentSelectedPlayerUI == playerElement) { }
        else if (currentSelectedPlayerUI != playerElement || currentSelectedPlayerUI == null)
        {
            if (currentSelectedPlayerUI != null)
            {
                UnselectCurrentPlayer();
            }

            foreach (Transform child in playerElement.transform)
            {
                if (child.name == "Border")
                {
                    child.gameObject.SetActive(true);
                }
            }
            currentSelectedPlayerUI = playerElement;
        }
        else
        {
            Debug.LogError("SelectPlayer is broken!");
        }
    }

    public void UnselectCurrentPlayer()
    {
        foreach (Transform child in currentSelectedPlayerUI.transform)
        {
            if (child.name == "Border")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ShowSelectedPlayerDetails()
    {
        if (currentSelectedPlayerUI != null)
        {
            dotaCanvasUI = GetComponent<DotACanvasUIController>();
            dotaCanvasUI.DisplayPlayer(currentSelectedPlayerUI.GetComponent<PlayerElementUIController>().playerData);
        }
        else
        {
            Debug.Log("No Player selected!");
        }
    }

    public void InstantiatePlayerElementsForTeam(Team selectedTeam)
    {
        foreach (Player player in selectedTeam.playersOnTeam)
        {
            if (player != null)
            {
                playerElementInstatiatePrefab.GetComponent<PlayerElementUIController>().playerData = player;
                Instantiate(playerElementInstatiatePrefab, playerUIInstatiateParent.transform);
            }
        }
    }

    public void DestroyAllPlayerElementsWhenLeavingUI()
    {
        foreach (Transform child in playerUIInstatiateParent.transform)
        {
            Destroy(child.gameObject);
        }

        currentSelectedPlayerUI = null;
    }
}
