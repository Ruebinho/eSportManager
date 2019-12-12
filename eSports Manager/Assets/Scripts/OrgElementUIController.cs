using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrgElementUIController : MonoBehaviour
{
    public Organization orgData = null;

    // Start is called before the first frame update
    void Start()
    {
        //playerData = GetComponent<Player>();
        PopulateUIWithOrgData();
        setupButton();

    }

    private void setupButton()
    {
        Button playerButton = GetComponent<Button>();
        playerButton.onClick.AddListener(clickSelectOrg);
    }

    public void clickSelectOrg()
    {
        FindObjectOfType<UIController>().SelectOrg(this.gameObject);
        FindObjectOfType<UIController>().currentSelectedOrg = orgData;
    }

    private void PopulateUIWithOrgData()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Name")
            {
                Debug.Log(orgData.orgName.ToString());
                child.GetComponent<TextMeshProUGUI>().text = orgData.orgName.ToString();
            }

        }
    }
}
