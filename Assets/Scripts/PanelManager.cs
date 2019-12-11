using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;
    public Button panelBtn;
    public Sprite closeBtn;
    public Sprite openBtn;
    private bool panelState = false;
    
    public void PanelGestion(float time)
    {
        if (panelState == false)
        {
            panelBtn.GetComponent<Image>().sprite = closeBtn;
            StartCoroutine(PanelPosition(time, -5f));
        }
        else if(panelState == true)
        {
            panelBtn.GetComponent<Image>().sprite = openBtn;
            StartCoroutine(PanelPosition(time, Screen.currentResolution.height + 5f));
        }
    }

    private IEnumerator PanelPosition(float time, float posX)
    {
        float elapsedTime = 0;
        Vector3 startingPos = panel.GetComponent<RectTransform>().anchoredPosition;
        while (elapsedTime < time)
        {
            panel.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startingPos, new Vector3(posX, 0f, 0f), elapsedTime/time);
            elapsedTime += Time.deltaTime;
            panelState = !panelState;
            yield return null;
        }
    }


}
