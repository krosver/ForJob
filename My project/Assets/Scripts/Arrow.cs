using System;
using UnityEngine;
using static RotationArrow;


public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject _contentHH;
    [SerializeField] private GameObject _contentMM;
    private int _hh;
    private int _mm;
    private void OnEnable()
    {
        OnMoveArrow += UpdateScroll;
    }
    private void UpdateScroll(Transform arrow)
    {
        var angleZ = 360 - arrow.rotation.eulerAngles.z;
        if (arrow.name == "HH Arrow")
        {
            _hh = Convert.ToInt16(angleZ) / 30;
        }
        else
        {
            _mm = Convert.ToInt16(angleZ) / 6;
        }
        var currentPosMM = _contentMM.transform.localPosition;
        var newYMM = -2504 + 85 * _mm;
        var currentPosHH = _contentMM.transform.localPosition;
        var newYHH = -977 + 85 * _hh;

        _contentMM.transform.localPosition = new Vector3(currentPosMM.x,newYMM, currentPosMM.z);
        _contentHH.transform.localPosition = new Vector3(currentPosHH.x,newYHH, currentPosHH.z);
    }
}
