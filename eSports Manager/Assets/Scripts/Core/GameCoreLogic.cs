using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoreLogic : MonoBehaviour
{
    public GlobalGameParameters globalGameParameters;
    public Calendar calendar;
    public UIController uiController;

    //customized Game parameters
    public Organization playerSelectedOrg = null;

    // Start is called before the first frame update
    void Start()
    {
        globalGameParameters = FindObjectOfType<GlobalGameParameters>();
        calendar = FindObjectOfType<Calendar>();
        uiController = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceGameTime()
    {
        // continue Date parameters
        Debug.Log("Continue date parameters");
        calendar.AdvanceTime();
        uiController.UpdateDateUI();

        // continue development of players



        // continue transfers

        // continue contracts

        //etc.



    }
}
