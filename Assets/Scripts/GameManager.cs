using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int moneyCurrent;
    [SerializeField] List<ItemScriptableObject> itemArray;

    [SerializeField] Transform itemListFather;
    [SerializeField] GameObject itemDisplayPrefab;
    [SerializeField] TextMeshProUGUI moneyDisplayText;
    
    // Start is called before the first frame update
    void Start()
    {
        itemArray = new List<ItemScriptableObject>();
        UpdateMoneyDisplay();
    }

    public void NewItem(ItemScriptableObject item)
    {
        if (!itemArray.Contains(item))
            itemArray.Add(item);

        Instantiate(itemDisplayPrefab, itemListFather).GetComponent<ItemDisplayController>().Initialize(item);
    }

    public void UpdateMoneyDisplay()
    {
        moneyDisplayText.text = moneyCurrent.ToString();
    }

}
