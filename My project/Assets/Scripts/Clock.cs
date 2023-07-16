using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject _ss;
    [SerializeField] private GameObject _mm;
    [SerializeField] private GameObject _hh;
    [SerializeField] private NTPtime ntp;
    private int HH;
    private int MM;
    private int SS;
    private void OnEnable()
    {
        StartCoroutine(Second());
        StartCoroutine(Minute());
        StartCoroutine(Hour());
    }
    
    void Start()
    {
        InstallationTime();
    }

    private void InstallationTime()
    {
        var ntpTime = ntp.GetTime();
        HH = ntpTime.Hour;
        print(ntpTime);
        MM = ntpTime.Minute;
        SS = ntpTime.Second;
        UpdateArrow();
    }
    private void UpdateArrow()
    {
        _hh.transform.rotation = Quaternion.identity;
        _mm.transform.rotation = Quaternion.identity;
        _ss.transform.rotation = Quaternion.identity;

        var h = new Vector3(0, 0, -30 * HH - 0.5f * MM);
        _hh.transform.Rotate(h);

        var m = new Vector3(0, 0, -6 * MM - 0.1f * SS);
        _mm.transform.Rotate(m);

        var s = new Vector3(0, 0, -6 * SS);
        _ss.transform.Rotate(s);
    }
    IEnumerator Second()
    {
        while (true) 
        {
            SS++;
            UpdateArrow();
            yield return new WaitForSecondsRealtime(1);
        }
    }
    IEnumerator Minute()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(3600);
            SS = 0;
            MM++;
        }

    }
    IEnumerator Hour()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(3600);
            MM = 0;
            InstallationTime();
        }
    }
}

