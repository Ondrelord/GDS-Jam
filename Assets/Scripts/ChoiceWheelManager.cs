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

    public void OpenWheel(IChoicesForWheel choices)
    {
        GameObject.FindGameObjectWithTag("Rayblocker").GetComponent<Image>().enabled = true;
        choiceWheel.SetActive(true);

        rumourButton.onClick.AddListener(choices.GetRumour);
        bribeButton.onClick.AddListener(choices.GetBribe);
        shopButton.onClick.AddListener(choices.GetShop);
    }

    public void CloseWheel()
    {
        choiceWheel.SetActive(false);

        rumourButton.onClick.RemoveAllListeners();
        bribeButton.onClick.RemoveAllListeners();
        shopButton.onClick.RemoveAllListeners();
    }
}
