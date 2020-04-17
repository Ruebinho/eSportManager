using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public Organization orgTeamBelongsTo;
    public string teamName;
    public GlobalGameParameters.Game teamGame;
    public List<Player> playersOnTeam = null;
    public Player teamCaptain = null;
    public GameDatabase gamedatabase;

    // Start is called before the first frame update
    void Start()
    {
        gamedatabase = FindObjectOfType<GameDatabase>();
        SetupTeam();
        //Debug.Log(playersOnTeam);
    }

    private void SetupTeam()
    {
        //if (gamedatabase)
        //{
        //    Debug.Log("found pdb");
        //}
        //else
        //{
        //    Debug.Log("you got shit");
        //}

        foreach (Player player in gamedatabase.playersInGame)
        {
            //Debug.Log(IsPlayerNowContractedtoTeam(player));
            if (IsPlayerNowContractedtoTeam(player))
            {
                playersOnTeam.Add(player);
            }
        }
    }

    internal void Initialise(Team team)
    {
        teamName = team.teamName;
        teamGame = team.teamGame;
        playersOnTeam = team.playersOnTeam;
    }

    private bool IsPlayerNowContractedtoTeam(Player player)
    {
        List<PlayerContract> playerContracts = player.careerContracts;

        foreach (PlayerContract playerContract in playerContracts)
        {
            if (playerContract != null && PlayerContractOnGameDateIsWithCorrectTeam(playerContract))
            {
                return true;
            }
        }

        return false;

    }

    private bool PlayerContractOnGameDateIsWithCorrectTeam(PlayerContract playerContract)
    {
        int gameDateDay = FindObjectOfType<GlobalGameParameters>().gameTimeDay;
        int gameDateMonth = FindObjectOfType<GlobalGameParameters>().gameTimeMonth;
        int gameDateYear = FindObjectOfType<GlobalGameParameters>().gameTimeYear;

        bool beginDatumContractIsKleinerGleichGameDatum = playerContract.contractStartDateYear <= gameDateYear && playerContract.contractStartDateMonth <= gameDateMonth && playerContract.contractStartDateDay <= gameDateDay;
        bool endeDatumContractIsGroeßerGleichGameDatum = playerContract.contractEndDateYear >= gameDateYear && playerContract.contractEndDateMonth >= gameDateMonth && playerContract.contractEndDateDay >= gameDateDay;

        if (beginDatumContractIsKleinerGleichGameDatum && endeDatumContractIsGroeßerGleichGameDatum && playerContract.teamPlayerIsContractedTo == this)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

