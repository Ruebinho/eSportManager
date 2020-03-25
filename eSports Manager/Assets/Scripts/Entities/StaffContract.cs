using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffContract : MonoBehaviour
{
    public StaffContract scPrefab;
    public Organization orgStaffMemberIsContractedTo = null;
    public int contractStartDateDay = 1;
    public int contractStartDateMonth = 1;
    public int contractStartDateYear = 2000;
    public int contractEndDateDay = 1;
    public int contractEndDateMonth = 1;
    public int contractEndDateYear = 2099;

    public float wage = 1f;

    public float contractProbability = 0f;

    // Start is called before the first frame update
    public StaffContract GenerateStaffContract(Organization contractOrg, int ds, int ms, int ys, int de, int me, int ye, float wage)
    {
        StaffContract generatedSC = scPrefab;

        #region org and duration data
        generatedSC.orgStaffMemberIsContractedTo = contractOrg;
        generatedSC.contractStartDateDay = ds;
        generatedSC.contractStartDateMonth = ms;
        generatedSC.contractStartDateYear = ys;
        generatedSC.contractEndDateDay = de;
        generatedSC.contractEndDateMonth = me;
        generatedSC.contractEndDateYear = ye;
        #endregion

        #region financial data
        generatedSC.wage = wage;

        #endregion

        return generatedSC;
    }
}
