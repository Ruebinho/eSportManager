﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatabase : MonoBehaviour
{
    public Player[] playersToAdd;
    public GameObject playerSpawnerParent;

    public Team[] teamsToAdd;
    public GameObject teamSpawnerParent;

    public Contract[] contractsToAdd;
    public GameObject contractSpawnerParent;

    public Organization[] orgsToAdd;
    public GameObject orgSpawnerParent;

    public Sponsor[] sponsorsToAdd;
    public GameObject sponsorSpawnerParent;

    public Finanzen[] financesToAdd;
    public GameObject financesSpawnerParent;

    public Akademie[] academiesToAdd;
    public GameObject academySpawnerParent;

    public Merch[] merchandisesToAdd;
    public GameObject merchandiseSpawnerParent;

    public List<Player> playersInGame;
    public List<Team> teamsInGame;
    public List<Contract> contractsInGame;
    public List<Organization> orgsInGame;
    public List<Finanzen> financesInGame;
    public List<Sponsor> sponsorsInGame;
    public List<Akademie> academiesInGame;
    public List<Merch> merchandisesInGame;

    // Start is called before the first frame update
    void Start()
    {
        SetupGameData();
    }

    private void SetupGameData()
    {
        int contractInitCounter = 0;
        int orgInitCounter = 0;
        int financeInitCounter = 0;

        foreach (Team team in teamsToAdd)
        {
            Team teamInGame = Instantiate(team, teamSpawnerParent.transform);
            teamsInGame.Add(teamInGame);
        }

        foreach (Merch merch in merchandisesToAdd)
        {
            Merch merchInGame = Instantiate(merch, merchandiseSpawnerParent.transform);
            merchandisesInGame.Add(merchInGame);
        }

        foreach (Sponsor sponsor in sponsorsToAdd)
        {
            Sponsor sponsorInGame = Instantiate(sponsor, sponsorSpawnerParent.transform);
            sponsorsInGame.Add(sponsorInGame);
        }

        foreach (Akademie academy in academiesToAdd)
        {
            Akademie academyInGame = Instantiate(academy, academySpawnerParent.transform);
            academiesInGame.Add(academyInGame);
        }

        foreach (Finanzen finance in financesToAdd)
        {
            Finanzen financeInGame = Instantiate(finance, financesSpawnerParent.transform);
            financeInGame.sponsor = sponsorsInGame[financeInitCounter];
            financesInGame.Add(financeInGame);

            financeInitCounter++;
        }

        foreach (Contract contract in contractsToAdd)
        {
            Contract contractInGame = Instantiate(contract, contractSpawnerParent.transform);
            contractInGame.teamPlayerIsContractedTo = teamsInGame[contractInitCounter];
            contractsInGame.Add(contractInGame);

            contractInitCounter++;
        }

        foreach (Player player in playersToAdd)
        {
            Player playerInGame = Instantiate(player, playerSpawnerParent.transform);
            playerInGame.careerContracts.SetValue(contractsInGame[player.initialContractInt], 0);
            playersInGame.Add(playerInGame);
        }

        foreach (Organization org in orgsToAdd)
        {
            Organization orgInGame = Instantiate(org, orgSpawnerParent.transform);
            orgInGame.orgTeams.Add(teamsInGame[orgInitCounter]);
            orgInGame.orgFinanzen.Add(financesInGame[orgInitCounter]);
            orgInGame.orgAkademie.Add(academiesInGame[orgInitCounter]);
            orgInGame.orgMerchandise.Add(merchandisesInGame[orgInitCounter]);
            orgsInGame.Add(orgInGame);

            orgInitCounter++;
        }

    }
}