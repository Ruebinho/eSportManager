using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotaMatch : MonoBehaviour
{
    public Team matchTeam1 = null;
    public Team matchTeam2 = null;

    public Player team1pos1 = null;
    public Player team1pos2 = null;
    public Player team1pos3 = null;
    public Player team1pos4 = null;
    public Player team1pos5 = null;

    public Player team2pos1 = null;
    public Player team2pos2 = null;
    public Player team2pos3 = null;
    public Player team2pos4 = null;
    public Player team2pos5 = null;

    public float resultEarlyGame = 0f;
    public float resultMidGame = 0f;
    public float resultLateGame = 0f;

    public float resultGame = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getDotaMatchGameData(Team team1, Team team2)
    {
        matchTeam1 = team1;
        matchTeam2 = team2;

        foreach (Player player in matchTeam1.playersOnTeam)
        {
            FillCorrectPlayerMatchDataTeam1(player);
        }

        foreach (Player player in matchTeam2.playersOnTeam)
        {
            FillCorrectPlayerMatchDataTeam2(player);
        }
    }

    private void FillCorrectPlayerMatchDataTeam1(Player player)
    {
        switch (player.role)
        {
            case ESM.Character.CharacterGenerator.Role.Position1:
                team1pos1 = player;
                break;
            case ESM.Character.CharacterGenerator.Role.Position2:
                team1pos2 = player;
                break;
            case ESM.Character.CharacterGenerator.Role.Position3:
                team1pos3 = player;
                break;
            case ESM.Character.CharacterGenerator.Role.Position4:
                team1pos4 = player;
                break;
            case ESM.Character.CharacterGenerator.Role.Position5:
                team1pos5 = player;
                break;
        }
    }

    private void FillCorrectPlayerMatchDataTeam2(Player player)
    {
        switch (player.role)
        {
            case ESM.Character.CharacterGenerator.Role.Position1:
                team2pos1 = player;
                break;
            case ESM.Character.CharacterGenerator.Role.Position2:
                team2pos2 = player;
                break;
            case ESM.Character.CharacterGenerator.Role.Position3:
                team2pos3 = player;
                break;
            case ESM.Character.CharacterGenerator.Role.Position4:
                team2pos4 = player;
                break;
            case ESM.Character.CharacterGenerator.Role.Position5:
                team2pos5 = player;
                break;
        }
    }

    public void StartMatch()
    {

        resultEarlyGame = CalculateEarlyGame();
        resultMidGame = CalculateMidGame(resultEarlyGame);
        resultLateGame = CalculateEndGame(resultMidGame);

        resultGame = CalculateFinalResult(resultLateGame);
    }

    #region calculateEG
    private float CalculateEarlyGame()
    {
        float topLaneEGResult = CalculateTopLaneEGResult();
        float midLaneEGResult = CalculateMidLaneEGResult();
        float botLaneEGResult = CalculateBotLaneEGResult();

        //calculate lane results
        float earlyGameResult = 0f;

        return earlyGameResult;
    }

    private float CalculateBotLaneEGResult()
    {
        throw new NotImplementedException();
    }

    private float CalculateMidLaneEGResult()
    {
        throw new NotImplementedException();
    }

    private float CalculateTopLaneEGResult()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region calculateMG
    private float CalculateMidGame(float resultEarlyGame)
    {
        throw new NotImplementedException();
    }

    private float CalculateTeamfightResult()
    {
        throw new NotImplementedException();
    }

    private float CalculateGankingResult()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region calculateEG

    private float CalculateEndGame(float resultMidGame)
    {
        throw new NotImplementedException();
    }
    #endregion

    private float CalculateFinalResult(float resultLateGame)
    {
        throw new NotImplementedException();
    }

    private void ResetGameResults()
    {
        resultEarlyGame = 0f;
        resultMidGame = 0f;
        resultLateGame = 0f;
        resultGame = 0f;
    }

    internal void SimulateDotaMatch()
    {
        ResetGameResults();
        StartMatch();

        Debug.Log(resultGame);
    }
}
