using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] RectTransform tooltip;
    [SerializeField] TextMeshProUGUI tooltipName;
    [SerializeField] TextMeshProUGUI tooltipText;
    [SerializeField] TextMeshProUGUI tooltipPrice;

    public void ShowTooltip(string name, string text, string price = "")
    {
        Vector2 mousePos = Input.mousePosition;

        float x = Mathf.Clamp(mousePos.x, 0, Camera.main.pixelWidth - tooltip.sizeDelta.x);
        float y = Mathf.Clamp(mousePos.y, tooltip.sizeDelta.y, Camera.main.pixelHeight);

        tooltip.position = new Vector2(x, y);

        tooltipName.text = name;
        tooltipText.text = text;
        tooltipPrice.text = price;

        tooltip.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip.gameObject.SetActive(false);
    }
}
