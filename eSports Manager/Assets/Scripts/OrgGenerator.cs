using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESM.Character
{
    public class OrgGenerator : MonoBehaviour
    {
        private CharacterGenerator charGen = null;

        private string[] teamNameList;

        public string teamOGname;
        public float teamOGruhm;
        public Team[] teamOGteams;
        public Finanzen teamOGFinanzen;
        public Akademie teamOGAkademie;
        public Merch teamOGMerchandise;


        public Organization createTeamOG()
        {
            Organization teamOG = new Organization();
            teamOG.orgName = teamOGname;
            teamOG.orgRuhm = teamOGruhm;
            teamOG.orgTeams = teamOGteams;
            teamOG.orgFinanzen = teamOGFinanzen;
            teamOG.orgAkademie = teamOGAkademie;
            teamOG.orgMerchandise = teamOGMerchandise;

            return teamOG;
        }

        private void Start()
        {
            charGen = FindObjectOfType<CharacterGenerator>();
        }

    }
}

