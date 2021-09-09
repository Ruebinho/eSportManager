using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotaTournament : MonoBehaviour
{

    public string tournamentName;
    public TournamentType tournamentType;
    public string tournamentLocation;

    public int startDay;
    public int startMonth;
    public int startYear;

    public int endDay;
    public int endMonth;
    public int endYear;

    public DotaTournament dotaTournamentQualifier;

    public int amountTeamsInTournament;
    public Team[] teamsInTournament;

    public enum TournamentType { International , Major , Minor , Qualifier, Charity };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
