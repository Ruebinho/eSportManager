using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractGenerator : MonoBehaviour
{
    public PlayerContract playerContractPrefab;
    public SponsorContract sponsorContractPrefab;
    public StaffContract staffContractPrefab;

    public int startDay;
    public int startMonth;
    public int startYear;

    public int endDay;
    public int endMonth;
    public int endYear;

    public GameCoreLogic gamecoreLogic = null;
    public GlobalGameParameters ggp;
    public Calendar cal;
    public Player playerToContract = null;
    public float wage;

    // Start is called before the first frame update
    void Start()
    {
        gamecoreLogic = FindObjectOfType<GameCoreLogic>();
        ggp = FindObjectOfType<GlobalGameParameters>();
        cal = FindObjectOfType<Calendar>();
    }

    public PlayerContract GeneratePlayerContract()
    {
        if (ChooseCorrectTeam() != null)
        {
            PlayerContract generatedPlayerContract = playerContractPrefab.GeneratePlayerContract(ChooseCorrectTeam(), startDay, startMonth, startYear, endDay, endMonth, endYear, wage);
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

    public SponsorContract GenerateSponsorContract(Organization org)
    {
        ChooseFittingDates();
        SponsorContract generatedSponsorContract = sponsorContractPrefab.GenerateSponsorContract(ChooseCorrectOrg(org), startDay, startMonth, startYear, endDay, endMonth, endYear);

        return generatedSponsorContract;
    }

    private void ChooseFittingDates()
    {
        //TODO fix adaptive date selection

        int calTodayDateDay = cal.currentDay;
        int calTodayDateMonth = cal.currentMonth;
        int calTodayDateYear = cal.currentYear;

        startDay = 01;
        startMonth = 01;
        startYear = 2020;

        endDay = 31;
        endMonth = 12;
        endYear = 2022;

    }

    private Organization ChooseCorrectOrg(Organization org)
    {
        //TODO sinnlose methode?

        //if(org.Equals(gamecoreLogic.playerSelectedOrg))
        //{
        //    return gamecoreLogic.playerSelectedOrg;
        //} else
        //{
        //    return org;
        //}

        return org;
    }

    public StaffContract GenerateStaffMemberContract(Organization org)
    {
        ChooseFittingDates();
        ChooseFittingWage();

        StaffContract generatedStaffContract = staffContractPrefab.GenerateStaffContract(ChooseCorrectOrg(org), startDay, startMonth, startYear, endDay, endMonth, endYear, wage);

        return generatedStaffContract;
    }

    private void ChooseFittingWage()
    {
        //TODO put reasonable amount
        wage = 10f;
    }
}
