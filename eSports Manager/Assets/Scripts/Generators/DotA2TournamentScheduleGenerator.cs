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
        int tEndYear = calendar.currentYear+1;

        int tStartDay = tEndDay - 11;
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

        int tEUQEndDay = internationalRegionalQualifiers[0].endDay - 1;
        int tEUQEndMonth = internationalRegionalQualifiers[0].endMonth - 1;
        int tEUQEndYear = internationalRegionalQualifiers[0].endYear;

        int tEUQStartDay = tEUQEndDay - 11;
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

        int tAQEndDay = internationalRegionalQualifiers[1].endDay - 1;
        int tAQEndMonth = internationalRegionalQualifiers[1].endMonth - 1;
        int tAQEndYear = internationalRegionalQualifiers[1].endYear;

        int tAQStartDay = tEUQEndDay - 11;
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

        int tNAEndDay = internationalRegionalQualifiers[2].endDay - 1;
        int tNAEndMonth = internationalRegionalQualifiers[2].endMonth - 1;
        int tNAEndYear = internationalRegionalQualifiers[2].endYear;

        int tNAStartDay = tEUQEndDay - 11;
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

        int tSAEndDay = internationalRegionalQualifiers[3].endDay - 1;
        int tSAEndMonth = internationalRegionalQualifiers[3].endMonth - 1;
        int tSAEndYear = internationalRegionalQualifiers[3].endYear;

        int tSAStartDay = tEUQEndDay - 11;
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

        int tCISQEndDay = internationalRegionalQualifiers[4].endDay - 1;
        int tCISQEndMonth = internationalRegionalQualifiers[4].endMonth - 1;
        int tCISQEndYear = internationalRegionalQualifiers[4].endYear;

        int tCISQStartDay = tEUQEndDay - 11;
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

        int tSEAQEndDay = internationalRegionalQualifiers[5].endDay - 1;
        int tSEAQEndMonth = internationalRegionalQualifiers[5].endMonth - 1;
        int tSEAQEndYear = internationalRegionalQualifiers[5].endYear;

        int tSEAQStartDay = tEUQEndDay - 11;
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
        DotaTournament.TournamentType tType = DecideDPCCalendarTourneyType(i);

        int tAmountTeams = DecideDPCCalendarTourneyAmountTeams(i, tType);

        int tEndYear = DecideDPCCalendarTourneyEndYear(i);
        int tEndMonth = DecideDPCCalendarTourneyEndMonth(i);
        int tEndDay = DecideDPCCalendarTourneyEndDay(i);

        int tStartYear = DecideDPCCalendarTourneyStartYear(i);
        int tStartMonth = DecideDPCCalendarTourneyStartMonth(i);
        int tStartDay = DecideDPCCalendarTourneyStartDay(i);

        gtg.SetupTournamentData(dotaTempTourney, tName, tLocation, tType, tAmountTeams);
        gtg.SetupTournamentDateData(dotaTempTourney, tStartDay, tStartMonth, tStartYear, tEndDay, tEndMonth, tEndYear);

        DotaTournament dotaTempTourneyQualifier = gtg.GenerateDotaTournamentQualifier();

        dotaTempTourney.dotaTournamentQualifier = dotaTempTourneyQualifier;

        dpcCalendarSchedule[i] = dotaTempTourney;
    }

    private int DecideDPCCalendarTourneyStartYear(int i)
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

    private int DecideDPCCalendarTourneyStartMonth(int i)
    {
        switch (i)
        {
            case 0:
                return 0;
            case 1:
                return 0;
            case 2:
                return 0;
            case 3:
                return 0;
            case 4:
                return 0;
            case 5:
                return 0;
            case 6:
                return 0;
            case 7:
                return 0;
            case 8:
                return 0;
            case 9:
                return 0;

            default:
                return 0;
        }
    }

    private int DecideDPCCalendarTourneyStartDay(int i)
    {
        switch (i)
        {
            case 0:
                return 0;
            case 1:
                return 0;
            case 2:
                return 0;
            case 3:
                return 0;
            case 4:
                return 0;
            case 5:
                return 0;
            case 6:
                return 0;
            case 7:
                return 0;
            case 8:
                return 0;
            case 9:
                return 0;

            default:
                return 0;
        }
    }

    private int DecideDPCCalendarTourneyEndYear(int i)
    {
        int nextTourneyEndYear = 0;
        int nextTourneyEndMonth = 0;
        int nextTourneyEndDay = 0;

        if (i < 10)
        {
            nextTourneyEndYear = GetNextTourneyStartYear(i);
            nextTourneyEndMonth = GetNextTourneyStartMonth(i);
            nextTourneyEndDay = GetNextTourneyStartDay(i);
        }
        else
        {
            int earliestOpenQualDay = 0;

            if (i == 10)
            {
                //get tournament Qual instead of day
                earliestOpenQualDay = GetEarliestOpenQualsStartDate();
            }

            nextTourneyEndYear = GetNextTourneyStartYear(i);
            nextTourneyEndMonth = GetNextTourneyStartMonth(i);
            nextTourneyEndDay = GetNextTourneyStartDay(i);
        }


        switch (i)
        {
            case 0:
                return 0;
            case 1:
                return 0;
            case 2:
                return 0;
            case 3:
                return 0;
            case 4:
                return 0;
            case 5:
                return 0;
            case 6:
                return 0;
            case 7:
                return 0;
            case 8:
                return 0;
            case 9:
                return 0;

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
        switch (i)
        {
            case 0:
                return 0;
            case 1:
                return 0;
            case 2:
                return 0;
            case 3:
                return 0;
            case 4:
                return 0;
            case 5:
                return 0;
            case 6:
                return 0;
            case 7:
                return 0;
            case 8:
                return 0;
            case 9:
                return 0;

            default:
                return 0;
        }
    }

    private int DecideDPCCalendarTourneyEndDay(int i)
    {
        switch (i)
        {
            case 0:
                return 0;
            case 1:
                return 0;
            case 2:
                return 0;
            case 3:
                return 0;
            case 4:
                return 0;
            case 5:
                return 0;
            case 6:
                return 0;
            case 7:
                return 0;
            case 8:
                return 0;
            case 9:
                return 0;

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

    private int GetEarliestOpenQualsStartDate()
    {
        int controlDay = 31;

        for (int i = 0; i < internationalOpenQualifiers.Length; i++)
        {
            if (internationalOpenQualifiers[i].startDay < controlDay)
            {
                controlDay = internationalOpenQualifiers[i].startDay;
            }
        }

        return controlDay;
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
