using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using System;

public class Player : MonoBehaviour
{
    [Header("Player Game Data")]
    #region gameData
    public bool currentAbilityIsScouted = false;
    public bool potentialIsScouted = false;
    #endregion

    [Header("Player Personal Data")]
    #region v_Personal
    public string vorname;
    public string nachname;
    public string nickname;
    public int age;
    public string nationality;
    #endregion
    #region v_Attributes
    public float logicalThinking;
    public float decisions;
    public float concentration;
    public float determination;
    public float handEyeCoordination;
    public float gameMechanics;
    public float reactionTime;
    public float teamwork;
    public float leadership;

    public float logicalThinkingP;
    public float decisionsP;
    public float concentrationP;
    public float determinationP;
    public float handEyeCoordinationP;
    public float gameMechanicsP;
    public float reactionTimeP;
    public float teamworkP;
    public float leadershipP;
    #endregion
    #region v_gameAttributes
    public CharacterGenerator.Role role;
    public float farming;
    public float supporting;
    public float teamfight;
    public float oneOnOne;
    public float lastHitting;
    public float mapAwareness;
    public float mindgaming;

    public float farmingP;
    public float supportingP;
    public float teamfightP;
    public float oneOnOneP;
    public float lastHittingP;
    public float mapAwarenessP;
    public float mindgamingP;
    #endregion

    [Header("Technical Links")]
    CharacterGenerator charGen;
    DotACanvasUIController dotaCanvasUI;

    // Start is called before the first frame update
    void Start()
    {
        charGen = GetComponent<CharacterGenerator>();
        dotaCanvasUI = FindObjectOfType<DotACanvasUIController>();
    }

    private void GeneratePlayer()
    {
        vorname = charGen.GetVorname();
        nachname = charGen.GetNachname();
        nickname = charGen.GetNickname();
        age = UnityEngine.Random.Range(14, 36);
        nationality = "Deutsch";

        charGen.GenerateAttributesForPlayer();
        logicalThinking = charGen.logicalThinking;
        decisions = charGen.decisions;
        concentration = charGen.concentration;
        determination = charGen.determination;
        handEyeCoordination = charGen.handEyeCoordination;
        gameMechanics = charGen.gameMechanics;
        reactionTime = charGen.reactionTime;
        teamwork = charGen.teamwork;
        leadership = charGen.leadership;
        farming = charGen.farming;
        supporting = charGen.supporting;
        teamfight = charGen.teamfight;
        oneOnOne = charGen.oneOnOne;
        lastHitting = charGen.lastHitting;
        mapAwareness = charGen.mapAwareness;
        mindgaming = charGen.mindgaming;

        charGen.GeneratePotentialsForPlayer();
        logicalThinkingP = charGen.logicalThinkingP;
        decisionsP = charGen.decisionsP;
        concentrationP = charGen.concentrationP;
        determinationP = charGen.determinationP;
        handEyeCoordinationP = charGen.handEyeCoordinationP;
        gameMechanicsP = charGen.gameMechanicsP;
        reactionTimeP = charGen.reactionTimeP;
        teamworkP = charGen.teamworkP;
        leadershipP = charGen.leadershipP;
        farmingP = charGen.farmingP;
        supportingP = charGen.supportingP;
        teamfightP = charGen.teamfightP;
        oneOnOneP = charGen.oneOnOneP;
        lastHittingP = charGen.lastHittingP;
        mapAwarenessP = charGen.mapAwarenessP;
        mindgamingP = charGen.mindgamingP;

        charGen.GenerateRoleForPlayer();
        role = charGen.role;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            GeneratePlayer();
            DisplayPlayerOnCanvas();
        }
    }

    private void DisplayPlayerOnCanvas()
    {
        Debug.Log("Test");
        dotaCanvasUI = FindObjectOfType<DotACanvasUIController>();
        Debug.Log(dotaCanvasUI);
        dotaCanvasUI.DisplayPlayer(this);
    }

    public float GetAverageRating()
    {
        float totalPersonalAttributes = 9f;
        float totalGameAttributes = 7f;

        float averageRatingPersonalAttributes = 0f;
        float averageRatingGameAttributes = 0f;

        averageRatingPersonalAttributes = Mathf.Round((logicalThinking + decisions + concentration + determination + handEyeCoordination + gameMechanics + reactionTime + teamwork + leadership) / totalPersonalAttributes);
        averageRatingGameAttributes = Mathf.Round((farming + supporting + teamfight + oneOnOne + lastHitting + mapAwareness + mindgaming) / totalGameAttributes);

        return Mathf.Round((averageRatingPersonalAttributes + averageRatingGameAttributes) / 2);
    }

    public float GetAveragePotentialRating()
    {
        float totalPersonalAttributes = 9f;
        float totalGameAttributes = 7f;

        float averagePotentialRatingPersonalAttributes = 0f;
        float averagePotentialRatingGameAttributes = 0f;

        averagePotentialRatingPersonalAttributes = Mathf.Round((logicalThinkingP + decisionsP + concentrationP + determinationP + handEyeCoordinationP + gameMechanicsP + reactionTimeP + teamworkP + leadershipP) / totalPersonalAttributes);
        averagePotentialRatingGameAttributes = Mathf.Round((farmingP + supportingP + teamfightP + oneOnOneP + lastHittingP + mapAwarenessP + mindgamingP) / totalGameAttributes);

        return Mathf.Round((averagePotentialRatingPersonalAttributes + averagePotentialRatingGameAttributes) / 2);
    }

    //private void PrintCreatedPlayer()
    //{
    //    Debug.Log(vorname + " " + "'" + nickname + "'" + " " + nachname);
    //    Debug.Log(age);
    //    Debug.Log(nationality);
    //    Debug.Log("logicalThinking: " + logicalThinking);
    //    Debug.Log("decisions: " + decisions);
    //    Debug.Log("determination: " + determination);
    //    Debug.Log("handEyeCoordination: " + handEyeCoordination);
    //    Debug.Log("gameMechanics: " + gameMechanics);
    //    Debug.Log("reactionTime: " + reactionTime);
    //    Debug.Log("teamwork: " + teamwork);
    //    Debug.Log("leadership: " + leadership);
    //    Debug.Log("farming: " + farming);
    //    Debug.Log("supporting: " + supporting);
    //    Debug.Log("teamfight: " + teamfight);
    //    Debug.Log("oneOnOne: " + oneOnOne);
    //    Debug.Log("lastHitting: " + lastHitting);
    //    Debug.Log("mapAwareness: " + mapAwareness);
    //    Debug.Log("mindgaming: " + mindgaming);
    //    Debug.Log("Role: " + role);
    //}
}
