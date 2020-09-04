using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotaTournamentGenerator : MonoBehaviour
{
    DotaTournament dotaTournamentPrefab = null;

    public int startDay;
    public int startMonth;
    public int startYear;

    public int endDay;
    public int endMonth;
    public int endYear;

    public GameCoreLogic gamecoreLogic = null;
    public GlobalGameParameters ggp;
    public Calendar cal;
    public GameDatabase gdb;

    // Start is called before the first frame update
    void Start()
    {
        gamecoreLogic = FindObjectOfType<GameCoreLogic>();
        ggp = FindObjectOfType<GlobalGameParameters>();
        cal = FindObjectOfType<Calendar>();
        gdb = FindObjectOfType<GameDatabase>();
    }

    public DotaTournament GenerateDotaTorunament()
    {

        FindTournamentDate();

        DotaTournament dotaTournament = Instantiate(dotaTournamentPrefab);

        dotaTournament.tournamentName = "ESL One Cologne";
        dotaTournament.tournamentLocation = "Cologne";
        dotaTournament.tournamentType = DotaTournament.TournamentType.Charity;

        dotaTournament.amountTeamsInTournament = FindTeamAmountFromTournamentType(dotaTournament.tournamentType);
        AddDeservingTeamsToTournamentPool(dotaTournament);

        dotaTournament.startDay = startDay;
        dotaTournament.startMonth = startMonth;
        dotaTournament.startYear = startYear;

        dotaTournament.endDay = endDay;
        dotaTournament.endMonth = endMonth;
        dotaTournament.endYear = endYear;

        return dotaTournament;
    }

    private void AddDeservingTeamsToTournamentPool(DotaTournament dotaTournament)
    {
        List<Team> teamsAdded = new List<Team>();

        for (int i = 0; i < dotaTournament.amountTeamsInTournament; i++)
        {
            int teamNumber = i;

            if (teamNumber >= 1)
            {
                int teamRandom = UnityEngine.Random.Range(0, gdb.teamsInGame.Count);

            } else
            {
                int teamRandom = UnityEngine.Random.Range(0, gdb.teamsInGame.Count);
                Team randomTeam = gdb.teamsInGame[teamRandom];
                teamsAdded.Add(randomTeam);
            }

        }
    }

    private int FindTeamAmountFromTournamentType(DotaTournament.TournamentType tournamentType)
    {
        if (tournamentType == DotaTournament.TournamentType.Charity)
        {
            return 8;
        }

        if (tournamentType == DotaTournament.TournamentType.Minor)
        {
            return 12;
        }

        if (tournamentType == DotaTournament.TournamentType.Major)
        {
            return 16;
        }

        if (tournamentType == DotaTournament.TournamentType.International)
        {
            return 18;
        }

        return 10;
    }

    private void FindTournamentDate()
    {
        bool nextyearBool = false;

        startDay = 1;

        if (cal.currentMonth < 12)
        {
            startMonth = cal.currentMonth + 1;
        }
        else
        {
            startMonth = 1;
            nextyearBool = true;
        }

        if (nextyearBool)
        {
            startYear = cal.currentYear + 1;
        }
        else
        {
            startYear = cal.currentYear;
        }
    }
}
