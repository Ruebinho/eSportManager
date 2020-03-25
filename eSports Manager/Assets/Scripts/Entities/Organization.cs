using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organization : MonoBehaviour
{
    public string orgName;
    public float orgRuhm;
    public List<Team> orgTeams;
    public List<Finanzen> orgFinanzen;
    public List<Akademie> orgAkademie;
    public List<Merch> orgMerchandise;
    public List<StaffMember> staffMembers;

    public bool isAIControlled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStaffMemberToOrg(StaffMember sm)
    {
        staffMembers.Add(sm);
    }
}
