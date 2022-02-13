using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameParameters : MonoBehaviour
{
    public int gameTimeDay = 1;
    public int gameTimeMonth = 9;
    public int gameTimeYear = 2018;

    public Calendar calendar;

    [SerializeField] public enum Game { DotA2, RocketLeague, Rainbow6Siege, CSGO, FIFA, PUBG, LeagueOfLegends, Starcraft2 };

    [SerializeField] public enum Region { Europe, China, CIS, SouthEastAsia, NorthAmerica, SouthAmerica };


    #region staff limits
    public int maxTrainers = 2;
    public int maxScouts = 2;
    public int maxDoctors = 1;
    public int maxPRManagers = 1;
    public int maxDataAnalysts = 2;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        calendar = FindObjectOfType<Calendar>();
    }
    
    public void UpdateGameDate()
    {
        gameTimeDay = calendar.returncurrentDay();
        gameTimeMonth = calendar.returncurrentMonth();
        gameTimeYear = calendar.returncurrentYear();
    }
}
