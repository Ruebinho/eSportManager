using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    GameDatabase gamedatabase;

    public GameOverviewUIController gameoverviewUI = null;
    public DotACanvasUIController dotaCanvasUI = null;
    public FinanceUIController financeUI = null;

    public Organization currentSelectedOrg = null;
    public Team currentSelectedTeam = null;

    public GameObject currentSelectedOrgUI = null;
    public GameObject currentSelectedTeamUI = null;
    public GameObject currentSelectedPlayerUI = null;
   
    public GameObject orgUIInstatiateParent = null;
    public GameObject orgElementInstatiatePrefab = null;

    public GameObject teamUIInstatiateParent = null;
    public GameObject teamElementInstatiatePrefab = null;

    public GameObject playerUIInstatiateParent = null;
    public GameObject playerTransferUIInstatiateParent = null;
    public GameObject playerElementInstatiatePrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        gamedatabase = FindObjectOfType<GameDatabase>();
        currentSelectedOrg = gamedatabase.orgsInGame[1];
    }

    public void ShowAllOrgs()
    {
        foreach (Organization org in gamedatabase.orgsInGame)
        {
            if (org != null)
            {
                orgElementInstatiatePrefab.GetComponent<OrgElementUIController>().orgData = org;
                Instantiate(orgElementInstatiatePrefab, orgUIInstatiateParent.transform);
            }
        }
    }

    #region OrgTeamOverview

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
            InstantiatePlayerElementsForTeam(currentSelectedTeam);
        }
        else
        {
            Debug.Log("No Team selected!");
        }
    }

    public void InstantiateTeamElements(Organization selectedOrg)
    {
        //Debug.Log(currentSelectedTeam.playersOnTeam);

        foreach (Team team in selectedOrg.orgTeams)
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

    #endregion

    #region TeamOverview

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

    public void InstantiatePlayerElementsForPotentialTransfer()
    {
        foreach (Player player in gamedatabase.playersInGame)
        {
            if (player.careerContracts[player.careerContracts.Length] = null)
            {
                playerElementInstatiatePrefab.GetComponent<PlayerElementUIController>().playerData = player;
                Instantiate(playerElementInstatiatePrefab, playerTransferUIInstatiateParent.transform);
            }
        }
    }

    public void ShowTransferOverview()
    {
            InstantiatePlayerElementsForPotentialTransfer();
    }

    #endregion

    #region OrgOverview

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

    public void ShowSelectedOrgTeams()
    {
        if (currentSelectedOrgUI != null)
        {
            Debug.Log(currentSelectedOrgUI);
            InstantiateTeamElements(currentSelectedOrg);
        }
        else
        {
            Debug.Log("No Org selected!");
        }
    }

    public void ShowSelectedOrgDetails()
    {
        //TODO implement UI display
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

    public void ShowSelectedOrgMerch()
    {
        //TODO implement UI display
    }

    public void ShowSelectedOrgFinance()
    {
        Debug.Log(currentSelectedOrg);
        financeUI = FindObjectOfType<FinanceUIController>();
        financeUI.DisplayFinanceUIValues((Organization)currentSelectedOrg);
    }

    public void ShowSelectedOrgSponsor()
    {
        //TODO implement UI display
    }

    public void ShowSelectedOrgStaff()
    {
        //TODO implement UI display
    }

    public void ShowGameOverview()
    {
        //TODO implement UI display
        Debug.Log(currentSelectedOrg);
        gameoverviewUI = FindObjectOfType<GameOverviewUIController>();
        gameoverviewUI.DisplayGameOverview((Organization)currentSelectedOrg);
    }

    #endregion

    #region core parameters

    public void UpdateDateUI()
    {
        gameoverviewUI = FindObjectOfType<GameOverviewUIController>();
        gameoverviewUI.UpdateDisplayDate();
    }

    #endregion

}
