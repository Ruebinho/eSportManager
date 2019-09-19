using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using UnityEngine.UI;
using System;

public class DotACanvasUIController : MonoBehaviour
{
    #region Variables
    [SerializeField] public Text nameUI;
    [SerializeField] public Text nicknameUI;
    [SerializeField] public Text ageUI;
    [SerializeField] public Text nationalityUI;

    [SerializeField] public Text logicalThinkingUI;
    [SerializeField] public Text decisionsUI;
    [SerializeField] public Text concentrationUI;
    [SerializeField] public Text determinationUI;
    [SerializeField] public Text handEyeCoordinationUI;
    [SerializeField] public Text gameMechanicsUI;
    [SerializeField] public Text reactionTimeUI;
    [SerializeField] public Text teamworkUI;
    [SerializeField] public Text leadershipUI;

    [SerializeField] public Text roleUI;
    [SerializeField] public Text farmingUI;
    [SerializeField] public Text supportingUI;
    [SerializeField] public Text teamfightUI;
    [SerializeField] public Text oneOnOneUI;
    [SerializeField] public Text lastHittingUI;
    [SerializeField] public Text mapAwarenessUI;
    [SerializeField] public Text mindgamingUI;
    #endregion
    public void DisplayPlayer(Player player)
    {
        GetPlayerValuesAsStringsAndInValuedColor(player);
    }

    private void GetPlayerValuesAsStringsAndInValuedColor(Player player)
    {
        DisplayPlayerPersonalData(player);

        DisplayPlayerAttributes(player);

        DisplayPlayerGameAttributes(player);
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

    private void ChangeUITextAndColorForAttribute(float playerAttribute, Text playerAttributeUI)
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
}
