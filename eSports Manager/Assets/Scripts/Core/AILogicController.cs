using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;

public class AILogicController : MonoBehaviour
{
    public GlobalGameParameters ggp;
    public ContractGenerator cg;
    public GameDatabase gdb;

    private void Start()
    {
        ggp = FindObjectOfType<GlobalGameParameters>();
        cg = FindObjectOfType<ContractGenerator>();
        gdb = FindObjectOfType<GameDatabase>();
    }

    public StaffContract OfferContractToStaffMember(Organization org)
    {
        bool aiWantMember = DecideIfAIWantsStaffMember();

        StaffContract offeredContract = cg.GenerateStaffMemberContract(org);
        if (aiWantMember)
        {
            return offeredContract;
        }
        
        return offeredContract;
    }

    private bool DecideIfAIWantsStaffMember()
    {
        //TODO get real decision
        return true;
    }

    public void ScoutOtherPlayer()
    {
        bool aiWantPlayer = DecideIfAIWantsToScoutPlayer();
    }

    private bool DecideIfAIWantsToScoutPlayer()
    {
        // if Player has good avr. rating and good skillz
        throw new NotImplementedException();
    }

    internal bool CheckIfStaffIsNeeded(Organization org)
    {
        int amountTrainers = 0;
        int amountScouts = 0;
        int amountPRManagers = 0;
        int amountDoctors = 0;
        int amountDataAnalysts = 0;

        if (org.staffMembers.Count < 1)
        {
            return true;
        }
        else
        {
            foreach (StaffMember sm in org.staffMembers)
            {
                CountExistingStaff(ref amountTrainers, ref amountScouts, ref amountPRManagers, ref amountDoctors, ref amountDataAnalysts, sm);
            }

            return CheckIfStaffIsRequired(amountTrainers, amountScouts, amountPRManagers, amountDoctors, amountDataAnalysts);
        }
    }

    private static void CountExistingStaff(ref int amountTrainers, ref int amountScouts, ref int amountPRManagers, ref int amountDoctors, ref int amountDataAnalysts, StaffMember sm)
    {
        if (sm.staffRole.Equals(CharacterGenerator.StaffRole.Trainer))
        {
            amountTrainers++;
        }
        else if (sm.staffRole.Equals(CharacterGenerator.StaffRole.Scout))
        {
            amountScouts++;
        }
        else if (sm.staffRole.Equals(CharacterGenerator.StaffRole.Trainer))
        {
            amountPRManagers++;
        }
        else if (sm.staffRole.Equals(CharacterGenerator.StaffRole.Trainer))
        {
            amountDoctors++;
        }
        else if (sm.staffRole.Equals(CharacterGenerator.StaffRole.Trainer))
        {
            amountDataAnalysts++;
        }
    }

    private bool CheckIfStaffIsRequired(int amountTrainers, int amountScouts, int amountPRManagers, int amountDoctors, int amountDataAnalysts)
    {
        if (amountTrainers < ggp.maxTrainers)
        {
            return true;
        }

        else if (amountScouts < ggp.maxScouts)
        {
            return true;
        }

        else if (amountPRManagers < ggp.maxPRManagers)
        {
            return true;
        }

        else if (amountDoctors < ggp.maxDoctors)
        {
            return true;
        }

        else if (amountDataAnalysts < ggp.maxDataAnalysts)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal StaffMember FindFittingCandidate(Organization org)
    {
        //TODO add fitting search; for now random
        float arrayLaenge = gdb.staffMembersInGame.Count;
        int attributeinArray = (Int32)UnityEngine.Random.Range(0, arrayLaenge - 1f);

        return gdb.staffMembersInGame[attributeinArray];
    }
}
