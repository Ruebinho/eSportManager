using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgGenerator : MonoBehaviour
{
    private string[] teamNameList;

    private string teamOGname;
    private float teamOGruhm;
    private Team[] teamOGteams;
    private Finanzen teamOGFinanzen;
    private Akademie teamOGAkademie;
    private Merch teamOGMerchandise;


    public Organization createTeamOG()
    {
        Organization teamOG = new Organization();

        return teamOG;
    }

}
