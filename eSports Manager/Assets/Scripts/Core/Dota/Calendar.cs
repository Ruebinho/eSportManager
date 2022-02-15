using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public int currentDay = 1;
    public int currentMonth = 9;
    public int currentYear = 2018;

    public DateTime currentDateTime = new DateTime(2018, 9, 1);

    public int returncurrentDay()
    {
        return currentDay;
    }

    public int returncurrentMonth()
    {
        return currentMonth;
    }

    public int returncurrentYear()
    {
        return currentYear;
    }

    public int returnnextYear()
    {
        return currentYear + 1;
    }

    public void AdvanceTime()
    {
        if (currentMonth == 12 && currentDay == 31)
        {
            currentYear += 1;
            currentMonth = 1;
            currentDay = 1;
        }
        else if (hasCurrentMonth31days() && currentDay == 31)
        {
            currentMonth += 1;
            currentDay = 1;
        }
        else if (hasCurrentMonth30days() && currentDay == 30)
        {
            currentMonth += 1;
            currentDay = 1;
        }
        else if (currentMonth == 2)
        {
            if (isSchaltjahr() && currentDay == 29)
            {
                currentMonth += 1;
                currentDay = 1;
            }
            else if (!isSchaltjahr() && currentDay == 28)
            {
                currentMonth += 1;
                currentDay = 1;
            }
            else
            {
                currentDay += 1;
            }
        }
        else
        {
            currentDay += 1;
        }

        FindObjectOfType<GlobalGameParameters>().UpdateGameDate();
    }

    private bool hasCurrentMonth30days()
    {
        if (currentMonth == 4 || currentMonth == 6 || currentMonth == 9 || currentMonth == 11)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool hasCurrentMonth31days()
    {
        if (currentMonth == 1 || currentMonth == 3 || currentMonth == 5 || currentMonth == 7 || currentMonth == 8 || currentMonth == 10 || currentMonth == 12)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int returnAmountDaysOfMonth(int month)
    {
        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            return 31;
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            return 30;
        }
        else
        {
            if (isSchaltjahr())
            {
                return 29;
            }
            else
            {
                return 28;
            }
        }
    }

    private bool isSchaltjahr()
    {
        if (currentYear % 4 == 0)
        {
            if (currentYear % 100 == 0)
            {
                if (currentYear % 400 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }

    }

    public bool CheckIfBirthdayHasPassedThisYear(int generatedBirthMonth, int generatedBirthDay)
    {
        int ingameD = currentDay;
        int ingameM = currentMonth;

        if (ingameM < generatedBirthMonth)
        {
            return false;
        }
        else
        {
            if (ingameM > generatedBirthMonth)
            {
                return true;
            }
            else
            {
                if (ingameM == generatedBirthMonth)
                {
                    if (ingameD < generatedBirthDay)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return true;
        }
    }

    public int GetPlayerAge(int birthmonth, int birthday, int birthyear)
    {
        int playerage = 0;

        bool hadBirthdayThisYear = CheckIfBirthdayHasPassedThisYear(birthmonth, birthday);
        if (hadBirthdayThisYear)
        {
            playerage = currentYear - birthyear;
        }
        else
        {
            playerage = currentYear - birthyear - 1;
        }

        return playerage;
    }

    public int CheckWeekDayOfFirstOfAUGNextYear()
    {
        DateTime dateValue = new DateTime(currentYear + 1, 8, 1);
        return ((int)dateValue.DayOfWeek);
    }

    public bool CheckIfNumberOfDaysSubstractedIsMoreThanDaysInMonthLeft(int startDay, int daysToSubstract)
    {
        return daysToSubstract > startDay;
    }

    public int CalculateYearSubtractingDays(int startYear, int startMonth, int startDay, int daysToSubtract)
    {
        if (startMonth > 1 && daysToSubtract <= 31)
        {
            return startYear;
        }
        else
        {
            return CalculateNewDateYear(startYear, startMonth, startDay, daysToSubtract);
        }

    }

    public int CalculateMonthSubtractingDays(int startYear, int startMonth, int startDay, int daysToSubtract)
    {
        Debug.Log("Calculating Month:" + startYear + "/" + startMonth + "/" + startDay + "// Days To Substarct: " + daysToSubtract);

        if (daysToSubtract < startDay)
        {
            Debug.Log("dts<startday");
            return startMonth;
        }
        else
        {
            Debug.Log("dts > startday");
            Debug.Log("New Month: " + CalculateNewDateMonth(startMonth, startDay, daysToSubtract));
            return CalculateNewDateMonth(startMonth, startDay, daysToSubtract);
        }

    }

    public int CalculateDaySubtractingDays(int startYear, int startMonth, int startDay, int daysToSubtract)
    {
        if (daysToSubtract < startDay)
        {
            return startDay-daysToSubtract;
        }
        else
        {
            return CalculateNewDateDay(startMonth, startDay, daysToSubtract);
        }

    }

    //TODO revise calculations
    private int CalculateNewDateYear(int startYear, int startMonth, int startDay, int daysToSubtract)
    {
        int remainderDaysForCalculation = daysToSubtract;


        if (isDaysToSubstractBiggerThanDaysInYearLeft(startMonth, startDay, daysToSubtract))
        {
            return startYear - 1;
        }
        else
        {
            return startYear;
        }

    }

    private bool isDaysToSubstractBiggerThanDaysInYearLeft(int startMonth, int startDay, int daysToSubtract)
    {
        int daysLeftInYear = CalculateDateToDays(startMonth, startDay);

        return daysLeftInYear < daysToSubtract;
    }

    private int CalculateDateToDays(int startMonth, int startDay)
    {
        int daysFromDate = CountDaysFromMonths(startMonth);
        daysFromDate += startDay;

        return daysFromDate;
    }

    private int CountDaysFromMonths(int startMonth)
    {
        int daysCounted = 0;

        for (int i = 0; i < startMonth; i++)
        {
            daysCounted += returnAmountDaysOfMonth(i);
        }

        return daysCounted;
    }

    private int CalculateNewDateMonth(int startMonth, int startDay, int daysToSubtract)
    {
        int remainderDaysForCalculation = startDay;
        int remainderMonthsForCalculation = startMonth;

        // if day of month is bigger than daysToSubstract
        if (startDay > daysToSubtract)
        {
            return startMonth;
        }
        else
        {
            int newMonth = CalculateNewMonthSubtractingDays(startDay, startMonth, daysToSubtract);
            return newMonth;
        }
    }

    private int CalculateNewMonthSubtractingDays(int startDay, int startMonth, int daysToSubtract)
    {
        int calcDaysToSubstract = daysToSubtract;
        int calcToNewMonth = startMonth;

        while (calcDaysToSubstract > 0)
        {
            if ((calcToNewMonth == startMonth) && (calcToNewMonth == 1))
            {
                calcDaysToSubstract = calcDaysToSubstract-startDay;
                calcToNewMonth = 12;
            }
            else if (calcToNewMonth == startMonth)
            {
                calcDaysToSubstract = calcDaysToSubstract - startDay;
                calcToNewMonth = calcToNewMonth - 1;
            }
            else
            {
                if ((calcDaysToSubstract > returnAmountDaysOfMonth(calcToNewMonth)) && calcToNewMonth == 1)
                {
                    calcDaysToSubstract = calcDaysToSubstract - returnAmountDaysOfMonth(calcToNewMonth);
                    calcToNewMonth = 12;
                    break;
                }
                else if (calcDaysToSubstract > returnAmountDaysOfMonth(calcToNewMonth))
                {
                    calcDaysToSubstract = calcDaysToSubstract - returnAmountDaysOfMonth(calcToNewMonth);
                    calcToNewMonth = calcToNewMonth-1;
                    break;
                }
                else
                {
                    return calcToNewMonth;
                }
            }
        }
        return calcToNewMonth;

    }

    private int CalculateNewDateDay(int startMonth, int startDay, int daysToSubtract)
    {
        int calcDaysToSubstract = daysToSubtract;
        int calcToNewMonth = startMonth;

        while (calcDaysToSubstract >= 0)
        {
            if ((calcToNewMonth == startMonth) && (calcToNewMonth == 1))
            {
                calcDaysToSubstract -= startDay;
                calcToNewMonth = 12;
            }
            else if (calcToNewMonth == startMonth)
            {
                calcDaysToSubstract -= startDay;
                calcToNewMonth -= 1;
            }
            else
            {
                if (calcDaysToSubstract > returnAmountDaysOfMonth(calcToNewMonth))
                {
                    calcDaysToSubstract -= returnAmountDaysOfMonth(calcToNewMonth);
                    calcToNewMonth -= 1;
                }
                else
                {
                    return returnAmountDaysOfMonth(calcToNewMonth)-calcDaysToSubstract;
                }
            }
        }

        return 0;
    }
}