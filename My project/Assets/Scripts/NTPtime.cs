using UnityEngine;
using GuerrillaNtp;
using Rebex.Net;
using System;
using TMPro;


public class NTPtime : MonoBehaviour
{
    [SerializeField] private TMP_Text _guerrillaNtpText;
    [SerializeField] private TMP_Text _rebexText;

    NtpClient client;
    NtpClock clock;
    DateTimeOffset local;

    Ntp ntpRebex;
    void Awake()
    {
        NtpClientTime();
        RebexTime();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }
    void UpdateTime()
    {
        local = clock.Now;

        var response = ntpRebex.GetTime();
        DateTime nowRebex = DateTime.Now.AddSeconds(response.TimeOffset.TotalSeconds);

        _guerrillaNtpText.text = local.ToString();
        _rebexText.text = nowRebex.ToString();
    }

    void NtpClientTime()
    {
        client = NtpClient.Default;
        clock = client.Query();
    }
    void RebexTime()
    {
        Rebex.Licensing.Key = "==AhW1qhQQaqsZZ8j40+VkhU9OupvqlIrhw0Fl+Rt0BJrk==";
        ntpRebex = new Ntp("test.rebex.net");
    }
    public DateTimeOffset GetTime()
    {
        return clock.Now;
    }
}
