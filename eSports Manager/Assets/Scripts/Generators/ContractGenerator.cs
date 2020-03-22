using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractGenerator : MonoBehaviour
{
    public PlayerContract playerContractInit = null;
    public SponsorContract sponsorContractInit = null;
    //public StaffContract staffContractInit = null;

    public int startDay;
    public int startMonth;
    public int startYear;

    public int endDay;
    public int endMonth;
    public int endYear;

    public GameCoreLogic gamecoreLogic = null;
    public Player playerToContract = null;
    public float wage;

    // Start is called before the first frame update
    void Start()
    {
        playerContractInit = GetComponent<PlayerContract>();
        sponsorContractInit = GetComponent<SponsorContract>();
        gamecoreLogic = FindObjectOfType<GameCoreLogic>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public PlayerContract GeneratePlayerContract()
    {
        if (ChooseCorrectTeam() != null)
        {
            PlayerContract generatedPlayerContract = playerContractInit.GeneratePlayerContract(ChooseCorrectTeam(), startDay, startMonth, startYear, endDay, endMonth, endYear, wage);
            return generatedPlayerContract;
        }

        return null;




    }

    private Team ChooseCorrectTeam()
    {
        Team teamToContractPlayerTo = FindFittingTeamInOrgForGamePlayerIsPlaying(playerToContract.gamePlayerIsPlaying);
        return teamToContractPlayerTo;
    }

    private Team FindFittingTeamInOrgForGamePlayerIsPlaying(GlobalGameParameters.Game gamePlayerIsPlaying)
    {
        foreach (Team orgTeam in gamecoreLogic.playerSelectedOrg.orgTeams)
        {
            if (orgTeam.teamGame == gamePlayerIsPlaying)
            {
                return orgTeam;
            }
            else
            {
                return null;
            }
        }

        return null;

    }

    public SponsorContract GenerateSponsorContract()
    {
        ChooseFittingDates();
        SponsorContract generatedSponsorContract = sponsorContractInit.GenerateSponsorContract(ChooseCorrectOrg(), startDay, startMonth, startYear, endDay, endMonth, endYear);

        return generatedSponsorContract;
    }

    private void ChooseFittingDates()
    {
        startDay = 01;
        startMonth = 01;
        startYear = 2020;

        endDay = 31;
        endMonth = 12;
        endYear = 2022;

    }

    private Organization ChooseCorrectOrg()
    {
        return gamecoreLogic.playerSelectedOrg;
    }
}
