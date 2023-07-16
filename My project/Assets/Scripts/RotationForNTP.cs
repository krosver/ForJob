using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationForNTP : MonoBehaviour
{
    [SerializeField] int scaleTransform;
    [SerializeField] List<Transform> transformList;
    private void OnRectTransformDimensionsChange()
    {
        if (Screen.orientation == UnityEngine.ScreenOrientation.LandscapeLeft ||
            Screen.orientation == UnityEngine.ScreenOrientation.LandscapeRight)
        {
            foreach (Transform t in transformList)
            {
                t.localScale = new Vector3(1, 1, 1);
            }
        }
        if (Screen.orientation == UnityEngine.ScreenOrientation.Portrait ||
            Screen.orientation == UnityEngine.ScreenOrientation.PortraitUpsideDown)
        {
            foreach (Transform t in transformList)
            {
                t.localScale = new Vector3(scaleTransform, scaleTransform, 1);
            }
        }
    }
}
