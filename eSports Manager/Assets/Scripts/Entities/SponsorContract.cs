using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponsorContract : MonoBehaviour
{

    public Organization OrgSponsorIsContractedTo = null;
    public int contractStartDateDay = 1;
    public int contractStartDateMonth = 1;
    public int contractStartDateYear = 2000;
    public int contractEndDateDay = 1;
    public int contractEndDateMonth = 1;
    public int contractEndDateYear = 2099;

    public Sponsor sponsor;
    public float sponsorBetrag;
    public SponsorArt sponsorArt;

    public enum SponsorArt { perSeason, perGame, perWin };

    private GameDatabase gameDatabase;

    private void Start()
    {
        gameDatabase = FindObjectOfType<GameDatabase>();
    }

    public SponsorContract GenerateSponsorContract(Organization contractOrg, int ds, int ms, int ys, int de, int me, int ye)
    {
        SponsorContract generatedSC = new SponsorContract();

        generatedSC.OrgSponsorIsContractedTo = contractOrg;
        generatedSC.contractStartDateDay = ds;
        generatedSC.contractStartDateMonth = ms;
        generatedSC.contractStartDateYear = ys;
        generatedSC.contractEndDateDay = de;
        generatedSC.contractEndDateMonth = me;
        generatedSC.contractEndDateYear = ye;

        // add random sponsor
        generatedSC.sponsor = ChooseFittingSponsor();
        generatedSC.sponsorBetrag = ChooseFittingAmount();
        generatedSC.sponsorArt = ChooseFittingType();


        return generatedSC;
    }

    private SponsorArt ChooseFittingType()
    {
        return SponsorArt.perSeason;
    }

    private float ChooseFittingAmount()
    {
        return 10000;
    }

    private Sponsor ChooseFittingSponsor()
    {
        return gameDatabase.sponsorsInGame[1];
    }
}
