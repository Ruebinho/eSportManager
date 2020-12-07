using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ESM.Character.CharacterGenerator;

public class GameCoreLogic : MonoBehaviour
{
    public GlobalGameParameters globalGameParameters;
    public Calendar calendar;
    public UIController uiController;

    public GameDatabase gdb;
    public AILogicController aiLogicController;

    public DotaMatch dotaMatch;

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

        dotaMatch = FindObjectOfType<DotaMatch>();
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

        // prepare Tournament Schedule for the year at the beginning of the season (different for every game)



        // continue development of players



        // continue transfers
        


        // continue contracts



        //fill up Staff Slots

        foreach (Organization org in gdb.orgsInGame)
        {
            //Debug.Log(aiLogicController.CheckIfStaffIsNeeded(org).ToString());
            if (org.isAIControlled)
            {
                CheckAndSignPotentialStaffMembers(org);
            }
        }

        foreach (StaffMember sm in gdb.staffMembersInGame)
        {
            if (sm.tec.potSC.Count > 0)
            {
                //Debug.Log(sm.tec.chosenSC.orgStaffMemberIsContractedTo.ToString());
            }
        }

        // consider ContractOffers
        //TODO make staff think about contracts for a few days

        for (var i = 0; i < gdb.staffMembersInGame.Count; i++)
        {
            if (gdb.staffMembersInGame[i].tec.potSC.Count < 1) { }
            else
            {
                foreach (StaffContract sc in gdb.staffMembersInGame[i].tec.potSC)
                {
                    gdb.staffMembersInGame[i].tec.CalculateTransferProbability(sc);
                }
            }
        }

        // decide on final contract

        //foreach (StaffMember sm in gdb.staffMembersInGame)
        //{
        //    //if (sm.tec.potSC.Count < 1) { break; }
        //    //else
        //    //{
        //    if (sm.tec.potSC != null)
        //    {
        //        foreach (StaffContract sc in sm.tec.potSC)
        //        {
        //            //Debug.Log(sc.orgStaffMemberIsContractedTo.ToString());
        //            if (sm.tec.chosenSC == null)
        //            {
        //                sm.tec.chosenSC = sc;
        //            }
        //            else if (sm.tec.chosenSC != null && sc.contractProbability >= sm.tec.chosenSC.contractProbability)
        //            {
        //                sm.tec.chosenSC = sc;
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //        }
        //    }
        //}
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
        //                continue;
        //            }
        //        }
        //    }
        //}


        // sign final contract

        //foreach (StaffMember sm in gdb.staffMembersInGame)
        //{
        //    if (sm.tec.chosenSC == null) { }
        //    else
        //    {
        //        sm.SignContract(sm.tec.chosenSC);
        //    }
        //}

        // if contract runs out, remove from List players bzw. staffmembers in team/org


        //simulate matches

        if (dotaMatch != null)
        {
            if (dotaMatch.matchTeam1 != null && dotaMatch.matchTeam2 != null)
            {
                dotaMatch.SimulateDotaMatch();
            }
        }
        
        //etc.



    }

    private void CheckAndSignPotentialStaffMembers(Organization org)
    {
        Debug.Log($"ORG: {org.name} ::: Checking Req Staff Role");
        StaffRole staffRoleRequired = aiLogicController.CheckWhichStaffRoleIsRequired(org);
        Debug.Log($"ORG: {org.name} ::: Req Staff Role is: {staffRoleRequired}");

        // if no staff is needed, return
        if (staffRoleRequired.Equals(StaffRole.Default)) { return; }

        Debug.Log($"ORG: {org.name} ::: Find Fitting Candidate");
        StaffMember potentialStaff = aiLogicController.FindFittingCandidate(org, staffRoleRequired);
        Debug.Log($"ORG: {org.name} ::: Fitting Candidate is: {potentialStaff}");


        StaffContract potentialContract = aiLogicController.OfferContractToStaffMember(org);


        if (potentialStaff != null)
        {
            potentialStaff.tec.ListStaffContractOffer(potentialContract);
            potentialStaff.tec.chosenSC = potentialContract;
            potentialStaff.SignContract(potentialStaff.tec.chosenSC);
        }
    }
}
