using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public List<Player> playerInGameList;
    public List<Team> teamInGameList;


    public PlayersInGame pig;
    public TeamsInGame tig;

    // Start is called before the first frame update
    void Start()
    {
        pig = FindObjectOfType<PlayersInGame>();
        tig = FindObjectOfType<TeamsInGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateInGamePlayerList()
    {
        Transform[] allChildren = pig.transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            playerInGameList.Add(child.GetComponent<Player>());
        }
    }

    public List<Player> getInGamePlayerList()
    {
        updateInGamePlayerList();
        return playerInGameList;
    }

    public void updateInGameTeamList()
    {
        Team[] allChildren = tig.transform.GetComponentsInChildren<Team>();
        foreach (Team child in allChildren)
        {
            Debug.Log("Team found");
            Debug.Log(child.GetComponent<Team>().teamName);
            teamInGameList.Add(child.GetComponent<Team>());
        }
    }

    public List<Team> getInGameTeamList()
    {
        updateInGameTeamList();
        return teamInGameList;
    }
}
