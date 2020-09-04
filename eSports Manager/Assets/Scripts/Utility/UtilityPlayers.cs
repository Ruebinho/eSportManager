using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityPlayers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal float GetAverageAmountFarmingThreePlayers(Player player1, Player player2, Player player3)
    {
        float result = 0;

        result = (player1.farming + player2.farming + player3.farming) / 3;

        return result;
    }

    internal float GetTeamAmountTeamfight(Player pos1, Player pos2, Player pos3, Player pos4, Player pos5)
    {
        float teamTeamfightValue = pos1.teamfight + pos2.teamfight + pos3.teamfight + pos4.teamfight + pos5.teamfight;

        return teamTeamfightValue;
    }

    internal float getTeamAmountFarming(Player pos1, Player pos2, Player pos3, Player pos4, Player pos5)
    {
        float teamFarmingValue = pos1.farming + pos2.farming + pos3.farming + pos4.farming + pos5.farming;

        return teamFarmingValue;
    }
}
