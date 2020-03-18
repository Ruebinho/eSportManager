using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClickTeamUICustomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setupButton();
    }

    private void setupButton()
    {
        Button playerButton = GetComponent<Button>();
        playerButton.onClick.AddListener(clickSelectPlayer);
    }

    public void clickSelectPlayer()
    {
        FindObjectOfType<TeamOverviewCanvasUIController>().InstantiatePlayerElementsForTeam(FindObjectOfType<OrgTeamOverviewCanvasUIController>().currentSelectedTeamUI.GetComponent<TeamElementUIController>().teamData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
