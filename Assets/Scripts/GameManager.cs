using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public struct NamedImage
{
    public string name;
    public Sprite image;
}


public class GameManager : MonoBehaviour
{
    [SerializeField] int moneyCurrent;
    [SerializeField] List<ItemScriptableObject> itemArray;

    [SerializeField] Transform itemListFather;
    [SerializeField] GameObject itemDisplayPrefab;
    [SerializeField] TextMeshProUGUI moneyDisplayText;

    [SerializeField] MonsterSO monster;

    [SerializeField] NamedImage[] speakerSprites;

    

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

    public int GetMoney() => moneyCurrent;
    public bool SpendMoney(int amount)
    {
        if (moneyCurrent - amount >= 0)
        {
            moneyCurrent -= amount;
            UpdateMoneyDisplay();
            return true;
        }
        else
            return false;
    }

    public List<ItemScriptableObject> GetItemList() => itemArray;

    public MonsterSO GetMonster() => monster;



    public Sprite GetSpeakerSprite(string speaker)
    {
        for (int i = 0; i < speakerSprites.Length; ++i)
        {
            if (speaker == speakerSprites[i].name)
                return speakerSprites[i].image;
        }

        return null;
    }
}
