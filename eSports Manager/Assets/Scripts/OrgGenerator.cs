using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESM.Character
{
    public class OrgGenerator : MonoBehaviour
    {
        private CharacterGenerator charGen = null;

        private string[] teamNameList;

        private void Start()
        {
            charGen = FindObjectOfType<CharacterGenerator>();
        }

    }
}

