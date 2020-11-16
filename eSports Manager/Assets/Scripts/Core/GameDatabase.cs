using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using System.Threading;

public class GameDatabase : MonoBehaviour
{
    public bool addCustomTeams = true;

    public int minimumPlayerSpawnerFriends = 0;
    public Player[] playersToAdd;
    public GameObject playerSpawnerParent;

    public int minimumTeamSpawnerFriends = 0;
    public Team[] teamsToAdd;
    public GameObject teamSpawnerParent;

    public int minimumPlayerContractSpawnerFriends = 0;
    public PlayerContract[] contractsToAdd;
    public GameObject contractSpawnerParent;

    public int minimumOrgSpawnerFriends = 0;
    public Organization[] orgsToAdd;
    public GameObject orgSpawnerParent;

    public Sponsor[] sponsorsToAdd;
    public GameObject sponsorSpawnerParent;

    public int minimumFinanceSpawnerFriends = 0;
    public Finanzen[] financesToAdd;
    public GameObject financesSpawnerParent;

    public int minimumAcademySpawnerFriends = 0;
    public Akademie[] academiesToAdd;
    public GameObject academySpawnerParent;

    public int minimumMerchSpawnerFriends = 0;
    public Merch[] merchandisesToAdd;
    public GameObject merchandiseSpawnerParent;

    public StaffMember[] staffMembersToAdd;
    public GameObject staffSpawnerParent;

    public List<Player> playersInGame;
    public List<Team> teamsInGame;
    public List<PlayerContract> contractsInGame;
    public List<Organization> orgsInGame;
    public List<Finanzen> financesInGame;
    public List<Sponsor> sponsorsInGame;
    public List<Akademie> academiesInGame;
    public List<Merch> merchandisesInGame;
    public List<StaffMember> staffMembersInGame;
    public List<StaffContract> staffMemberContractsInGame;

    public int randomCharactersToCreate = 10;
    public CharacterGenerator charGen;
    public GameDataInit gdinit;

    // Start is called before the first frame update
    void Start()
    {
        charGen = FindObjectOfType<CharacterGenerator>();
        gdinit = FindObjectOfType<GameDataInit>();
    }

    public void SetupGameData()
    {
        SetupCustomFriendsGameData();

        int contractInitCounter = 0;
        int orgInitCounter = 0;
        int financeInitCounter = 0;

        foreach (Team team in teamsToAdd)
        {
            //Debug.Log(team.teamName);
            if (team.teamIsActive)
            {
                Team teamInGame = Instantiate(team, teamSpawnerParent.transform);
                teamsInGame.Add(teamInGame);
            }
        }

        foreach (Merch merch in merchandisesToAdd)
        {
            if (merch.merchIsActive)
            {
                Merch merchInGame = Instantiate(merch, merchandiseSpawnerParent.transform);
                merchandisesInGame.Add(merchInGame);
            }
        }

        foreach (Sponsor sponsor in sponsorsToAdd)
        {
            Sponsor sponsorInGame = Instantiate(sponsor, sponsorSpawnerParent.transform);
            sponsorsInGame.Add(sponsorInGame);
        }

        foreach (Akademie academy in academiesToAdd)
        {
            if (academy.akademieIsActive)
            {
                Akademie academyInGame = Instantiate(academy, academySpawnerParent.transform);
                academiesInGame.Add(academyInGame);
            }
        }

        foreach (Finanzen finance in financesToAdd)
        {
            if (finance.finanzenIsActive)
            {
                Finanzen financeInGame = Instantiate(finance, financesSpawnerParent.transform);
                // TODO fix financeInGame.sponsors[0] = sponsorsInGame[financeInitCounter];
                //Debug.Log(financeInGame.name);
                financesInGame.Add(financeInGame);
            }

            financeInitCounter++;
        }

        foreach (PlayerContract contract in contractsToAdd)
        {
            if (contract.playerContractIsActive)
            {
                PlayerContract contractInGame = Instantiate(contract, contractSpawnerParent.transform);
                contractInGame.teamPlayerIsContractedTo = teamsInGame[contractInitCounter];
                contractsInGame.Add(contractInGame);
            }

            contractInitCounter++;
        }

        foreach (Player player in playersToAdd)
        {
            if (player.playerIsActive)
            {
                Player playerInGame = Instantiate(player, playerSpawnerParent.transform);
                playerInGame.careerContracts.Add(contractsInGame[player.initialContractInt]);
                playersInGame.Add(playerInGame);
            }
        }

        foreach (Organization org in orgsToAdd)
        {
            if (org.orgIsActive)
            {
                Organization orgInGame = Instantiate(org, orgSpawnerParent.transform);
                orgInGame.orgTeams.Add(teamsInGame[orgInitCounter]);
                orgInGame.orgFinanzen.Add(financesInGame[orgInitCounter]);
                orgInGame.orgAkademie.Add(academiesInGame[orgInitCounter]);
                orgInGame.orgMerchandise.Add(merchandisesInGame[orgInitCounter]);
                orgsInGame.Add(orgInGame);
            }

            orgInitCounter++;
        }

        AddRandomGeneratedPlayers();
        AddRandomGeneratedStaff();

        gdinit = FindObjectOfType<GameDataInit>();
        gdinit.setGDBsetup();
    }

    private void SetupCustomFriendsGameData()
    {
        if (addCustomTeams)
        {
            return;
        }
        else
        {
            SetOrgInactive(0);
            SetOrgInactive(1);
        }

    }

    private void SetOrgInactive(int instantiationArrayNumber)
    {
        orgsToAdd[instantiationArrayNumber].orgIsActive = false;
        teamsToAdd[instantiationArrayNumber].teamIsActive = false;
        merchandisesToAdd[instantiationArrayNumber].merchIsActive = false;
        financesToAdd[instantiationArrayNumber].finanzenIsActive = false;
        contractsToAdd[instantiationArrayNumber].playerContractIsActive = false;
        academiesToAdd[instantiationArrayNumber].akademieIsActive = false;
        playersToAdd[0].playerIsActive = false;
        playersToAdd[1].playerIsActive = false;
        playersToAdd[2].playerIsActive = false;
        playersToAdd[3].playerIsActive = false;
        playersToAdd[4].playerIsActive = false;
        playersToAdd[5].playerIsActive = false;
        playersToAdd[6].playerIsActive = false;
        playersToAdd[7].playerIsActive = false;
        playersToAdd[8].playerIsActive = false;
        playersToAdd[9].playerIsActive = false;
    }

    private void AddRandomGeneratedStaff()
    {
        int randomStaffToCreate = 20;

        for (int i = 0; i < randomStaffToCreate; i++)
        {
            StaffMember staffMemberToInstantiate = charGen.GenerateStaffMember();
            StaffMember staffMemberInGame = Instantiate(staffMemberToInstantiate, staffSpawnerParent.transform);
            staffMembersInGame.Add(staffMemberInGame);
        }
    }

    private void AddRandomGeneratedPlayers()
    {
        if(charGen == null)
        {
            charGen = FindObjectOfType<CharacterGenerator>();
        }

        //Debug.Log("Rnadom player get createsd");
        //Debug.Log(charGen);
        randomCharactersToCreate = charGen.nicknameList.Length - 1;

        for (int i = 0; i < randomCharactersToCreate; i++)
        {
            Player playerToInstantiate = charGen.GeneratePlayer();
            Player playerInGame = Instantiate(playerToInstantiate, playerSpawnerParent.transform);
            playersInGame.Add(playerInGame);
        }
    }
}
