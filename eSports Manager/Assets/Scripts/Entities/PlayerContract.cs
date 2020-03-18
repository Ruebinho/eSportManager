using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContract : MonoBehaviour
{
    public Team teamPlayerIsContractedTo = null;
    public int contractStartDateDay = 1;
    public int contractStartDateMonth = 1;
    public int contractStartDateYear = 2000;
    public int contractEndDateDay = 1;
    public int contractEndDateMonth = 1;
    public int contractEndDateYear = 2099;

    public float wage = 1f;

    // Start is called before the first frame update
    public PlayerContract GeneratePlayerContract(Team contractTeam, int ds, int ms, int ys, int de, int me, int ye, float wage)
    {
        PlayerContract generatedPC = new PlayerContract();

        #region team and duration data
        generatedPC.teamPlayerIsContractedTo = contractTeam;
        generatedPC.contractStartDateDay = ds;
        generatedPC.contractStartDateMonth = ms;
        generatedPC.contractStartDateYear = ys;
        generatedPC.contractEndDateDay = de;
        generatedPC.contractEndDateMonth = me;
        generatedPC.contractEndDateYear = ye;
        #endregion

        #region financial data
        generatedPC.wage = wage;

        #endregion
        
        return generatedPC;
    }
}
