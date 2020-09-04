using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPCRankings : MonoBehaviour
{
    public DPCTeamPoints dpcteampointsPrefab;
    public List<DPCTeamPoints> dpcTeamPointsArray;

    public Utility util;
    public List<Team> listInGameTeams = null;
    
    // Start is called before the first frame update
    void Start()
    {
        util = FindObjectOfType<Utility>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateDPCRankingEntries()
    {
        Debug.Log("-----Instatiating DPC Entries------------------------------");

        listInGameTeams = util.getInGameTeamList();

        foreach (Team team in listInGameTeams)
        {
            if (team != null && team.teamGame == GlobalGameParameters.Game.DotA2)
            {
                Debug.Log(team.teamName);
                dpcteampointsPrefab.team = team;
                dpcteampointsPrefab.points = 0f;

                dpcTeamPointsArray.Add(Instantiate(dpcteampointsPrefab));
            }
        }

        Debug.Log("-----Instatiating DPC Entries--DONE------------------------");
    }
}
