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

        if (org.staffMembers.Count.Equals(0))
        {
            return true;
        }
        else
        {
            foreach (StaffMember sm in org.staffMembers)
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

            if (amountTrainers < ggp.maxTrainers)
            {
                return true;
            }

            if (amountScouts < ggp.maxScouts)
            {
                return true;
            }

            if (amountPRManagers < ggp.maxPRManagers)
            {
                return true;
            }

            if (amountDoctors < ggp.maxDoctors)
            {
                return true;
            }

            if (amountDataAnalysts < ggp.maxDataAnalysts)
            {
                return true;
            }

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
