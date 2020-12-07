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

    // Start is called before the first frame update
    void Start()
    {
        gtg = FindObjectOfType<GameTournamentGenerator>();
        calendar = FindObjectOfType<Calendar>();
         
        seasonStartDay = game.seasonStartDay;
        seasonStartMonth = game.seasonStartMonth;

        amountTournamentDPC = CalculateTotalTournamentAmountForYear();

        dpcCalendarSchedule = new DotaTournament[amountTournamentDPC];
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

    }
}
