using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoreLogic : MonoBehaviour
{
    public GlobalGameParameters globalGameParameters;
    public Calendar calendar;
    public UIController uiController;

    public GameDatabase gdb;
    public AILogicController aiLogicController;

    //customized Game parameters
    public Organization playerSelectedOrg = null;

    // Start is called before the first frame update
    void Start()
    {
        globalGameParameters = FindObjectOfType<GlobalGameParameters>();
        calendar = FindObjectOfType<Calendar>();
        uiController = FindObjectOfType<UIController>();
        gdb = FindObjectOfType<GameDatabase>();
        aiLogicController = FindObjectOfType<AILogicController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AdvanceGameTime()
    {
        // continue Date parameters

        calendar.AdvanceTime();
        uiController.UpdateDateUI();

        // continue development of players



        // continue transfers

        // continue contracts


        //fill up Staff Slots

        foreach (Organization org in gdb.orgsInGame)
        {
            if (org.isAIControlled && aiLogicController.CheckIfStaffIsNeeded(org))
            {
                StaffMember potentialStaff = aiLogicController.FindFittingCandidate(org);
                StaffContract potentialContract = aiLogicController.OfferContractToStaffMember(org);
                potentialStaff.tec.ListStaffContractOffer(potentialContract);
            }
        }

        Debug.Log(gdb.staffMembersInGame.Count);
        // consider ContractOffers
        //TODO make staff think about contracts for a few days

        for (var i = 0; i < gdb.staffMembersInGame.Count; i++)
        {
            if (gdb.staffMembersInGame[i].tec.potSC.Count < 1) { break; }
            else
            {
                foreach (StaffContract sc in gdb.staffMembersInGame[i].tec.potSC)
                {
                    gdb.staffMembersInGame[i].tec.CalculateTransferProbability(sc);
                }
            }
        }

        // decide on final contract

        foreach (StaffMember sm in gdb.staffMembersInGame)
        {
            //if (sm.tec.potSC.Count < 1) { break; }
            //else
            //{
            if (sm.tec.potSC != null)
            {
                foreach (StaffContract sc in sm.tec.potSC)
                {

                    if (sm.tec.chosenSC = null)
                    {
                        sm.tec.chosenSC = sc;
                    }
                    else if (sm.tec.chosenSC != null && sc.contractProbability >= sm.tec.chosenSC.contractProbability)
                    {
                        sm.tec.chosenSC = sc;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        //}
    

        //for (var i = 0; i < gdb.staffMembersInGame.Count; i++)
        //{
        //    Debug.Log(gdb.staffMembersInGame[i]);
        //    if (gdb.staffMembersInGame[i].tec.potSC.Count < 1) { break; }
        //    else
        //    {
        //        Debug.Log("cheko");
        //        foreach (StaffContract sc in gdb.staffMembersInGame[i].tec.potSC)
        //        {
        //            if (sc.contractProbability > gdb.staffMembersInGame[i].tec.chosenSC.contractProbability)
        //            {
        //                gdb.staffMembersInGame[i].tec.chosenSC = sc;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}


        // sign final contract

        foreach (StaffMember sm in gdb.staffMembersInGame)
        {
            Debug.Log(sm.tec.chosenSC);
            if (sm.tec.chosenSC == null) { break; }
            else
            {
                sm.SignContract(sm.tec.chosenSC);
            }
        }

        // if contract runs out, remove from List players bzw. staffmembers in team/org

        //etc.



    }
}
