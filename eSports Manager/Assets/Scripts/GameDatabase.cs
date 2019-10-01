using System;
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

    public List<Player> playersInGame;
    public List<Team> teamsInGame;
    public List<Contract> contractsInGame;

    // Start is called before the first frame update
    void Start()
    {
        SetupGameData();
    }

    private void SetupGameData()
    {
        int contractInitCounter = 0;

        foreach (Team team in teamsToAdd)
        {
            Team teamInGame = Instantiate(team, teamSpawnerParent.transform);
            teamsInGame.Add(teamInGame);
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
            int randomContractInt = UnityEngine.Random.Range(0, contractsInGame.Count);
            Player playerInGame = Instantiate(player, playerSpawnerParent.transform);
            playerInGame.careerContracts.SetValue(contractsInGame[randomContractInt], 0);
            playersInGame.Add(playerInGame);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
