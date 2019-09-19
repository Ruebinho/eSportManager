using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using System;

public class Player : MonoBehaviour
{
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
    #endregion

    #region gameData

    #endregion

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
        dotaCanvasUI.DisplayPlayer(this);
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
