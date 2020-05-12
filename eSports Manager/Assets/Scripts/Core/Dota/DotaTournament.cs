using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotaTournament : MonoBehaviour
{

    public string tournamentName;
    public TournamentType tournamentType;
    public string tournamentLocation;

    public int amountTeamsInTournament;
    public Team[] teamsInTournament;

    public enum TournamentType { International , Major , Minor , Charity};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
