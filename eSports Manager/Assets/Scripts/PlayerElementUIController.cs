using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerElementUIController : MonoBehaviour
{
    public Player playerData = null;
    [SerializeField] public Sprite star0;
    [SerializeField] public Sprite star05;
    [SerializeField] public Sprite star1;

    [SerializeField] public GameObject starCA1;
    [SerializeField] public GameObject starCA2;
    [SerializeField] public GameObject starCA3;
    [SerializeField] public GameObject starCA4;
    [SerializeField] public GameObject starCA5;

    [SerializeField] public GameObject starPA1;
    [SerializeField] public GameObject starPA2;
    [SerializeField] public GameObject starPA3;
    [SerializeField] public GameObject starPA4;
    [SerializeField] public GameObject starPA5;

    // Start is called before the first frame update
    void Start()
    {
        //playerData = GetComponent<Player>();
        PopulateUIWithPlayerData();
        setupButton();

        if (playerData.currentAbilityIsScouted)
        {
            ConvertPlayerAttributeIntoStarRating();
        }

        if (playerData.potentialIsScouted)
        {
            ConvertPlayerAttributePotentialIntoStarRating();
        }
    }

    private void setupButton()
    {
        Button playerButton = GetComponent<Button>();
        playerButton.onClick.AddListener(clickSelectPlayer);
    }

    public void clickSelectPlayer()
    {
        FindObjectOfType<UIController>().SelectPlayer(this.gameObject);
    }

    private void ConvertPlayerAttributeIntoStarRating()
    {
        float averageRating = playerData.GetAverageRating();
        float starRating = CalculateStarRating(averageRating);
        SetStarSpritesAccordingToStarRating(starRating);
    }

    private void ConvertPlayerAttributePotentialIntoStarRating()
    {
        float averagePotentialRating = playerData.GetAveragePotentialRating();
        float starRating = CalculateStarRating(averagePotentialRating);
        SetStarSpritesAccordingToPotentialStarRating(starRating);
    }

    private void SetStarSpritesAccordingToStarRating(float starRating)
    {
        switch (starRating)
        {
            case 0.5f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star05;
                starCA2.GetComponent<SpriteRenderer>().sprite = star0;
                starCA3.GetComponent<SpriteRenderer>().sprite = star0;
                starCA4.GetComponent<SpriteRenderer>().sprite = star0;
                starCA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 1f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star1;
                starCA2.GetComponent<SpriteRenderer>().sprite = star0;
                starCA3.GetComponent<SpriteRenderer>().sprite = star0;
                starCA4.GetComponent<SpriteRenderer>().sprite = star0;
                starCA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 1.5f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star1;
                starCA2.GetComponent<SpriteRenderer>().sprite = star05;
                starCA3.GetComponent<SpriteRenderer>().sprite = star0;
                starCA4.GetComponent<SpriteRenderer>().sprite = star0;
                starCA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 2f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star1;
                starCA2.GetComponent<SpriteRenderer>().sprite = star1;
                starCA3.GetComponent<SpriteRenderer>().sprite = star0;
                starCA4.GetComponent<SpriteRenderer>().sprite = star0;
                starCA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 2.5f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star1;
                starCA2.GetComponent<SpriteRenderer>().sprite = star1;
                starCA3.GetComponent<SpriteRenderer>().sprite = star05;
                starCA4.GetComponent<SpriteRenderer>().sprite = star0;
                starCA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 3f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star1;
                starCA2.GetComponent<SpriteRenderer>().sprite = star1;
                starCA3.GetComponent<SpriteRenderer>().sprite = star1;
                starCA4.GetComponent<SpriteRenderer>().sprite = star0;
                starCA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 3.5f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star1;
                starCA2.GetComponent<SpriteRenderer>().sprite = star1;
                starCA3.GetComponent<SpriteRenderer>().sprite = star1;
                starCA4.GetComponent<SpriteRenderer>().sprite = star05;
                starCA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 4f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star1;
                starCA2.GetComponent<SpriteRenderer>().sprite = star1;
                starCA3.GetComponent<SpriteRenderer>().sprite = star1;
                starCA4.GetComponent<SpriteRenderer>().sprite = star1;
                starCA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 4.5f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star1;
                starCA2.GetComponent<SpriteRenderer>().sprite = star1;
                starCA3.GetComponent<SpriteRenderer>().sprite = star1;
                starCA4.GetComponent<SpriteRenderer>().sprite = star1;
                starCA5.GetComponent<SpriteRenderer>().sprite = star05;
                break;

            case 5f:
                starCA1.GetComponent<SpriteRenderer>().sprite = star1;
                starCA2.GetComponent<SpriteRenderer>().sprite = star1;
                starCA3.GetComponent<SpriteRenderer>().sprite = star1;
                starCA4.GetComponent<SpriteRenderer>().sprite = star1;
                starCA5.GetComponent<SpriteRenderer>().sprite = star1;
                break;

            default:
                Debug.Log("Error at Sprite Setting With StarRating");
                break;
        }
    }

    private void SetStarSpritesAccordingToPotentialStarRating(float starRating)
    {
        switch (starRating)
        {
            case 0.5f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star05;
                starPA2.GetComponent<SpriteRenderer>().sprite = star0;
                starPA3.GetComponent<SpriteRenderer>().sprite = star0;
                starPA4.GetComponent<SpriteRenderer>().sprite = star0;
                starPA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 1f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star1;
                starPA2.GetComponent<SpriteRenderer>().sprite = star0;
                starPA3.GetComponent<SpriteRenderer>().sprite = star0;
                starPA4.GetComponent<SpriteRenderer>().sprite = star0;
                starPA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 1.5f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star1;
                starPA2.GetComponent<SpriteRenderer>().sprite = star05;
                starPA3.GetComponent<SpriteRenderer>().sprite = star0;
                starPA4.GetComponent<SpriteRenderer>().sprite = star0;
                starPA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 2f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star1;
                starPA2.GetComponent<SpriteRenderer>().sprite = star1;
                starPA3.GetComponent<SpriteRenderer>().sprite = star0;
                starPA4.GetComponent<SpriteRenderer>().sprite = star0;
                starPA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 2.5f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star1;
                starPA2.GetComponent<SpriteRenderer>().sprite = star1;
                starPA3.GetComponent<SpriteRenderer>().sprite = star05;
                starPA4.GetComponent<SpriteRenderer>().sprite = star0;
                starPA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 3f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star1;
                starPA2.GetComponent<SpriteRenderer>().sprite = star1;
                starPA3.GetComponent<SpriteRenderer>().sprite = star1;
                starPA4.GetComponent<SpriteRenderer>().sprite = star0;
                starPA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 3.5f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star1;
                starPA2.GetComponent<SpriteRenderer>().sprite = star1;
                starPA3.GetComponent<SpriteRenderer>().sprite = star1;
                starPA4.GetComponent<SpriteRenderer>().sprite = star05;
                starPA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 4f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star1;
                starPA2.GetComponent<SpriteRenderer>().sprite = star1;
                starPA3.GetComponent<SpriteRenderer>().sprite = star1;
                starPA4.GetComponent<SpriteRenderer>().sprite = star1;
                starPA5.GetComponent<SpriteRenderer>().sprite = star0;
                break;

            case 4.5f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star1;
                starPA2.GetComponent<SpriteRenderer>().sprite = star1;
                starPA3.GetComponent<SpriteRenderer>().sprite = star1;
                starPA4.GetComponent<SpriteRenderer>().sprite = star1;
                starPA5.GetComponent<SpriteRenderer>().sprite = star05;
                break;

            case 5f:
                starPA1.GetComponent<SpriteRenderer>().sprite = star1;
                starPA2.GetComponent<SpriteRenderer>().sprite = star1;
                starPA3.GetComponent<SpriteRenderer>().sprite = star1;
                starPA4.GetComponent<SpriteRenderer>().sprite = star1;
                starPA5.GetComponent<SpriteRenderer>().sprite = star1;
                break;

            default:
                Debug.Log("Error at Sprite Setting With StarRating");
                break;
        }
    }
    private float CalculateStarRating(float averageRating)
    {
        if (averageRating < 10f)
        {
            return 0.5f;
        }
        else if (averageRating < 20f && averageRating >= 10f)
        {
            return 1f;
        }
        else if (averageRating < 30f && averageRating >= 20f)
        {
            return 1.5f;
        }
        else if (averageRating < 40f && averageRating >= 30f)
        {
            return 2f;
        }
        else if (averageRating < 50f && averageRating >= 40f)
        {
            return 2.5f;
        }
        else if (averageRating < 60f && averageRating >= 50f)
        {
            return 3f;
        }
        else if (averageRating < 70f && averageRating >= 60f)
        {
            return 3.5f;
        }
        else if (averageRating < 80f && averageRating >= 70f)
        {
            return 4f;
        }
        else if (averageRating < 90f && averageRating >= 80f)
        {
            return 4.5f;
        }
        else if (averageRating < 101f && averageRating >= 90f)
        {
            return 5f;
        }
        else
        {
            return 0f;
        }
    }

    private void PopulateUIWithPlayerData()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Name")
            {
                child.GetComponent<TextMeshProUGUI>().text = playerData.vorname.ToString() + " " + playerData.nachname.ToString();
            }

            if (child.name == "Nickname")
            {
                child.GetComponent<TextMeshProUGUI>().text = playerData.nickname.ToString();
            }

            if (child.name == "Age")
            {
                child.GetComponent<TextMeshProUGUI>().text = playerData.age.ToString();
            }

            if (child.name == "Position")
            {
                child.GetComponent<TextMeshProUGUI>().text = playerData.role.ToString();
            }
        }
    }
}
