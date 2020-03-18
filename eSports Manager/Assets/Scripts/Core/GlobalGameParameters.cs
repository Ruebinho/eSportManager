using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameParameters : MonoBehaviour
{
    public int gameTimeDay = 1;
    public int gameTimeMonth = 1;
    public int gameTimeYear = 2019;

    public Calendar calendar;

    [SerializeField] public enum Game { DotA2, RocketLeague, Rainbow6Siege, CSGO, FIFA };
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
