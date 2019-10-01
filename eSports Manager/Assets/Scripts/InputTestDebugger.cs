using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESM.Character;

public class InputTestDebugger : MonoBehaviour
{
    private CharacterGenerator charGen;

    // Start is called before the first frame update
    void Start()
    {
        charGen = FindObjectOfType<CharacterGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log(charGen.OutputGeneratedChar());
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }
}
