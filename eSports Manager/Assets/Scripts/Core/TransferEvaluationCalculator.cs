using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferEvaluationCalculator : MonoBehaviour
{
    public List<PlayerContract> potPC;
    public List<StaffContract> potSC;

    public PlayerContract chosenPC;
    public StaffContract chosenSC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ListPlayerContractOffer(PlayerContract pc)
    {
        potPC.Add(pc);
    }

    public void ListStaffContractOffer(StaffContract sc)
    {
        //Debug.Log(sc.orgStaffMemberIsContractedTo.ToString());
        potSC.Add(sc);
    }

    internal void CalculateTransferProbability(StaffContract sc)
    {
        //TODO calculate a reasonable value
        sc.contractProbability = 50f;
    }



    //TODO: implement transfer thinking in transfers
    // if org ruhm is lower < last one and age < 32 -> no
    // if wage offered < anticipated -> no
    // etc.
}
