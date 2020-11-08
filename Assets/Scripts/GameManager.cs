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


    [Header("Buildings")]
    [SerializeField] NPC alchemyBuilding;
    [SerializeField] NPC libraryBuilding;
    [SerializeField] NPC magicBuilding;
    [SerializeField] NPC smithBuilding;
    [SerializeField] NPC innBuilding;

    

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

    public void InitMonster()
    {
        Monsters[] monsters = GetComponent<SpeechManager>().getMonsterDialogs();

        //hard coded

        int j = 0;
        for(int i = 0; i < monsters[j].buildings.Length; i++)
        {
            switch(i)
            {
                case 0:
                    SetDialoquesToBuilding(innBuilding, monsters[j].buildings[i].buildingDialoques);
                    break;
                case 1:
                    SetDialoquesToBuilding(magicBuilding, monsters[j].buildings[i].buildingDialoques);
                    break;
                case 2:
                    SetDialoquesToBuilding(smithBuilding, monsters[j].buildings[i].buildingDialoques);
                    break;
                case 4:
                    SetDialoquesToBuilding(alchemyBuilding, monsters[j].buildings[i].buildingDialoques);
                    break;
                case 6:
                    SetDialoquesToBuilding(libraryBuilding, monsters[j].buildings[i].buildingDialoques);
                    break;
                default:
                    break;
            }
        }

    }

    public void SetDialoquesToBuilding(NPC building, personalDialoque[] buildingDialoques)
    {
        for(int i=0; i < buildingDialoques.Length; i++)
        {
            switch(i)
            {
                case 0:
                    building.setRumor(buildingDialoques[i].dialoque);
                    building.b_canRumour = true;
                    break;
                case 1:
                    building.setBribe(buildingDialoques[i].dialoque);
                    building.b_canBribe = true;
                    break;
                case 2:
                    building.setShop(buildingDialoques[i].dialoque);
                    building.b_canShop = true;
                    break;
                default:
                    break;
            }
        }
    }
}
