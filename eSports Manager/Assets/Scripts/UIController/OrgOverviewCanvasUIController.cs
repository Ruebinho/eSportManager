using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using UnityEngine.UI;
using System;
using TMPro;

public class OrgOverviewCanvasUIController : MonoBehaviour
{
    public OrgTeamOverviewCanvasUIController orgTeamOverviewCanvasUIController = null;

    GameDatabase gamedatabase;

    public GameObject currentSelectedOrgUI = null;
    public GameObject orgUIInstatiateParent = null;
    public GameObject orgElementInstatiatePrefab = null;

    private void Start()
    {
        gamedatabase = FindObjectOfType<GameDatabase>();
        //currentSelectedOrg = FindObjectOfType<GameDatabase>().teamsInGame[0];
    }

    public void SelectOrg(GameObject orgElement)
    {
        if (currentSelectedOrgUI == orgElement) { }
        else if (currentSelectedOrgUI != orgElement || currentSelectedOrgUI == null)
        {
            if (currentSelectedOrgUI != null)
            {
                UnselectCurrentOrg();
            }

            foreach (Transform child in orgElement.transform)
            {
                if (child.name == "Border")
                {
                    child.gameObject.SetActive(true);
                }
            }
            currentSelectedOrgUI = orgElement;
        }
        else
        {
            Debug.LogError("SelectOrg is broken!");
        }
    }

    public void UnselectCurrentOrg()
    {
        foreach (Transform child in currentSelectedOrgUI.transform)
        {
            if (child.name == "Border")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ShowSelectedOrgDetails()
    {
        if (currentSelectedOrgUI != null)
        {
            orgTeamOverviewCanvasUIController = GetComponent<OrgTeamOverviewCanvasUIController>();
            orgTeamOverviewCanvasUIController.InstantiateTeamElements(orgTeamOverviewCanvasUIController.currentSelectedOrg);
        }
        else
        {
            Debug.Log("No Org selected!");
        }
    }

    public void InstantiateOrgElements()
    {
        //Debug.Log(currentSelectedTeam.playersOnTeam);

        Debug.Log("Org OVerview");

        foreach (Organization org in gamedatabase.orgsInGame)
        {
            if (org != null)
            {
                orgElementInstatiatePrefab.GetComponent<OrgElementUIController>().orgData = org;
                Instantiate(orgElementInstatiatePrefab, orgUIInstatiateParent.transform);
            }
        }
    }

    public void DestroyAllOrgElementsWhenLeavingUI()
    {
        foreach (Transform child in orgUIInstatiateParent.transform)
        {
            Destroy(child.gameObject);
        }

        currentSelectedOrgUI = null;
    }
}
