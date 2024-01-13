using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ages : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject secondPanel;

    void Start()
    {
        ShowPanel(currentPanel);
    }

    void ShowPanel(GameObject panelToShow)
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }

        panelToShow.SetActive(true);
        currentPanel = panelToShow;
    }

    public void SwitchToSecondPanel()
    {
        // Eğer secondPanel zaten görünüyorsa, işlemi yapma
        if (secondPanel != null && secondPanel.activeSelf)
        {
            return;
        }

        ShowPanel(secondPanel);
    }
}
