using UnityEngine;
using UnityEngine.UI;

public class Alarm2 : MonoBehaviour
{
    [SerializeField] private GameObject _mmArrow;
    [SerializeField] private GameObject _hhArrow;

    [SerializeField] private CurrentNumber _currentHH;
    [SerializeField] private CurrentNumber _currentMM;

    [SerializeField] private ScrollRect _scrollRectHH;
    [SerializeField] private ScrollRect _scrollRectMM;
    private void Awake()
    {
        _scrollRectHH.onValueChanged.AddListener(UpdateTime);
        _scrollRectMM.onValueChanged.AddListener(UpdateTime);
    }
    private void UpdateTime(Vector2 value)
    {
        _hhArrow.transform.rotation = Quaternion.identity;
        _mmArrow.transform.rotation = Quaternion.identity;

        var h = new Vector3(0, 0, -1 * (30 * _currentHH.Current + 0.5f * _currentMM.Current));
        _hhArrow.transform.Rotate(h);

        var m = new Vector3(0, 0, -6 * _currentMM.Current);
        _mmArrow.transform.Rotate(m);
    }
}
