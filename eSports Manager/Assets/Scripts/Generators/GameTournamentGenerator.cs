using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTournamentGenerator : MonoBehaviour
{
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
    public int tAmountTeamsInTorunament = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
