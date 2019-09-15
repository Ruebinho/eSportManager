using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamGenerator : MonoBehaviour
{
    private string[] teamNameList;

    #region Name Generation
    private void InitializeNameDatabase()
    {
        teamNameList = new string[] {
            "OG",
            "Evil Geniuses",
            "Team Liquid",
            "Vici Gaming",
            "LGD.PSG Gaming",
            "fnatic",
            "Alex",
            "Kyle",
            "Dirk",
            "Bernhard",
            "James",
            "Rick",
            "Sven",
            "Hugo"
                };

    }

    #endregion

}
