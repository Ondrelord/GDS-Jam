using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    GameManager gm;
    

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }


    public void StartFight()
    {
        string[] monsterTags = gm.GetMonster().GetTags();

        int result = 0;

        foreach (ItemScriptableObject item in gm.GetItemList())
        {
            result += item.CountMatchingTags(monsterTags);
        }

        if (gm.GetMonster().GetStrength() <= result)
        {
            FindObjectOfType<DialogueManager>().StartConversation(gm.GetMonster().GetWin());
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartConversation(gm.GetMonster().GetLose());
        }
    }


}
