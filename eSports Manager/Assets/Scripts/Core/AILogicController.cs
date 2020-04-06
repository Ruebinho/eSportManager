using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;
using static ESM.Character.CharacterGenerator;

public class AILogicController : MonoBehaviour
{
    public GlobalGameParameters ggp;
    public ContractGenerator cg;
    public GameDatabase gdb;

    List<StaffMember> potentialCandidates = new List<StaffMember>();

    private int amountTrainers = 0;
    private int amountScouts = 0;
    private int amountPRManagers = 0;
    private int amountDoctors = 0;
    private int amountDataAnalysts = 0;

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
        ResetStaffCounter();

        foreach (StaffMember sm in org.staffMembers)
        {
            CountExistingStaff(sm);
        }
        //Debug.Log(org.ToString());
        //Debug.Log(amountTrainers.ToString());
        return CheckIfStaffIsRequired();
    }

    private void CountExistingStaff(StaffMember sm)
    {
        if (sm.staffRole == StaffRole.Trainer)
        {
            amountTrainers++;
        }
        else if (sm.staffRole == StaffRole.Scout)
        {
            amountScouts++;
        }
        else if (sm.staffRole == StaffRole.PRManager)
        {
            amountPRManagers++;
        }
        else if (sm.staffRole == StaffRole.Doctor)
        {
            amountDoctors++;
        }
        else if (sm.staffRole == StaffRole.DataAnalyst)
        {
            amountDataAnalysts++;
        }
    }

    private bool CheckIfStaffIsRequired()
    {
        bool staffRequired = false;
        //Debug.Log(amountTrainers.ToString());
        //Debug.Log(amountScouts.ToString());
        //Debug.Log(amountPRManagers.ToString());
        //Debug.Log(amountDoctors.ToString());
        //Debug.Log(amountDataAnalysts.ToString());

        if (amountTrainers < ggp.maxTrainers)
        {
            staffRequired = true;
        }
        else if (amountScouts < ggp.maxScouts)
        {
            staffRequired = true;
        }
        else if (amountPRManagers < ggp.maxPRManagers)
        {
            staffRequired = true;
        }
        else if (amountDoctors < ggp.maxDoctors)
        {
            staffRequired = true;
        }
        else if (amountDataAnalysts < ggp.maxDataAnalysts)
        {
            staffRequired = true;
        }
        else
        {
            staffRequired = false;
        }
        return staffRequired;
    }

    internal StaffMember FindFittingCandidate(Organization org, StaffRole staffRoleRequired)
    {
        StaffMember staffSearchResult = null;
        if (potentialCandidates != null) { potentialCandidates.Clear(); }
        //Debug.Log(org.ToString());
        //TODO add fitting search; for now random
        if (staffRoleRequired != StaffRole.Default)
        {
            foreach (StaffMember smInGame in gdb.staffMembersInGame)
            {
                if (smInGame.staffRole == staffRoleRequired && !CheckIfSMHasActiveContract(smInGame))
                {
                    potentialCandidates.Add(smInGame);
                }
            }

            if (potentialCandidates.Count > 0)
            {
                float arrayLaenge = potentialCandidates.Count - 1f;
                int attributeinArray = (Int32)UnityEngine.Random.Range(0, arrayLaenge);
                staffSearchResult = potentialCandidates[attributeinArray];
                Debug.Log(staffSearchResult.ToString());
            }
        }
        return staffSearchResult;
    }

    private bool CheckIfSMHasActiveContract(StaffMember smInGame)
    {
        if (smInGame.careerContracts.Count > 0)
        {
            int lastContractIndex = smInGame.careerContracts.Count - 1;
            StaffContract staffContract = smInGame.careerContracts[lastContractIndex];
            if (staffContract.contractEndDateYear < ggp.gameTimeYear && staffContract.contractEndDateMonth < ggp.gameTimeMonth && staffContract.contractEndDateDay < ggp.gameTimeDay)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }

    }

    public StaffRole CheckWhichStaffRoleIsRequired(Organization org)
    {
        ResetStaffCounter();
        StaffRole requiredStaffRole = StaffRole.Default;
        Debug.Log(org.ToString());
        foreach (StaffMember sm in org.staffMembers)
        {
            //Debug.Log(sm.staffRole.ToString());
            CountExistingStaff(sm);
        }

        //Debug.Log(org.ToString());
        //Debug.Log(amountTrainers.ToString());
        //Debug.Log(amountScouts.ToString());
        //Debug.Log(amountPRManagers.ToString());
        //Debug.Log(amountDoctors.ToString());
        //Debug.Log(amountDataAnalysts.ToString());

        if (amountTrainers < ggp.maxTrainers)
        {
            //Debug.Log(amountTrainers.ToString());
            requiredStaffRole = StaffRole.Trainer;
        }

        else if (amountScouts < ggp.maxScouts)
        {
            requiredStaffRole = StaffRole.Scout;
        }

        else if (amountPRManagers < ggp.maxPRManagers)
        {
            requiredStaffRole = StaffRole.PRManager;
        }

        else if (amountDoctors < ggp.maxDoctors)
        {
            requiredStaffRole = StaffRole.Doctor;
        }

        else if (amountDataAnalysts < ggp.maxDataAnalysts)
        {
            requiredStaffRole = StaffRole.DataAnalyst;
        }
        else
        {
            requiredStaffRole = StaffRole.Default;
        }
        //Debug.Log(requiredStaffRole.ToString());
        return requiredStaffRole;
    }

    private void ResetStaffCounter()
    {
        amountTrainers = 0;
        amountScouts = 0;
        amountPRManagers = 0;
        amountDoctors = 0;
        amountDataAnalysts = 0;
    }
}
