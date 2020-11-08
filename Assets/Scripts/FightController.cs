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

        setUpNewMonster();
    }

    public void setUpNewMonster()
    {
        Monsters[] monsters = GetComponent<SpeechManager>().getMonsterDialogs();
        gm.monsterNumber++;
        if (gm.monsterNumber >= monsters.Length)
            gm.monsterNumber = 0;

        gm.InitMonster(gm.monsterNumber);

        DialogueScriptableObject msgLose;
        DialogueScriptableObject msgWin;

        switch (gm.monsterNumber)
        {
            case 0:
                {
                    gm.monster.name = "Dragon";
                    msgWin = ScriptableObject.CreateInstance<DialogueScriptableObject>();
                    msgWin.Init();
                    msgWin.monsterName = "Dragon";
                    msgWin.sentences.Add("After you read the book you were almost certain that you don't want to face the Dragon in its full power. You came out with a genius plan to kill another animal and stuff it with goods. ");
                    msgWin.sentences.Add("Thanks to some villagers you were able to place the decoy out in the fields and wait. After the Dragon ate the bait, you rushed out in the field, equipped and encouraged, you managed to slay the beast.");
                    msgWin.speakerName.Add(" ");
                    msgWin.speakerName.Add(" ");
                    gm.monster.setWinText(msgWin);

                    msgLose = ScriptableObject.CreateInstance<DialogueScriptableObject>();
                    msgLose.Init();
                    msgLose.monsterName = "Dragon";
                    msgLose.sentences.Add("You found yourself in the middle of the meadow, flock of sheep running around you, waiting for overgrown chicken. Weapon drawn, you ducked in fear when majetic red Dragon flew over your head, landing just in front of you. ");
                    msgLose.sentences.Add("Your battle roar went silent as soon as the Dragon breathed fire down on you, burning your skin black.");
                    msgLose.speakerName.Add(" ");
                    msgLose.speakerName.Add(" ");
                    gm.monster.setLoseText(msgLose);
                }
               
                break;
            case 1:
                {
                    gm.monster.name = "Treant";
                    msgWin = ScriptableObject.CreateInstance<DialogueScriptableObject>();
                    msgWin.Init();
                    msgWin.monsterName = "Treant";
                    msgWin.sentences.Add("After your marvelous research you have found out where the Treant is hiding. Obviously in the forest. You come to the darkest place in the forest and begin to damage some random trees to provoke the Treant. And it worked. ");
                    msgWin.sentences.Add("One of the oldest and widest trees suddenly moved your direction. Movement was so slow, you would more probably die from old age. So you take matters into your own hands and end this masquerade.");
                    msgWin.speakerName.Add(" ");
                    msgWin.speakerName.Add(" ");
                    gm.monster.setWinText(msgWin);

                    msgLose = ScriptableObject.CreateInstance<DialogueScriptableObject>();
                    msgLose.Init();
                    msgLose.monsterName = "Treant";
                    msgLose.sentences.Add("You wandered deep into the forest and managed to find the creature. Your worst suspicions were true. Big old Treant stands before you. ");
                    msgLose.sentences.Add("Treant despite his slow movements ability, he managed to catch your flash body and squeezed all the internal organs out of you just like toothpaste."); 
                    msgLose.speakerName.Add(" ");
                    msgLose.speakerName.Add(" ");
                    gm.monster.setLoseText(msgLose);
                }
                
                break;
            case 2:
                {
                    gm.monster.name = "Yoghurt";
                    msgWin = ScriptableObject.CreateInstance<DialogueScriptableObject>();
                    msgWin.Init();
                    msgWin.monsterName = "Yoghurt";
                    msgWin.sentences.Add("After you read the book you were almost certain that you don't want to face the Dragon in its full power. You came out with a genius plan to kill another animal and stuff it with goods. ");
                    msgWin.sentences.Add("Thanks to some villagers you were able to place the decoy out in the fields and wait. After the Dragon ate the bait, you rushed out in the field, equipped and encouraged, you managed to slay the beast."); 
                    msgWin.speakerName.Add(" ");
                    msgWin.speakerName.Add(" ");
                    gm.monster.setWinText(msgWin);

                    msgLose = ScriptableObject.CreateInstance<DialogueScriptableObject>();
                    msgLose.Init();
                    msgLose.monsterName = "Yoghurt";
                    msgLose.sentences.Add("You found yourself in the middle of the meadow, flock of sheep running around you, waiting for overgrown chicken. ");
                    msgLose.sentences.Add("Weapon drawn, you ducked in fear when majetic red Dragon flew over your head, landing just in front of you. Your battle roar went silent as soon as the Dragon breathed fire down on you, burning your skin black.");
                    msgLose.speakerName.Add(" ");
                     msgLose.speakerName.Add(" ");
                    gm.monster.setLoseText(msgLose);
                }
                
                break;

        }


    }


}
