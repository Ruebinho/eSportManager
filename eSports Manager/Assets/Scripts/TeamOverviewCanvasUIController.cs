using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using UnityEngine.UI;
using System;
using TMPro;

public class TeamOverviewCanvasUIController : MonoBehaviour
{
    public GameObject currentSelectedPlayer = null;
    public DotACanvasUIController dotaCanvasUI = null;

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
            dotaCanvasUI.DisplayPlayer(currentSelectedPlayer.GetComponent<Player>());
        }
        else
        {
            Debug.Log("No Player selected!");
        }
    }
}
