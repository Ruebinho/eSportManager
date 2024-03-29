﻿using System;
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

    public GeographicalDefinition geodef = null;

    public Region[] regionMajors = new Region[5];
    public Region[] regionMinors = new Region[5];

    // Start is called before the first frame update
    void Start()
    {
        gtg = FindObjectOfType<GameTournamentGenerator>();
        calendar = FindObjectOfType<Calendar>();
        geodef = FindObjectOfType<GeographicalDefinition>();


        //TODO: implement in calendar for every year generation
        InitiateRegionArrays();
        StartDotaTournamentScheduleGeneratorSetup();
    }

    private void InitiateRegionArrays()
    {
        regionMajors[0] = geodef.regionsInGame[0];
        regionMajors[1] = geodef.regionsInGame[1];
        regionMajors[2] = geodef.regionsInGame[2];
        regionMajors[3] = geodef.regionsInGame[3];
        regionMajors[4] = geodef.regionsInGame[5];

        regionMinors[0] = geodef.regionsInGame[0];
        regionMinors[1] = geodef.regionsInGame[1];
        regionMinors[2] = geodef.regionsInGame[2];
        regionMinors[3] = geodef.regionsInGame[3];
        regionMinors[4] = geodef.regionsInGame[4];
    }

    public void StartDotaTournamentScheduleGeneratorSetup()
    {
        seasonStartDay = game.seasonStartDay;
        seasonStartMonth = game.seasonStartMonth;

        amountTournamentDPC = CalculateTotalTournamentAmountForYear();

        dpcCalendarSchedule = new DotaTournament[amountTournamentDPC];

        if (!(lastYearOfGeneration == calendar.currentYear))
        {
            lastYearOfGeneration = calendar.currentYear;
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
        int weekdayFirstOfAUGNextYear = calendar.CheckWeekDayOfFirstOfAUGNextYear();

        // result should be a sunday
        int additionCalculation = 28 - weekdayFirstOfAUGNextYear;

        int endDateDayInternational = 1 + additionCalculation;

        return endDateDayInternational;
    }

    public void CreateDPCTournamentSchedule(int internationalEndDate)
    {
        // Setup Tournaments in reverse order from the international to first tournament

        SetupTournamentInternational(internationalEndDate);
        CreateRegionalQualsForTI();
        CreateMajorMinorSchedule();
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
        int tEndYear = calendar.currentYear + 1;

        int tStartDay = tEndDay - 10;
        int tStartMonth = tEndMonth;
        int tStartYear = tEndYear;

        gtg.SetupTournamentData(dotaTournamentinternational, tName, tLocation, tType, tAmountTeams);
        gtg.SetupTournamentDateData(dotaTournamentinternational, tStartDay, tStartMonth, tStartYear, tEndDay, tEndMonth, tEndYear);
        SetupQualifiersForTournament(dotaTournamentinternational);

        DotaTournament theInternational = dotaTournamentinternational;

        dpcCalendarSchedule[amountTournamentDPC - 1] = theInternational;
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
        int tEUQEndMonth = 7;
        int tEUQEndYear = calendar.currentYear+1;

        int tEUQStartDay = tEUQEndDay - 3;
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
        int tAQEndMonth = 7;
        int tAQEndYear = calendar.currentYear+1;

        int tAQStartDay = tAQEndDay - 3;
        int tAQStartMonth = tAQEndMonth;
        int tAQStartYear = tAQEndYear;

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
        int tNAEndMonth = 7;
        int tNAEndYear = calendar.currentYear+1;

        int tNAStartDay = tNAEndDay - 3;
        int tNAStartMonth = tNAEndMonth;
        int tNAStartYear = tNAEndYear;

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
        int tSAEndMonth = 7;
        int tSAEndYear = calendar.currentYear+1;

        int tSAStartDay = tSAEndDay - 3;
        int tSAStartMonth = tSAEndMonth;
        int tSAStartYear = tSAEndYear;

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
        int tCISQEndMonth = 7;
        int tCISQEndYear = calendar.currentYear+1;

        int tCISQStartDay = tCISQEndDay - 3;
        int tCISQStartMonth = tCISQEndMonth;
        int tCISQStartYear = tCISQEndYear;

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
        int tSEAQEndMonth = 7;
        int tSEAQEndYear = calendar.currentYear+1;

        int tSEAQStartDay = tSEAQEndDay - 3;
        int tSEAQStartMonth = tSEAQEndMonth;
        int tSEAQStartYear = tSEAQEndYear;

        gtg.SetupTournamentData(internationalRegionalQualifiers[5], tSEAQName, tSEAQLocation, tSEAQType, tSEAQAmountTeams);
        gtg.SetupTournamentDateData(internationalRegionalQualifiers[5], tSEAQStartDay, tSEAQStartMonth, tSEAQStartYear, tSEAQEndDay, tSEAQEndMonth, tSEAQEndYear);

        #endregion
    }

    private int GenerateTIQualsStartDates(DotaTournament dotaTournamentinternational, string Region)
    {
        switch (Region)
        {
            case "EU":
                return calendar.CalculateDaySubtractingDays(dotaTournamentinternational.startYear, dotaTournamentinternational.startMonth, dotaTournamentinternational.startDay, 32);
                //return dotaTournamentinternational.startDay - 32;
            case "CH":
                return calendar.CalculateDaySubtractingDays(dotaTournamentinternational.startYear, dotaTournamentinternational.startMonth, dotaTournamentinternational.startDay, 32);
                //return dotaTournamentinternational.startDay - 32;
            case "NA":
                return calendar.CalculateDaySubtractingDays(dotaTournamentinternational.startYear, dotaTournamentinternational.startMonth, dotaTournamentinternational.startDay, 32);
                //return dotaTournamentinternational.startDay - 32;
            case "SA":
                return calendar.CalculateDaySubtractingDays(dotaTournamentinternational.startYear, dotaTournamentinternational.startMonth, dotaTournamentinternational.startDay, 36);
                //return dotaTournamentinternational.startDay - 36;
            case "SEA":
                return calendar.CalculateDaySubtractingDays(dotaTournamentinternational.startYear, dotaTournamentinternational.startMonth, dotaTournamentinternational.startDay, 36);
                //return dotaTournamentinternational.startDay - 36;
            case "CIS":
                return calendar.CalculateDaySubtractingDays(dotaTournamentinternational.startYear, dotaTournamentinternational.startMonth, dotaTournamentinternational.startDay, 36);
                //return dotaTournamentinternational.startDay - 36;
            default:
                return dotaTournamentinternational.endDay;
        }

    }

    private void CreateRegionalQualsForTI()
    {
        Debug.Log("GTG EU OQ");
        for (int i = 0; i < AmountInternationalRegionalQualifiers; i++)
        {
            internationalOpenQualifiers[i] = gtg.GenerateDotaTournament();
        }

        #region EU Quals
        //European Qualifiers
        string tEUQName = "The International EU Open Qualifiers";
        string tEUQLocation = "Porz";
        DotaTournament.TournamentType tEUQType = DotaTournament.TournamentType.Qualifier;

        int tEUQAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tEUQEndDay = internationalRegionalQualifiers[3].startDay - 1;
        int tEUQEndMonth = internationalRegionalQualifiers[3].endMonth;
        int tEUQEndYear = internationalRegionalQualifiers[0].endYear;

        int tEUQStartDay = tEUQEndDay - 3;
        int tEUQStartMonth = tEUQEndMonth;
        int tEUQStartYear = tEUQEndYear;

        Debug.Log("GTG EU OQ");
        gtg.SetupTournamentData(internationalOpenQualifiers[0], tEUQName, tEUQLocation, tEUQType, tEUQAmountTeams);
        gtg.SetupTournamentDateData(internationalOpenQualifiers[0], tEUQStartDay, tEUQStartMonth, tEUQStartYear, tEUQEndDay, tEUQEndMonth, tEUQEndYear);

        #endregion

        #region China Quals
        //China Qualifiers
        string tAQName = "The International CH Open Qualifiers";
        string tAQLocation = "Porz";
        DotaTournament.TournamentType tAQType = DotaTournament.TournamentType.Qualifier;

        int tAQAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tAQEndDay = internationalRegionalQualifiers[3].startDay - 1;
        int tAQEndMonth = internationalRegionalQualifiers[3].endMonth;
        int tAQEndYear = internationalRegionalQualifiers[1].endYear;

        int tAQStartDay = tEUQEndDay - 3;
        int tAQStartMonth = tEUQEndMonth;
        int tAQStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalOpenQualifiers[1], tAQName, tAQLocation, tAQType, tAQAmountTeams);
        gtg.SetupTournamentDateData(internationalOpenQualifiers[1], tAQStartDay, tAQStartMonth, tAQStartYear, tAQEndDay, tAQEndMonth, tAQEndYear);

        #endregion

        #region NA Quals
        //NA Qualifiers
        string tNAName = "The International NA Open Qualifiers";
        string tNALocation = "Porz";
        DotaTournament.TournamentType tNAType = DotaTournament.TournamentType.Qualifier;

        int tNAAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tNAEndDay = internationalRegionalQualifiers[3].startDay - 1;
        int tNAEndMonth = internationalRegionalQualifiers[3].endMonth;
        int tNAEndYear = internationalRegionalQualifiers[2].endYear;

        int tNAStartDay = tEUQEndDay - 3;
        int tNAStartMonth = tEUQEndMonth;
        int tNAStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalOpenQualifiers[2], tNAName, tNALocation, tNAType, tNAAmountTeams);
        gtg.SetupTournamentDateData(internationalOpenQualifiers[2], tNAStartDay, tNAStartMonth, tNAStartYear, tNAEndDay, tNAEndMonth, tNAEndYear);

        #endregion

        #region SA Quals
        //SA Qualifiers
        string tSAName = "The International SA Open Qualifiers";
        string tSALocation = "Porz";
        DotaTournament.TournamentType tSAType = DotaTournament.TournamentType.Qualifier;

        int tSAAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tSAEndDay = internationalRegionalQualifiers[3].startDay - 1;
        int tSAEndMonth = internationalRegionalQualifiers[3].endMonth;
        int tSAEndYear = internationalRegionalQualifiers[3].endYear;

        int tSAStartDay = tEUQEndDay - 3;
        int tSAStartMonth = tEUQEndMonth;
        int tSAStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalOpenQualifiers[3], tSAName, tSALocation, tSAType, tSAAmountTeams);
        gtg.SetupTournamentDateData(internationalOpenQualifiers[3], tSAStartDay, tSAStartMonth, tSAStartYear, tSAEndDay, tSAEndMonth, tSAEndYear);

        #endregion

        #region CIS Quals
        //CIS Qualifiers
        string tCISQName = "The International CIS Open Qualifiers";
        string tCISQLocation = "Porz";
        DotaTournament.TournamentType tCISQType = DotaTournament.TournamentType.Qualifier;

        int tCISQAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tCISQEndDay = internationalRegionalQualifiers[3].startDay - 1;
        int tCISQEndMonth = internationalRegionalQualifiers[3].endMonth;
        int tCISQEndYear = internationalRegionalQualifiers[4].endYear;

        int tCISQStartDay = tEUQEndDay - 3;
        int tCISQStartMonth = tEUQEndMonth;
        int tCISQStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalOpenQualifiers[4], tCISQName, tCISQLocation, tCISQType, tCISQAmountTeams);
        gtg.SetupTournamentDateData(internationalOpenQualifiers[4], tCISQStartDay, tCISQStartMonth, tCISQStartYear, tCISQEndDay, tCISQEndMonth, tCISQEndYear);

        #endregion

        #region SEA Quals
        //CIS Qualifiers
        string tSEAQName = "The International SEA Open Qualifiers";
        string tSEAQLocation = "Porz";
        DotaTournament.TournamentType tSEAQType = DotaTournament.TournamentType.Qualifier;

        int tSEAQAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tSEAQEndDay = internationalRegionalQualifiers[3].startDay - 1;
        int tSEAQEndMonth = internationalRegionalQualifiers[3].endMonth;
        int tSEAQEndYear = internationalRegionalQualifiers[5].endYear;

        int tSEAQStartDay = tEUQEndDay - 3;
        int tSEAQStartMonth = tEUQEndMonth;
        int tSEAQStartYear = tEUQEndYear;

        gtg.SetupTournamentData(internationalOpenQualifiers[5], tSEAQName, tSEAQLocation, tSEAQType, tSEAQAmountTeams);
        gtg.SetupTournamentDateData(internationalOpenQualifiers[5], tSEAQStartDay, tSEAQStartMonth, tSEAQStartYear, tSEAQEndDay, tSEAQEndMonth, tSEAQEndYear);

        #endregion
    }

    private void CreateMajorMinorSchedule()
    {

        Debug.Log("i is: 10");
        for (int i = dpcCalendarSchedule.Length - 2; i > -1; i--)
        {
            Debug.Log("DPC Cal i is:" + i);
            GenerateDPCCalendarScheduleTournamentInPosition(i);
        }

    }

    private void GenerateDPCCalendarScheduleTournamentInPosition(int i)
    {
        //TODO: Randomize Locations and be fair in distribution

        DotaTournament dotaTempTourney = gtg.GenerateDotaTournament();

        string tLocation = DecideDPCCalendarTourneyLocation(i);

        //decide name after region to match possible partners/sponsor
        string tName = DecideDPCCalendarTourneyName(i);

        Debug.Log(tName);

        DotaTournament.TournamentType tType = DecideDPCCalendarTourneyType(i);

        int tAmountTeams = DecideDPCCalendarTourneyAmountTeams(i, tType);

        int tEndYear = DecideDPCCalendarTourneyEndYear(i);
        int tEndMonth = DecideDPCCalendarTourneyEndMonth(i);
        int tEndDay = DecideDPCCalendarTourneyEndDay(i);

        int tStartYear = DecideDPCCalendarTourneyStartYear(i, tEndYear);
        int tStartMonth = DecideDPCCalendarTourneyStartMonth(i, tStartYear, tEndMonth, tEndDay);
        int tStartDay = DecideDPCCalendarTourneyStartDay(i, tStartYear, tStartMonth, tEndDay);

        Debug.Log("StartDate: " + tStartYear + "/" + tStartMonth + "/" + tStartDay);
        Debug.Log("EndDate: " + tEndYear + "/" + tEndMonth + "/" + tEndDay);

        gtg.SetupTournamentData(dotaTempTourney, tName, tLocation, tType, tAmountTeams);
        gtg.SetupTournamentDateData(dotaTempTourney, tStartDay, tStartMonth, tStartYear, tEndDay, tEndMonth, tEndYear);

        DotaTournament dotaTempTourneyQualifier = gtg.GenerateDotaTournamentQualifier();

        SetupDotaTournamentQualifier(dotaTempTourneyQualifier, tStartYear, tStartMonth, tStartDay, i);

        dotaTempTourney.dotaTournamentQualifier = dotaTempTourneyQualifier;

        dpcCalendarSchedule[i] = dotaTempTourney;
    }

    private void SetupDotaTournamentQualifier(DotaTournament dotaTempTourneyQualifier, int tStartYear, int tStartMonth, int tStartDay, int i)
    {
        int tourneyQualYearEnd = 0;
        int tourneyQualMonthEnd = 0;
        int tourneyQualDayEnd = 0;

        int tourneyQualYearStart = 0;
        int tourneyQualMonthStart = 0;
        int tourneyQualDayStart = 0;

        int daysToSubtract = DecideHowManyDaysBeforeTourneyQualStarts(i);

        tourneyQualYearEnd = calendar.CalculateYearSubtractingDays(tStartYear, tStartMonth, tStartDay, daysToSubtract);
        tourneyQualMonthEnd = calendar.CalculateMonthSubtractingDays(tStartYear, tStartMonth, tStartDay, daysToSubtract);
        tourneyQualDayEnd = calendar.CalculateDaySubtractingDays(tStartYear, tStartMonth, tStartDay, daysToSubtract);

        dotaTempTourneyQualifier.endYear = tourneyQualYearEnd;
        dotaTempTourneyQualifier.endMonth = tourneyQualMonthEnd;
        dotaTempTourneyQualifier.endDay = tourneyQualDayEnd;

        int qualDurationDays = DecideHowManyDaysQualTakes(i);
        
        tourneyQualYearStart = calendar.CalculateYearSubtractingDays(tourneyQualYearEnd, tourneyQualMonthEnd, tourneyQualDayEnd, qualDurationDays);
        tourneyQualMonthStart = calendar.CalculateMonthSubtractingDays(tourneyQualYearStart, tourneyQualMonthEnd, tourneyQualDayEnd, qualDurationDays);
        tourneyQualDayStart = calendar.CalculateDaySubtractingDays(tourneyQualYearStart, tourneyQualMonthStart, tourneyQualDayEnd, qualDurationDays);

        dotaTempTourneyQualifier.startYear = tourneyQualYearStart;
        dotaTempTourneyQualifier.startMonth = tourneyQualMonthStart;
        dotaTempTourneyQualifier.startDay = tourneyQualDayStart;
    }

    private int DecideHowManyDaysQualTakes(int i)
    {
        switch (i)
        {
            case 0:
                return 3;
            case 1:
                return 11;
            case 2:
                return 4;
            case 3:
                return 15;
            case 4:
                return 5;
            case 5:
                return 13;
            case 6:
                return 5;
            case 7:
                return 11;
            case 8:
                return 5;
            case 9:
                return 8;

            default:
                return 0;
        }
    }

    private int DecideHowManyDaysBeforeTourneyQualStarts(int i)
    {
        switch (i)
        {
            case 0:
                return 33;
            case 1:
                return 49;
            case 2:
                return 35;
            case 3:
                return 50;
            case 4:
                return 23;
            case 5:
                return 36;
            case 6:
                return 16;
            case 7:
                return 33;
            case 8:
                return 19;
            case 9:
                return 34;

            default:
                return 0;
        }
    }

    private int DecideDPCCalendarTourneyStartYear(int i, int tEndYear)
    {
        switch (i)
        {
            case 0:
                return calendar.currentYear;
            case 1:
                return calendar.currentYear;
            case 2:
                return calendar.currentYear + 1;
            case 3:
                return calendar.currentYear + 1;
            case 4:
                return calendar.currentYear + 1;
            case 5:
                return calendar.currentYear + 1;
            case 6:
                return calendar.currentYear + 1;
            case 7:
                return calendar.currentYear + 1;
            case 8:
                return calendar.currentYear + 1;
            case 9:
                return calendar.currentYear + 1;

            default:
                return 0;
        }
    }

    private int DecideDPCCalendarTourneyStartMonth(int i, int tEndYear, int tEndMonth, int tEndDay)
    {
        Debug.Log("Deicde Start month");

        int nextTourneyEndYear = 0;
        int nextTourneyEndMonth = 0;
        int nextTourneyEndDay = 0;

        nextTourneyEndYear = tEndYear;
        nextTourneyEndMonth = tEndMonth;
        nextTourneyEndDay = tEndDay;


        switch (i)
        {
            case 0:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 7);
            case 1:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 10);
            case 2:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 5);
            case 3:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 9);
            case 4:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 4);
            case 5:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 11);
            case 6:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 7);
            case 7:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 9);
            case 8:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 5);
            case 9:
                return calendar.CalculateMonthSubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 9);

            default:
                return 0;
        }
    }

    //private int GetThisTourneyEndDay(int i)
    //{
    //    int nextTeY = dpcCalendarSchedule[i].endDay;
    //    return nextTeY;
    //}

    //private int GetThisTourneyEndMonth(int i)
    //{
    //    int nextTeY = dpcCalendarSchedule[i].endMonth;
    //    return nextTeY;
    //}

    //private int GetThisTourneyEndYear(int i)
    //{
    //    int nextTeY = dpcCalendarSchedule[i].endYear;
    //    return nextTeY;
    //}

    private int DecideDPCCalendarTourneyStartDay(int i, int tStartYear, int tStartMonth, int tEndDay)
    {
        int nextTourneyEndYear = 0;
        int nextTourneyEndMonth = 0;
        int nextTourneyEndDay = 0;

        nextTourneyEndYear = tStartYear;
        nextTourneyEndMonth = tStartMonth;
        nextTourneyEndDay = tEndDay;

        switch (i)
        {
            case 0:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 5);
            case 1:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 9);
            case 2:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 4);
            case 3:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 8);
            case 4:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 3);
            case 5:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 10);
            case 6:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 6);
            case 7:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 8);
            case 8:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 4);
            case 9:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 8);

            default:
                return 0;
        }
    }

    private int DecideDPCCalendarTourneyEndYear(int i)
    {
        switch (i)
        {
            case 0:
                return calendar.currentYear;
            case 1:
                return calendar.currentYear;
            case 2:
                return calendar.returnnextYear();
            case 3:
                return calendar.returnnextYear();
            case 4:
                return calendar.returnnextYear();
            case 5:
                return calendar.returnnextYear();
            case 6:
                return calendar.returnnextYear();
            case 7:
                return calendar.returnnextYear();
            case 8:
                return calendar.returnnextYear();
            case 9:
                return calendar.returnnextYear();

            default:
                return 0;
        }
    }

    private int GetNextTourneyStartDay(int i)
    {
        int nextTeY = dpcCalendarSchedule[i + 1].startDay;
        return nextTeY;
    }

    private int GetNextTourneyStartMonth(int i)
    {
        int nextTeY = dpcCalendarSchedule[i + 1].startMonth;
        return nextTeY;
    }

    private int GetNextTourneyStartYear(int i)
    {
        int nextTeY = dpcCalendarSchedule[i + 1].startYear;
        return nextTeY;
    }

    private int DecideDPCCalendarTourneyEndMonth(int i)
    {
        Debug.Log("Decide End Month");

        int nextTourneyStartYear = 0;
        int nextTourneyStartMonth = 0;
        int nextTourneyStartDay = 0;

        if (i < 9)
        {
            nextTourneyStartYear = GetNextTourneyStartYear(i);
            nextTourneyStartMonth = GetNextTourneyStartMonth(i);
            nextTourneyStartDay = GetNextTourneyStartDay(i);
        }
        else
        {
            DotaTournament earliestOpenQualDay = null;

            if (i == 9)
            {
                earliestOpenQualDay = GetEarliestOpenQualsTournament();

                nextTourneyStartYear = earliestOpenQualDay.startYear;
                nextTourneyStartMonth = earliestOpenQualDay.startMonth;
                nextTourneyStartDay = earliestOpenQualDay.startDay;
            }

        }

        switch (i)
        {
            case 0:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 5);
            case 1:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 52);
            case 2:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 6);
            case 3:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 39);
            case 4:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 4);
            case 5:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 29);
            case 6:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 6);
            case 7:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 31);
            case 8:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 6);
            case 9:
                return calendar.CalculateMonthSubtractingDays(nextTourneyStartYear, nextTourneyStartMonth, nextTourneyStartDay, 3);

            default:
                return 0;
        }
    }

    private int DecideDPCCalendarTourneyEndDay(int i)
    {
        int nextTourneyEndYear = 0;
        int nextTourneyEndMonth = 0;
        int nextTourneyEndDay = 0;

        if (i < 9)
        {
            nextTourneyEndYear = GetNextTourneyStartYear(i);
            nextTourneyEndMonth = GetNextTourneyStartMonth(i);
            nextTourneyEndDay = GetNextTourneyStartDay(i);
        }
        else
        {
            DotaTournament earliestOpenQualDay = null;

            if (i == 9)
            {
                //get tournament Qual instead of day
                earliestOpenQualDay = GetEarliestOpenQualsTournament();
            }
            Debug.Log("OOstart: " + earliestOpenQualDay);
            nextTourneyEndYear = earliestOpenQualDay.startYear;
            nextTourneyEndMonth = earliestOpenQualDay.startMonth;
            nextTourneyEndDay = earliestOpenQualDay.startDay;
        }

        switch (i)
        {
            case 0:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 5);
            case 1:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 52);
            case 2:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 6);
            case 3:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 39);
            case 4:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 4);
            case 5:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 29);
            case 6:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 6);
            case 7:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 31);
            case 8:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 6);
            case 9:
                return calendar.CalculateDaySubtractingDays(nextTourneyEndYear, nextTourneyEndMonth, nextTourneyEndDay, 3);

            default:
                return 0;
        }
    }

    private int DecideDPCCalendarTourneyAmountTeams(int i, DotaTournament.TournamentType tType)
    {
        if (tType.Equals(DotaTournament.TournamentType.Major))
        {
            return 16;
        }
        else if (tType.Equals(DotaTournament.TournamentType.Minor))
        {
            return 12;
        }
        else
        {
            return 6;
        }
    }

    private string DecideDPCCalendarTourneyName(int i)
    {
        switch (i)
        {
            case 0:
                return "EU Minor";
            case 1:
                return "SEA Major";
            case 2:
                return "Europe Minor";
            case 3:
                return "Asia Major";
            case 4:
                return "Starladder Minor";
            case 5:
                return "Dreamleague Major";
            case 6:
                return "OGA DotaPit Minor";
            case 7:
                return "MDL Major";
            case 8:
                return "Starladder Minor";
            case 9:
                return "Epicenter Major";

            default:
                return "";
        }
    }

    private string DecideDPCCalendarTourneyLocation(int i)
    {
        switch (i)
        {
            case 0:
                return "Köln";
            case 1:
                return "Singapur";
            case 2:
                return "Paris";
            case 3:
                return "Shanghai";
            case 4:
                return "Kiew";
            case 5:
                return "Stockholm";
            case 6:
                return "Athen";
            case 7:
                return "Shenzhen";
            case 8:
                return "Warschau";
            case 9:
                return "London";

            default:
                return "";
        }
    }

    private DotaTournament.TournamentType DecideDPCCalendarTourneyType(int i)
    {
        switch (i)
        {
            case 0:
                return DotaTournament.TournamentType.Minor;
            case 1:
                return DotaTournament.TournamentType.Major;
            case 2:
                return DotaTournament.TournamentType.Minor;
            case 3:
                return DotaTournament.TournamentType.Major;
            case 4:
                return DotaTournament.TournamentType.Minor;
            case 5:
                return DotaTournament.TournamentType.Major;
            case 6:
                return DotaTournament.TournamentType.Minor;
            case 7:
                return DotaTournament.TournamentType.Major;
            case 8:
                return DotaTournament.TournamentType.Minor;
            case 9:
                return DotaTournament.TournamentType.Major;

            default:
                return DotaTournament.TournamentType.International;
        }
    }

    private DotaTournament GetEarliestOpenQualsTournament()
    {
        int controlDay = 31;
        int tournamentIndex = 0;

        for (int i = 0; i < internationalOpenQualifiers.Length; i++)
        {
            if (internationalOpenQualifiers[i].startDay < controlDay)
            {
                controlDay = internationalOpenQualifiers[i].startDay;
                tournamentIndex = i;
            }
        }

        return internationalOpenQualifiers[tournamentIndex];
    }

    private void CreateMajorTournament()
    {
        dotaTournamentinternational = gtg.GenerateDotaTournament();

        string tName = "The International";
        string tLocation = "Cologne";
        DotaTournament.TournamentType tType = DotaTournament.TournamentType.International;

        int tAmountTeams = 18;
        // AddDeservingTeamsToTournamentPool(dotaTournament);

        int tEndDay = 5;
        int tEndMonth = 8;
        int tEndYear = calendar.currentYear;

        int tStartDay = tEndDay - 1;
        int tStartMonth = tEndMonth;
        int tStartYear = tEndYear;

        gtg.SetupTournamentData(dotaTournamentinternational, tName, tLocation, tType, tAmountTeams);
        gtg.SetupTournamentDateData(dotaTournamentinternational, tStartDay, tStartMonth, tStartYear, tEndDay, tEndMonth, tEndYear);
        SetupQualifiersForTournament(dotaTournamentinternational);

        DotaTournament theInternational = dotaTournamentinternational;

        dpcCalendarSchedule[amountTournamentDPC - 1] = theInternational;
    }
}
