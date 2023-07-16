using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationForAlarm : MonoBehaviour
{
    [SerializeField] private int scaleTransform;
    [SerializeField] private Transform clock;
    [SerializeField] private Transform scrolls;
    [SerializeField] private Transform button;
    private void OnRectTransformDimensionsChange()
    {
        if (Screen.orientation == UnityEngine.ScreenOrientation.LandscapeLeft ||
            Screen.orientation == UnityEngine.ScreenOrientation.LandscapeRight)
        {
            clock.localPosition = new Vector3(-391,-36,0);
            scrolls.localPosition = new Vector3(581,99,0);
            button.localPosition = new Vector3(581,-173,0);

            clock.localScale = new Vector3(1, 1, 0);
            scrolls.localScale = new Vector3(1, 1, 0);
            button.localScale = new Vector3(1, 1, 0);
        }
        if (Screen.orientation == UnityEngine.ScreenOrientation.Portrait ||
            Screen.orientation == UnityEngine.ScreenOrientation.PortraitUpsideDown)
        {
            clock.localPosition = new Vector3(0, 500, 0);
            scrolls.localPosition = new Vector3(0, -884, 0);
            button.localPosition = new Vector3(0, -1598, 0);

            clock.localScale = new Vector3(scaleTransform, scaleTransform, 0);
            scrolls.localScale = new Vector3(scaleTransform, scaleTransform, 0);
            button.localScale = new Vector3(scaleTransform, scaleTransform, 0);
        }
    }
}
