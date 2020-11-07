using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceWheelManager : MonoBehaviour
{
    [SerializeField] GameObject choiceWheel;
    [SerializeField] Button rumourButton;
    [SerializeField] Button bribeButton;
    [SerializeField] Button shopButton;

    IChoicesForWheel currentChoices;

    public void OpenWheel(IChoicesForWheel choices)
    {
        choiceWheel.SetActive(true);
        currentChoices = choices;

        rumourButton.onClick.AddListener(choices.GetRumour);
        bribeButton.onClick.AddListener(choices.GetBribe);
        shopButton.onClick.AddListener(choices.GetShop);
    }

    public void CloseWheel()
    {
        choiceWheel.SetActive(false);

        if (currentChoices != null)
        {
            rumourButton.onClick.RemoveListener(currentChoices.GetRumour);
            bribeButton.onClick.RemoveListener(currentChoices.GetBribe);
            shopButton.onClick.RemoveListener(currentChoices.GetShop);
        }
    }
}
