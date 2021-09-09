using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotA2TournamentScheduleGenerator : MonoBehaviour
{
    int lastYearOfGeneration = 2000;
    [SerializeField] public Game game = null;
    [SerializeField] public GameTournamentGenerator gtg = null;

    public int seasonStartDay = 0;
    public int seasonStartMonth = 0;

    public Calendar calendar = null;

    public int amountMajors = 5;
    public int amountMinors = 5;
    public int amountCharity = 2;
    public int amountInternational = 1;

    public int amountTournamentDPC = 1;

    public DotaTournament[] dpcCalendarSchedule = null;

    DotaTournament dotaTournamentinternational = null;
    int AmountInternationalRegionalQualifiers = 6;
    public DotaTournament[] internationalOpenQualifiers = new DotaTournament[6];
    public DotaTournament[] internationalRegionalQualifiers = new DotaTournament[6];
    DotaTournament xy = null;

    // Start is called before the first frame update
    void Start()
    {
        gtg = FindObjectOfType<GameTournamentGenerator>();
        calendar = FindObjectOfType<Calendar>();



        StartDotaTournamentScheduleGeneratorSetup();
    }

    public void StartDotaTournamentScheduleGeneratorSetup()
    {
        seasonStartDay = game.seasonStartDay;
        seasonStartMonth = game.seasonStartMonth;

        amountTournamentDPC = CalculateTotalTournamentAmountForYear();

        dpcCalendarSchedule = new DotaTournament[amountTournamentDPC];

        if (!(lastYearOfGeneration == calendar.currentYear))
        {
            SetupTournamentSchedule();
        }
    }

    private int CalculateTotalTournamentAmountForYear()
    {
        return amountMajors + amountMinors + amountInternational;
    }

    public void SetupTournamentSchedule()
    {
        int internationalEndDate = DecideInternationalEndDate();
        CreateDPCTournamentSchedule(internationalEndDate);
    }

    private int DecideInternationalEndDate()
    {
        int weekdayFirstOfAUGNextYear = calendar.CheckWeekDayFromFirstOfAUGNextYear();

        // result should be a sunday
        int additionCalculation = 28 - weekdayFirstOfAUGNextYear;

        int endDateDayInternational = 1 + additionCalculation;

        return endDateDayInternational;
    }

    public void CreateDPCTournamentSchedule(int internationalEndDate)
    {
        // Setup Tournaments in reverse order from the international to first tournament

        SetupTournamentInternational(internationalEndDate);
    }

    private void SetupTournamentInternational(int internationalEndDate)
    {
        dotaTournamentinternational = gtg.GenerateDotaTournament();

        string tName = "The International";
        string tLocation = "Cologne";
        DotaTournament.TournamentType tType = DotaTournament.TournamentType.International;

        int tAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tEndDay = internationalEndDate;
        int tEndMonth = 8;
        int tEndYear = calendar.currentYear;

        int tStartDay = tEndDay - 11;
        int tStartMonth = tEndMonth;
        int tStartYear = tEndYear;

        gtg.SetupTournamentData(dotaTournamentinternational, tName, tLocation, tType, tAmountTeams);
        gtg.SetupTournamentDateData(dotaTournamentinternational, tStartDay, tStartMonth, tStartYear, tEndDay, tEndMonth, tEndYear);
        SetupQualifiersForTournament(dotaTournamentinternational);

        DotaTournament theInternational = dotaTournamentinternational;

        dpcCalendarSchedule[amountTournamentDPC-1] = theInternational;
    }

    private void SetupQualifiersForTournament(DotaTournament dotaTournamentinternational)
    {
        for (int i = 0; i < AmountInternationalRegionalQualifiers; i++)
        {
            internationalRegionalQualifiers[i] = gtg.GenerateDotaTournament();
        }

        #region EU Quals
        //European Qualifiers
        string tEUQName = "The International EU Qualifiers";
        string tEUQLocation = "Porz";
        DotaTournament.TournamentType tEUQType = DotaTournament.TournamentType.Qualifier;

        int tEUQAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tEUQEndDay = GenerateTIQualsStartDates(dotaTournamentinternational, "EU");
        int tEUQEndMonth = 8;
        int tEUQEndYear = calendar.currentYear;

        int tEUQStartDay = tEUQEndDay - 11;
        int tEUQStartMonth = tEUQEndMonth;
        int tEUQStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalRegionalQualifiers[0], tEUQName, tEUQLocation, tEUQType, tEUQAmountTeams);
        gtg.SetupTournamentDateData(internationalRegionalQualifiers[0], tEUQStartDay, tEUQStartMonth, tEUQStartYear, tEUQEndDay, tEUQEndMonth, tEUQEndYear);

        #endregion

        #region China Quals
        //China Qualifiers
        string tAQName = "The International CH Qualifiers";
        string tAQLocation = "Porz";
        DotaTournament.TournamentType tAQType = DotaTournament.TournamentType.Qualifier;

        int tAQAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tAQEndDay = GenerateTIQualsStartDates(dotaTournamentinternational, "CH");
        int tAQEndMonth = 8;
        int tAQEndYear = calendar.currentYear;

        int tAQStartDay = tEUQEndDay - 11;
        int tAQStartMonth = tEUQEndMonth;
        int tAQStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalRegionalQualifiers[1], tAQName, tAQLocation, tAQType, tAQAmountTeams);
        gtg.SetupTournamentDateData(internationalRegionalQualifiers[1], tAQStartDay, tAQStartMonth, tAQStartYear, tAQEndDay, tAQEndMonth, tAQEndYear);

        #endregion

        #region NA Quals
        //NA Qualifiers
        string tNAName = "The International NA Qualifiers";
        string tNALocation = "Porz";
        DotaTournament.TournamentType tNAType = DotaTournament.TournamentType.Qualifier;

        int tNAAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tNAEndDay = GenerateTIQualsStartDates(dotaTournamentinternational, "NA");
        int tNAEndMonth = 8;
        int tNAEndYear = calendar.currentYear;

        int tNAStartDay = tEUQEndDay - 11;
        int tNAStartMonth = tEUQEndMonth;
        int tNAStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalRegionalQualifiers[2], tNAName, tNALocation, tNAType, tNAAmountTeams);
        gtg.SetupTournamentDateData(internationalRegionalQualifiers[2], tNAStartDay, tNAStartMonth, tNAStartYear, tNAEndDay, tNAEndMonth, tNAEndYear);

        #endregion

        #region SA Quals
        //SA Qualifiers
        string tSAName = "The International SA Qualifiers";
        string tSALocation = "Porz";
        DotaTournament.TournamentType tSAType = DotaTournament.TournamentType.Qualifier;

        int tSAAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tSAEndDay = GenerateTIQualsStartDates(dotaTournamentinternational, "SA");
        int tSAEndMonth = 8;
        int tSAEndYear = calendar.currentYear;

        int tSAStartDay = tEUQEndDay - 11;
        int tSAStartMonth = tEUQEndMonth;
        int tSAStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalRegionalQualifiers[3], tSAName, tSALocation, tSAType, tSAAmountTeams);
        gtg.SetupTournamentDateData(internationalRegionalQualifiers[3], tSAStartDay, tSAStartMonth, tSAStartYear, tSAEndDay, tSAEndMonth, tSAEndYear);

        #endregion

        #region CIS Quals
        //CIS Qualifiers
        string tCISQName = "The International CIS Qualifiers";
        string tCISQLocation = "Porz";
        DotaTournament.TournamentType tCISQType = DotaTournament.TournamentType.Qualifier;

        int tCISQAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tCISQEndDay = GenerateTIQualsStartDates(dotaTournamentinternational, "CIS");
        int tCISQEndMonth = 8;
        int tCISQEndYear = calendar.currentYear;

        int tCISQStartDay = tEUQEndDay - 11;
        int tCISQStartMonth = tEUQEndMonth;
        int tCISQStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalRegionalQualifiers[4], tCISQName, tCISQLocation, tCISQType, tCISQAmountTeams);
        gtg.SetupTournamentDateData(internationalRegionalQualifiers[4], tCISQStartDay, tCISQStartMonth, tCISQStartYear, tCISQEndDay, tCISQEndMonth, tCISQEndYear);

        #endregion

        #region SEA Quals
        //CIS Qualifiers
        string tSEAQName = "The International SEA Qualifiers";
        string tSEAQLocation = "Porz";
        DotaTournament.TournamentType tSEAQType = DotaTournament.TournamentType.Qualifier;

        int tSEAQAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tSEAQEndDay = GenerateTIQualsStartDates(dotaTournamentinternational, "SEA");
        int tSEAQEndMonth = 8;
        int tSEAQEndYear = calendar.currentYear;

        int tSEAQStartDay = tEUQEndDay - 11;
        int tSEAQStartMonth = tEUQEndMonth;
        int tSEAQStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalRegionalQualifiers[5], tSEAQName, tSEAQLocation, tSEAQType, tSEAQAmountTeams);
        gtg.SetupTournamentDateData(internationalRegionalQualifiers[5], tSEAQStartDay, tSEAQStartMonth, tSEAQStartYear, tSEAQEndDay, tSEAQEndMonth, tSEAQEndYear);

        #endregion
    }

    private int GenerateTIQualsStartDates(DotaTournament dotaTournamentinternational, string Region)
    {
        switch (Region)
        {
            case "EU":
                return dotaTournamentinternational.endDay - 11;
            case "CH":
                return dotaTournamentinternational.endDay - 11;
            case "NA":
                return dotaTournamentinternational.endDay - 11;
            case "SA":
                return dotaTournamentinternational.endDay - 15;
            case "SEA":
                return dotaTournamentinternational.endDay - 15;
            case "CIS":
                return dotaTournamentinternational.endDay - 15;
            default:
                return dotaTournamentinternational.endDay;
        }
            
    }

    private DotaTournament CreateRegionalQualsForTI(DotaTournament dotaTournament)
    {
        return null;
    }
}
