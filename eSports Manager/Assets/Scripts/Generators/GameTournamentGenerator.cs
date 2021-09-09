using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTournamentGenerator : MonoBehaviour
{
    public DotaTournamentGenerator dtg = null;

    public DotaTournament dotaTournamentPrefab;

    public string tName = "xxx";
    public DotaTournament.TournamentType tType = DotaTournament.TournamentType.International;
    public string tLocation = "xxx";
    public int tStartDay = 01;
    public int tStartMonth = 12;
    public int tStartYear = 2000;
    public int tEndDay = 31;
    public int tEndMonth = 12;
    public int tEndYear = 2000;
    public int tAmountTeamsInTournament = 2;

    // Start is called before the first frame update
    void Start()
    {
        dtg = gameObject.GetComponent<DotaTournamentGenerator>();
    }

    // Generate different game tournaments

    public DotaTournament GenerateDotaTournament()
    {
        /*
        DotaTournament dotaTournamentHull = Instantiate(dotaTournamentPrefab);

        dotaTournamentHull.tournamentName = tName;
        dotaTournamentHull.tournamentType = tType;
        dotaTournamentHull.tournamentLocation = tLocation;
        dotaTournamentHull.startDay = tStartDay;
        dotaTournamentHull.startMonth = tStartMonth;
        dotaTournamentHull.startYear = tStartYear;
        dotaTournamentHull.endDay = tEndDay;
        dotaTournamentHull.endMonth = tEndMonth;
        dotaTournamentHull.endYear = tEndYear;
        dotaTournamentHull.amountTeamsInTournament = tAmountTeamsInTournament;

        return dotaTournamentHull;
        */

        DotaTournament dotaTournament = Instantiate(dotaTournamentPrefab);

        return dotaTournament;
    }

    public void SetupTournamentDateData(DotaTournament dotaTournament, int tStartDay, int tStartMonth, int tStartYear, int tEndDay, int tEndMonth, int tEndYear)
    {
        dotaTournament.startDay = tStartDay;
        dotaTournament.startMonth = tStartMonth;
        dotaTournament.startYear = tStartYear;

        dotaTournament.endDay = tEndDay;
        dotaTournament.endMonth = tEndMonth;
        dotaTournament.endYear = tEndYear;
    }

    public void SetupTournamentData(DotaTournament dotaTournament,
                                     string tName,
                                     string tLocation,
                                     DotaTournament.TournamentType tType,
                                     int tAmountTeams)
    {
        dotaTournament.name = tName;
        dotaTournament.tournamentLocation = tLocation;
        dotaTournament.tournamentType = tType;

        dotaTournament.amountTeamsInTournament = tAmountTeams;
        
        //FindTeamAmountFromTournamentType(dotaTournament.tournamentType);
        //AddDeservingTeamsToTournamentPool(dotaTournament); 
    }


}
