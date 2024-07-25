using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphsWindow : MonoBehaviour
{
    private void OnEnable()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        
    }

    private void OnDisable()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
