using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIViewSwitcher : MonoBehaviour
{

    public GameObject SwitchView(GameObject activeCanvas, GameObject newCanvas)
    {
        activeCanvas.SetActive(false);

        newCanvas.SetActive(true);

        return newCanvas;
    }

}
