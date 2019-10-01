using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField] public enum Game { DotA2, CSGO, FIFA, RocketLeague };

public class Team : MonoBehaviour
{
    public string teamName;
    public Game teamGame;
    public List<Player> playersOnTeam = null;
    public GameDatabase gamedatabase;

    // Start is called before the first frame update
    void Start()
    {
        gamedatabase = FindObjectOfType<GameDatabase>();
        SetupTeam();
        Debug.Log(playersOnTeam);
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
            Debug.Log(IsPlayerNowContractedtoTeam(player));
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
        Contract[] playerContracts = player.careerContracts;

        foreach (Contract playerContract in playerContracts)
        {
            if (PlayerContractOnGameDateIsWithCorrectTeam(playerContract))
            {
                return true;
            }
        }

        return false;

    }

    private bool PlayerContractOnGameDateIsWithCorrectTeam(Contract playerContract)
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

