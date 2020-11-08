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

    public void Update()
    {
        if (choiceWheel.activeSelf)
        {
            if (Input.GetMouseButtonDown(1))
                CloseWheel();
        }
    }


    public void OpenWheel(IChoicesForWheel choices)
    {
        GameObject.FindGameObjectWithTag("Rayblocker").GetComponent<Image>().enabled = true;
        choiceWheel.SetActive(true);

        if (choices.canRumour()) rumourButton.onClick.AddListener(choices.GetRumour);
        if (choices.canBribe() && FindObjectOfType<GameManager>().GetMoney() >= 25) bribeButton.onClick.AddListener(choices.GetBribe);
        if (choices.canShop()) shopButton.onClick.AddListener(choices.GetShop);

        rumourButton.gameObject.SetActive(choices.canRumour());
        bribeButton.gameObject.SetActive(choices.canBribe());
        shopButton.gameObject.SetActive(choices.canShop());
    }

    public void CloseWheel()
    {
        GameObject.FindGameObjectWithTag("Rayblocker").GetComponent<Image>().enabled = false;
        choiceWheel.SetActive(false);

        rumourButton.onClick.RemoveAllListeners();
        bribeButton.onClick.RemoveAllListeners();
        shopButton.onClick.RemoveAllListeners();
    }
}
