using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotaMatch : MonoBehaviour
{
    public Team matchTeam1 = null;
    public Team matchTeam2 = null;

    public Player team1captain = null;
    public Player team1pos1 = null;
    public Player team1pos2 = null;
    public Player team1pos3 = null;
    public Player team1pos4 = null;
    public Player team1pos5 = null;

    public Player team2captain = null;
    public Player team2pos1 = null;
    public Player team2pos2 = null;
    public Player team2pos3 = null;
    public Player team2pos4 = null;
    public Player team2pos5 = null;

    public float resultEarlyGame = 0f;
    public float resultMidGame = 0f;
    public float resultLateGame = 0f;

    public float resultGame = 0f;

    //change if team factor should be bigger
    public float teamFactorMultiplicator = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getDotaMatchGameData()
    {
        SetCorrectTeam1Captain(matchTeam1);
        SetCorrectTeam2Captain(matchTeam2);

        foreach (Player player in matchTeam1.playersOnTeam)
        {
            FillCorrectPlayerMatchDataTeam1(player);
        }

        foreach (Player player in matchTeam2.playersOnTeam)
        {
            FillCorrectPlayerMatchDataTeam2(player);
        }
    }

    private void SetCorrectTeam2Captain(Team matchTeam2)
    {
        team2captain = matchTeam2.teamCaptain;
    }

    private void SetCorrectTeam1Captain(Team matchTeam1)
    {
        team1captain = matchTeam1.teamCaptain;
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
        getDotaMatchGameData();
        resultEarlyGame = CalculateEarlyGame();
        resultMidGame = CalculateMidGame(resultEarlyGame);
        resultLateGame = CalculateEndGame(resultMidGame);

        resultGame = CalculateFinalResult(resultLateGame);
    }

    #region calculateEG
    private float CalculateEarlyGame()
    {
        float botLaneEGResult = CalculateBotLaneEGResult();
        float topLaneEGResult = CalculateTopLaneEGResult();
        float midLaneEGResult = CalculateMidLaneEGResult();

        //calculate lane results
        float earlyGameResult = 0f;

        return earlyGameResult;
    }

    private float CalculateBotLaneEGResult()
    {
        float botLaneEGResult = 0.5f;

        Player rCarry = team1pos1;
        Player rHardSupport = team1pos5;

        Player dOfflaner = team2pos3;
        Player dSupport = team2pos4;

        // depends on skill of players and draft abilities of captain
        float rcVSdo = CheckWhoHasAdvantage(rCarry, dOfflaner);
        float rhsVSds = CheckWhoHasAdvantage(rHardSupport, dSupport);
        float rcVSds = CheckWhoHasAdvantage(rCarry, dSupport);
        float rhsVSdo = CheckWhoHasAdvantage(rHardSupport, dOfflaner);

        //depends on teamwork skill and team composition/drafting
        float teamVSteam = CheckWhoHasTeamAdvantage(rCarry, rHardSupport, dOfflaner, dSupport);

        botLaneEGResult = (rcVSdo + rhsVSds + rcVSds + rhsVSdo + teamVSteam) / 5;

        return botLaneEGResult;
    }

    private float CheckWhoHasTeamAdvantage(Player rCore, Player rSupport, Player dCore, Player dSupport)
    {
        float cptT1draftingskill = team1captain.getDraftingSkill();
        float cptT2draftingskill = team2captain.getDraftingSkill();

        float t1teamskill = (rCore.teamwork + rSupport.teamwork) / 2;
        float t2teamskill = (dCore.teamwork + dSupport.teamwork) / 2;

        float team1advantage = (cptT1draftingskill + t1teamskill) / 2;
        float team2advantage = (cptT2draftingskill + t2teamskill) / 2;

        float egTeamAdvantage = CalculateFloatResultOfAdvantages(team1advantage, team2advantage);
        Debug.Log("Team Advantage: " + egTeamAdvantage);
        return egTeamAdvantage;
    }

    private float CalculateFloatResultOfAdvantages(float team1advantage, float team2advantage)
    {
        float result = 0.5f;
        float endResult = 0.5f;
        //get result of -100 to 100
        float resultCalculation = (team1advantage - team2advantage);

        bool resultIsPositive = CalculateResultPositiveNegative(resultCalculation);

        // 0.005f is factor to put value from 0 to 1
        // teamFactorMultiplicator if teamplay should be rewarded more (standard: 1f)
        if (resultIsPositive)
        {
            endResult = result - (resultCalculation * 0.005f * teamFactorMultiplicator);
        } else
        {
            endResult = result + (resultCalculation * 0.005f * teamFactorMultiplicator);
        }

        return endResult;
    }

    private bool CalculateResultPositiveNegative(float resultCalculation)
    {
        return resultCalculation > 0;
    }

    private float CheckWhoHasAdvantage(Player t1Player, Player t2Player)
    {
        // Check for Roles and make specific comparisons

        float t1PlayerTotalSkill = t1Player.lastHitting;
        float t2PlayerTotalSkill = t2Player.lastHitting;

        float result = CalculateFloatResultOfAdvantages(t1PlayerTotalSkill, t2PlayerTotalSkill);
        Debug.Log("Advantage - " + t1Player.name + " vs. " + t2Player.name + " : " + result);
        return result;
    }

    private float CalculateMidLaneEGResult()
    {
        float midLaneEGResult = 0.5f;

        Player rMid = team1pos2;

        Player dMid = team2pos2;

        // depends on skill of players and draft abilities of captain
        float rmVSdm = CheckWhoHasAdvantage(rMid, dMid);

        //TODO need checks on other parameters

        midLaneEGResult = rmVSdm;

        return midLaneEGResult;
    }

    private float CalculateTopLaneEGResult()
    {
        float topLaneEGResult = 0.5f;

        Player dCarry = team2pos1;
        Player dHardSupport = team2pos5;

        Player rOfflaner = team1pos3;
        Player rSupport = team1pos4;

        // depends on skill of players and draft abilities of captain
        float roVSdc = CheckWhoHasAdvantage(rOfflaner, dCarry);
        float rsVSdhs = CheckWhoHasAdvantage(rSupport, dHardSupport);
        float rsVSdc = CheckWhoHasAdvantage(rSupport, dCarry);
        float roVSdhs = CheckWhoHasAdvantage(rOfflaner, dHardSupport);

        //depends on teamwork skill and team composition/drafting
        float teamVSteam = CheckWhoHasTeamAdvantage(rOfflaner, rSupport, dCarry, dHardSupport);

        topLaneEGResult = (roVSdc + rsVSdhs + rsVSdc + roVSdhs + teamVSteam) / 5;

        return topLaneEGResult;
    }

    #endregion

    #region calculateMG
    private float CalculateMidGame(float resultEarlyGame)
    {
        float resultMidGame = 0.5f;

        float gankingResult = CalculateGankingResult();
        float farmingResult = CalculateMidGameFarming();
        float teamfightResult = CalculateTeamfightResult();

        return (resultEarlyGame + resultMidGame) / 2f;
    }

    private float CalculateMidGameFarming()
    {
        throw new NotImplementedException();
    }

    private float CalculateTeamfightResult()
    {
        throw new NotImplementedException();
    }

    private float CalculateGankingResult()
    {
        float gankingResult = 0.5f;

        Player rMid = team1pos2;
        Player rSupport = team1pos4;
        Player rHardSupport = team1pos5;

        Player rCarry= team1pos1;
        Player rOfflaner= team1pos3;

        Player dMid = team2pos2;
        Player dSupport = team2pos4;
        Player dHardSupport = team2pos5;

        Player dCarry = team2pos1;
        Player dOfflaner = team2pos3;

        // depends on skill of players: Gankers - Mind gaming, determination, teamwork / Victims - Map Awareness, Mindgaming, concentration, reaction time
        float rGankdMid = CheckWhoHasGankingAdvantage3v1(rMid, rSupport, rHardSupport, dMid);
        float rGankdCarry = CheckWhoHasGankingAdvantage3v2(rMid, rSupport, rOfflaner, dCarry, dHardSupport);
        float rGankdOfflaner = CheckWhoHasGankingAdvantage3v2(rMid, rHardSupport, rCarry, dOfflaner, dSupport);

        float dGankrMid = CheckWhoHasGankingAdvantage3v1(dMid, dSupport, dHardSupport, rMid);
        float dGankrCarry = CheckWhoHasGankingAdvantage3v2(dMid, dSupport, dOfflaner, rCarry, rHardSupport);
        float dGankrOfflaner = CheckWhoHasGankingAdvantage3v2(dMid, dHardSupport, dCarry, rOfflaner, rSupport);

        float gankingResultTeam1 = (rGankdMid + rGankdCarry + rGankdOfflaner) / 3;
        float gankingResultTeam2 = (dGankrMid + dGankrCarry + dGankrOfflaner) / 3;

        gankingResult = CalculateFloatResultOfAdvantages(gankingResultTeam1, gankingResultTeam2);

        return gankingResult;
    }

    private float CheckWhoHasGankingAdvantage3v2(Player rMid, Player rSupport, Player rOfflaner, Player dCarry, Player dHardSupport)
    {
        float gankingResult = 0.5f;

        float radiant1score = (rMid.determination + rMid.mindgaming + rMid.teamwork) / 3;
        float radiant2score = (rSupport.determination + rSupport.mindgaming + rSupport.teamwork) / 3;
        float radiant3score = (rOfflaner.determination + rOfflaner.mindgaming + rOfflaner.teamwork) / 3;

        // TODO: add factor that checks bonus if laning phase was good or bad against hero
        float radiantScoreTotal = (radiant1score + radiant2score + radiant3score) / 3;

        float dire1score = (dCarry.mapAwareness + dCarry.concentration + dCarry.reactionTime + dCarry.mindgaming) / 4;
        float dire2score = (dHardSupport.mapAwareness + dHardSupport.concentration + dHardSupport.reactionTime + dHardSupport.mindgaming) / 4;

        float direScoreTotal = (dire1score + dire2score) / 2;

        CalculateFloatResultOfAdvantages(radiantScoreTotal, direScoreTotal);

        return gankingResult;
    }

    private float CheckWhoHasGankingAdvantage3v1(Player rCore, Player rSupport, Player rHardSupport, Player dCore)
    {
        float gankingResult = 0.5f;

        float radiant1score = (rCore.determination + rCore.mindgaming + rCore.teamwork) / 3;
        float radiant2score = (rSupport.determination + rSupport.mindgaming + rSupport.teamwork) / 3;
        float radiant3score = (rHardSupport.determination + rHardSupport.mindgaming + rHardSupport.teamwork) / 3;

        // TODO: add factor that checks bonus if laning phase was good or bad against hero
        float radiantScoreTotal = (radiant1score + radiant2score + radiant3score) / 3;

        float direscore = (dCore.mapAwareness + dCore.concentration + dCore.reactionTime + dCore.mindgaming) / 4;

        CalculateFloatResultOfAdvantages(radiantScoreTotal, direscore);

        return gankingResult;
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
