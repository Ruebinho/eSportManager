using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamGenerator : MonoBehaviour
{
    private string[] teamNameList;

    private string teamOGName;
    private float teamOGRuhm;
    private Team[] teamOGTeams;
    private Finanzen teamOGFinanzen;


    public Team createTeamOG()
    {
        Team teamOG = new Team();

        return teamOG;
    }

}
