using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public int currentDay = 1;
    public int currentMonth = 1;
    public int currentYear = 2019;

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
        }else
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
}