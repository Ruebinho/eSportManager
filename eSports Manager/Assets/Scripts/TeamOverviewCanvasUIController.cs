﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using UnityEngine.UI;
using System;
using TMPro;

public class TeamOverviewCanvasUIController : MonoBehaviour
{
    public Team currentSelectedTeam = null;
    public GameObject currentSelectedPlayer = null;
    public DotACanvasUIController dotaCanvasUI = null;

    public GameObject playerUIInstatiateParent = null;
    public GameObject playerElementInstatiatePrefab = null;

    private void Start()
    {
        currentSelectedTeam = FindObjectOfType<GameDatabase>().teamsInGame[0];
    }

    public void SelectPlayer(GameObject playerElement)
    {
        if (currentSelectedPlayer == playerElement) { }
        else if (currentSelectedPlayer != playerElement || currentSelectedPlayer == null)
        {
            if (currentSelectedPlayer != null)
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
            currentSelectedPlayer = playerElement;
        }
        else
        {
            Debug.LogError("SelectPlayer is broken!");
        }
    }

    public void UnselectCurrentPlayer()
    {
        foreach (Transform child in currentSelectedPlayer.transform)
        {
            if (child.name == "Border")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ShowSelectedPlayerDetails()
    {
        if (currentSelectedPlayer != null)
        {
            dotaCanvasUI = GetComponent<DotACanvasUIController>();
            dotaCanvasUI.DisplayPlayer(currentSelectedPlayer.GetComponent<PlayerElementUIController>().playerData);
        }
        else
        {
            Debug.Log("No Player selected!");
        }
    }

    public void InstantiatePlayerElementsForTeam()
    {
        Debug.Log(currentSelectedTeam.playersOnTeam);

        foreach (Player player in currentSelectedTeam.playersOnTeam)
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

        currentSelectedPlayer = null;
    }
}
