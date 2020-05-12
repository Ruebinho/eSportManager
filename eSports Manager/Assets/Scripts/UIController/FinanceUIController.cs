using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinanceUIController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI kontostandUI;

    public void DisplayFinanceUIValues(Organization org)
    {
        PutFinancialDetailsOnUIForSelectedOrg(org);
    }

    private void PutFinancialDetailsOnUIForSelectedOrg(Organization org)
    {
        kontostandUI.text = org.orgFinanzen[0].kontostand.ToString() + " €";
    }
}
