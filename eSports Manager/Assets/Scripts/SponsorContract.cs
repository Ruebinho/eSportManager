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

    public float sponsorBetrag;
    public SponsorArt sponsorArt;

    public enum SponsorArt { perSeason, perGame, perWin };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
