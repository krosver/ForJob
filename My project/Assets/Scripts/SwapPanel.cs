using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapPanel : MonoBehaviour
{
    [SerializeField] private Button _firsButton;
    private GameObject CurrentPanel;
    private void Start()
    {
        _firsButton.onClick?.Invoke();
    }
    public void PressButtonSwapPanel(GameObject panel)
    {
        if (CurrentPanel)
        {
            CurrentPanel.SetActive(false);
            CurrentPanel = panel;
            CurrentPanel.SetActive(true);
        }
        else
        {
            CurrentPanel = panel;
            CurrentPanel.SetActive(true);
        }
    }
}
