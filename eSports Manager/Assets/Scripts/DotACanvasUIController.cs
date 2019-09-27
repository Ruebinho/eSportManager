using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using UnityEngine.UI;
using System;
using TMPro;

public class DotACanvasUIController : MonoBehaviour
{
    #region Variables
    [SerializeField] public TextMeshProUGUI nameUI;
    [SerializeField] public TextMeshProUGUI nicknameUI;
    [SerializeField] public TextMeshProUGUI ageUI;
    [SerializeField] public TextMeshProUGUI nationalityUI;

    [SerializeField] public TextMeshProUGUI logicalThinkingUI;
    [SerializeField] public TextMeshProUGUI decisionsUI;
    [SerializeField] public TextMeshProUGUI concentrationUI;
    [SerializeField] public TextMeshProUGUI determinationUI;
    [SerializeField] public TextMeshProUGUI handEyeCoordinationUI;
    [SerializeField] public TextMeshProUGUI gameMechanicsUI;
    [SerializeField] public TextMeshProUGUI reactionTimeUI;
    [SerializeField] public TextMeshProUGUI teamworkUI;
    [SerializeField] public TextMeshProUGUI leadershipUI;

    [SerializeField] public TextMeshProUGUI roleUI;
    [SerializeField] public TextMeshProUGUI farmingUI;
    [SerializeField] public TextMeshProUGUI supportingUI;
    [SerializeField] public TextMeshProUGUI teamfightUI;
    [SerializeField] public TextMeshProUGUI oneOnOneUI;
    [SerializeField] public TextMeshProUGUI lastHittingUI;
    [SerializeField] public TextMeshProUGUI mapAwarenessUI;
    [SerializeField] public TextMeshProUGUI mindgamingUI;

    [SerializeField] public TextMeshProUGUI logicalThinkingPUI;
    [SerializeField] public TextMeshProUGUI decisionsPUI;
    [SerializeField] public TextMeshProUGUI concentrationPUI;
    [SerializeField] public TextMeshProUGUI determinationPUI;
    [SerializeField] public TextMeshProUGUI handEyeCoordinationPUI;
    [SerializeField] public TextMeshProUGUI gameMechanicsPUI;
    [SerializeField] public TextMeshProUGUI reactionTimePUI;
    [SerializeField] public TextMeshProUGUI teamworkPUI;
    [SerializeField] public TextMeshProUGUI leadershipPUI;

    [SerializeField] public TextMeshProUGUI farmingPUI;
    [SerializeField] public TextMeshProUGUI supportingPUI;
    [SerializeField] public TextMeshProUGUI teamfightPUI;
    [SerializeField] public TextMeshProUGUI oneOnOnePUI;
    [SerializeField] public TextMeshProUGUI lastHittingPUI;
    [SerializeField] public TextMeshProUGUI mapAwarenessPUI;
    [SerializeField] public TextMeshProUGUI mindgamingPUI;
    #endregion
    public void DisplayPlayer(Player player)
    {
        GetPlayerValuesAsStringsAndInValuedColor(player);
    }

    private void GetPlayerValuesAsStringsAndInValuedColor(Player player)
    {
        DisplayPlayerPersonalData(player);

        //only display attributes if is owned player or potential is scouted
        if (player.currentAbilityIsScouted)
        {
            DisplayPlayerAttributes(player);

            DisplayPlayerGameAttributes(player);
        }
        else
        {
            SetPlayerAttributesToNA();
        }

        if (player.potentialIsScouted)
        {
            DisplayPlayerAttributesPotentials(player);

            DisplayPlayerGameAttributesPotentials(player);
        }
        else
        {
            SetPlayerPotentialsToNA();
        }

    }

    private void DisplayPlayerPersonalData(Player player)
    {
        nameUI.text = player.vorname.ToString() + " " + player.nachname.ToString();
        nicknameUI.text = player.nickname.ToString();
        ageUI.text = player.age.ToString();
        nationalityUI.text = player.nationality.ToString();
    }

    private void DisplayPlayerAttributes(Player player)
    {
        ChangeUITextAndColorForAttribute(player.logicalThinking, logicalThinkingUI);
        ChangeUITextAndColorForAttribute(player.decisions, decisionsUI);
        ChangeUITextAndColorForAttribute(player.concentration, concentrationUI);
        ChangeUITextAndColorForAttribute(player.determination, determinationUI);
        ChangeUITextAndColorForAttribute(player.handEyeCoordination, handEyeCoordinationUI);
        ChangeUITextAndColorForAttribute(player.gameMechanics, gameMechanicsUI);
        ChangeUITextAndColorForAttribute(player.reactionTime, reactionTimeUI);
        ChangeUITextAndColorForAttribute(player.teamwork, teamworkUI);
        ChangeUITextAndColorForAttribute(player.leadership, leadershipUI);
    }

    private void DisplayPlayerGameAttributes(Player player)
    {
        roleUI.text = player.role.ToString();

        ChangeUITextAndColorForAttribute(player.farming, farmingUI);
        ChangeUITextAndColorForAttribute(player.supporting, supportingUI);
        ChangeUITextAndColorForAttribute(player.teamfight, teamfightUI);
        ChangeUITextAndColorForAttribute(player.oneOnOne, oneOnOneUI);
        ChangeUITextAndColorForAttribute(player.lastHitting, lastHittingUI);
        ChangeUITextAndColorForAttribute(player.mapAwareness, mapAwarenessUI);
        ChangeUITextAndColorForAttribute(player.mindgaming, mindgamingUI);
    }

    private void DisplayPlayerGameAttributesPotentials(Player player)
    {
        ChangeUITextAndColorForAttribute(player.logicalThinkingP, logicalThinkingPUI);
        ChangeUITextAndColorForAttribute(player.decisionsP, decisionsPUI);
        ChangeUITextAndColorForAttribute(player.concentrationP, concentrationPUI);
        ChangeUITextAndColorForAttribute(player.determinationP, determinationPUI);
        ChangeUITextAndColorForAttribute(player.handEyeCoordinationP, handEyeCoordinationPUI);
        ChangeUITextAndColorForAttribute(player.gameMechanicsP, gameMechanicsPUI);
        ChangeUITextAndColorForAttribute(player.reactionTimeP, reactionTimePUI);
        ChangeUITextAndColorForAttribute(player.teamworkP, teamworkPUI);
        ChangeUITextAndColorForAttribute(player.leadershipP, leadershipPUI);
    }

    private void DisplayPlayerAttributesPotentials(Player player)
    {
        ChangeUITextAndColorForAttribute(player.farmingP, farmingPUI);
        ChangeUITextAndColorForAttribute(player.supportingP, supportingPUI);
        ChangeUITextAndColorForAttribute(player.teamfightP, teamfightPUI);
        ChangeUITextAndColorForAttribute(player.oneOnOneP, oneOnOnePUI);
        ChangeUITextAndColorForAttribute(player.lastHittingP, lastHittingPUI);
        ChangeUITextAndColorForAttribute(player.mapAwarenessP, mapAwarenessPUI);
        ChangeUITextAndColorForAttribute(player.mindgamingP, mindgamingPUI);
    }

    private void ChangeUITextAndColorForAttribute(float playerAttribute, TextMeshProUGUI playerAttributeUI)
    {
        playerAttributeUI.text = ChangeUITextPerAttribute(playerAttribute);
        playerAttributeUI.color = ChangeUITextColorPerAttributeValue(playerAttribute);
    }

    private Color ChangeUITextColorPerAttributeValue(float playerAttribute)
    {
        switch (playerAttribute)
        {
            case float n when (n <= 10):
                return Color.grey; // Grey
            case float n when (n <= 25):
                return Color.red;
            case float n when (n <= 40):
                return new Color(255, 140, 0); //Orange 
            case float n when (n <= 55):
                return Color.yellow;
            case float n when (n <= 70):
                return Color.green;
            case float n when (n <= 85):
                return Color.blue;
            case float n when (n <= 95):
                return Color.blue;
            case float n when (n <= 99):
                return Color.cyan;
            case float n when (n <= 100):
                return new Color(218, 165, 32); //Gold 

            default:
                return Color.white;

        }
    }

    private static string ChangeUITextPerAttribute(float playerAttribute)
    {
        return playerAttribute.ToString();
    }

    private void SetPlayerAttributesToNA()
    {
        ChangePlayerAttributesToNA(logicalThinkingUI);
        ChangePlayerAttributesToNA(decisionsUI);
        ChangePlayerAttributesToNA(concentrationUI);
        ChangePlayerAttributesToNA(determinationUI);
        ChangePlayerAttributesToNA(handEyeCoordinationUI);
        ChangePlayerAttributesToNA(gameMechanicsUI);
        ChangePlayerAttributesToNA(reactionTimeUI);
        ChangePlayerAttributesToNA(teamworkUI);
        ChangePlayerAttributesToNA(leadershipUI);

        ChangePlayerAttributesToNA(farmingUI);
        ChangePlayerAttributesToNA(supportingUI);
        ChangePlayerAttributesToNA(teamfightUI);
        ChangePlayerAttributesToNA(oneOnOneUI);
        ChangePlayerAttributesToNA(lastHittingUI);
        ChangePlayerAttributesToNA(gameMechanicsUI);
        ChangePlayerAttributesToNA(mapAwarenessUI);
        ChangePlayerAttributesToNA(mindgamingUI);
    }

    private void SetPlayerPotentialsToNA()
    {
        ChangePlayerAttributesToNA(logicalThinkingPUI);
        ChangePlayerAttributesToNA(decisionsPUI);
        ChangePlayerAttributesToNA(concentrationPUI);
        ChangePlayerAttributesToNA(determinationPUI);
        ChangePlayerAttributesToNA(handEyeCoordinationPUI);
        ChangePlayerAttributesToNA(gameMechanicsPUI);
        ChangePlayerAttributesToNA(reactionTimePUI);
        ChangePlayerAttributesToNA(teamworkPUI);
        ChangePlayerAttributesToNA(leadershipPUI);

        ChangePlayerAttributesToNA(farmingPUI);
        ChangePlayerAttributesToNA(supportingPUI);
        ChangePlayerAttributesToNA(teamfightPUI);
        ChangePlayerAttributesToNA(oneOnOnePUI);
        ChangePlayerAttributesToNA(lastHittingPUI);
        ChangePlayerAttributesToNA(gameMechanicsPUI);
        ChangePlayerAttributesToNA(mapAwarenessPUI);
        ChangePlayerAttributesToNA(mindgamingPUI);
    }

    private void ChangePlayerAttributesToNA(TextMeshProUGUI playerAttributeUI)
    {
        playerAttributeUI.text = "N/A";
        playerAttributeUI.color = Color.white;
    }
}
