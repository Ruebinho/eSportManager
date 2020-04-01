using ESM.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffMember : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Staff Data")]
    #region gameData
    public bool isGeneratedPlayer = true;
    public List<StaffContract> careerContracts;
    public int initialContractInt = 0;
    public TransferEvaluationCalculator tec;
    #endregion

    [Header("Staff Personal Data")]
    #region v_Personal
    public string vorname;
    public string nachname;
    public int age;
    public string nationality;
    #endregion

    #region v_Attributes

    public CharacterGenerator.StaffRole staffRole;

    public float discipline;
    public float motivating;
    public float concentration;
    public float determination;
    public float adaptability;
    public float workingWithYoungsters;

    public float gameMechanics;
    public float mental;
    public float technical;
    public float tacticalKnowledge;
    
    public float judgingPlayerAbility;
    public float judgingPlayerPotential;

    public float physioTherapy;
    public float fitness;

    #endregion

    [Header("Technical Links")]
    CharacterGenerator charGen;
    DotACanvasUIController dotaCanvasUI;

    // Start is called before the first frame update
    void Start()
    {
        charGen = FindObjectOfType<CharacterGenerator>();
        dotaCanvasUI = FindObjectOfType<DotACanvasUIController>();
        tec = GetComponent<TransferEvaluationCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    GeneratePlayer();
        //    DisplayPlayerOnCanvas();
        //}
    }

    private void DisplayPlayerOnCanvas()
    {
        Debug.Log("Test");
        dotaCanvasUI = FindObjectOfType<DotACanvasUIController>();
        Debug.Log(dotaCanvasUI);
        //dotaCanvasUI.DisplayPlayer(this);
    }

    internal void SignContract(StaffContract chosenSC)
    {
        //Debug.Log(chosenSC.orgStaffMemberIsContractedTo.ToString());
        careerContracts.Add(chosenSC);
        chosenSC.orgStaffMemberIsContractedTo.AddStaffMemberToOrg(this);
        chosenSC = null;
    }

    //public float GetAverageRating()
    //{
    //    float totalPersonalAttributes = 9f;
    //    float totalGameAttributes = 7f;

    //    float averageRatingPersonalAttributes = 0f;
    //    float averageRatingGameAttributes = 0f;

    //    averageRatingPersonalAttributes = Mathf.Round((logicalThinking + decisions + concentration + determination + handEyeCoordination + gameMechanics + reactionTime + teamwork + leadership) / totalPersonalAttributes);
    //    averageRatingGameAttributes = Mathf.Round((farming + supporting + teamfight + oneOnOne + lastHitting + mapAwareness + mindgaming) / totalGameAttributes);

    //    return Mathf.Round((averageRatingPersonalAttributes + averageRatingGameAttributes) / 2);
    //}

    //public float GetAveragePotentialRating()
    //{
    //    float totalPersonalAttributes = 9f;
    //    float totalGameAttributes = 7f;

    //    float averagePotentialRatingPersonalAttributes = 0f;
    //    float averagePotentialRatingGameAttributes = 0f;

    //    averagePotentialRatingPersonalAttributes = Mathf.Round((logicalThinkingP + decisionsP + concentrationP + determinationP + handEyeCoordinationP + gameMechanicsP + reactionTimeP + teamworkP + leadershipP) / totalPersonalAttributes);
    //    averagePotentialRatingGameAttributes = Mathf.Round((farmingP + supportingP + teamfightP + oneOnOneP + lastHittingP + mapAwarenessP + mindgamingP) / totalGameAttributes);

    //    return Mathf.Round((averagePotentialRatingPersonalAttributes + averagePotentialRatingGameAttributes) / 2);
    //}
}
