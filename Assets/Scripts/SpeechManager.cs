using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using System.IO;
using System.Text;
using System;
using UnityEngine.Assertions;

public class Monsters
{
    public string monsterName;
    public MonsterDialoqueBuildings[] buildings;

    public void loadBuildings(string str)
    {
        //split different buildings types
        string[] dialoques = str.Split('/');

        if (dialoques.Length == 0 )
        {
            return;
        }
        //Debug.Log(dialoques.Length);
        buildings = new MonsterDialoqueBuildings[dialoques.Length];
        int i = 0;
        foreach (string dialoque in dialoques)
        {
            if (dialoque == "" || dialoque == "\n")
                continue;
            buildings[i] = new MonsterDialoqueBuildings();
            buildings[i].loadDialoques(dialoque);
            i++;
        }
    }
}

public class MonsterDialoqueBuildings
{
    [SerializeField] public personalDialoque[] buildingDialoques;

    public void loadDialoques(string str)
    {
        //split different dialowue types (rumor, bribe...)
        string[] dialoques = str.Split('*');
        if (dialoques.Length == 0)
        {
            return;
        }
       // Debug.Log(dialoques.Length);
        buildingDialoques = new personalDialoque[dialoques.Length];
        int i = 0;
        foreach (string dialoque in dialoques)
        {
            if (dialoque == "" || dialoque == "\n")
                continue;
            buildingDialoques[i] = new personalDialoque();
            buildingDialoques[i].loadSentences(dialoque);
            i++;
        }
    }
}

public class personalDialoque
{
    [SerializeField] DialogueScriptableObject dialoque;
    public void loadSentences(string str)
    {

        //dialoque = new DialogueScriptableObject();
        //split speech of each person in dialoque
        //Debug.Log(str);
        string[] dial = str.Split(';');
        if (dial.Length == 0)
        {
            return;
        }
        //Debug.Log(dial[0]);
        //Debug.Log("\n\n");
        //Debug.Log(dial.Length);
        dialoque = ScriptableObject.CreateInstance<DialogueScriptableObject>();
        dialoque.Init();

        int i = 0;
        foreach (string sentence in dial)
        {
            int startPos = sentence.IndexOf(":", 0, sentence.Length);

            if (startPos < 0 && sentence!="" && sentence != "\n")
            {
                string errMsg = "ERROR: invalid format in: \"";
                errMsg += sentence;
                errMsg += "\"";
                Debug.Log(errMsg);
                Debug.Log(startPos);
            }
            else
            {
                if(sentence != "" && sentence != "\n" || sentence.Length > 1)
                {
                    //string tmp = "";
                    if (sentence[0] == '\n')
                    {
                        /*tmp += sentence.Substring(1, startPos-1);
                        Debug.Log(tmp);*/
                        dialoque.speakerName.Add(sentence.Substring(1, startPos-1));
                    }
                    else
                    {
                        /*tmp += sentence.Substring(0, startPos);
                        Debug.Log(tmp);*/
                        dialoque.speakerName.Add(sentence.Substring(0, startPos));
                    }
                        
                    dialoque.sentences.Add(sentence.Substring(startPos + 2, (sentence.Length - startPos - 2)));
                }
                else
                {
                    string tmp = "nevypis: ";
                    tmp += sentence;
                }

                dialoque.monsterName = SpeechManager.actualMonsterName;
            }

            i++;
        }
    }
}

public class SpeechManager : MonoBehaviour
{
    Monsters[] monsterDialogs;

    public static string actualMonsterName;

    // Start is called before the first frame update
    void Start()
    {
        loadDialogs();
    }


    // Update is called once per frame
    void Update()
    {

    }

    void loadDialogs()
    {
        //load data from file
        string text = System.IO.File.ReadAllText(@"Assets\Test.txt");
        //Debug.Log(text);

        //split monsters
        string[] blocksMonsters = text.Split('|');
        if (blocksMonsters.Length == 0)
            return;
        //Debug.Log(blocksMonsters.Length);
        monsterDialogs = new Monsters[blocksMonsters.Length];

        int i = 0;
        foreach (string monster in blocksMonsters)
        {
            if (monster == "" || monster == "\n")
                continue;

            int startPos = monster.IndexOf(" ", 0, monster.Length);
            actualMonsterName = monster.Substring(0, startPos);
            string monSbstr = monster.Substring(startPos + 1, (monster.Length - startPos - 1));
            monsterDialogs[i] = new Monsters();
            monsterDialogs[i].monsterName = actualMonsterName;
            monsterDialogs[i].loadBuildings(monSbstr);
            i++;
        }
    }

    public Monsters[] getMonsterDialogs()
    {
        return monsterDialogs;
    }
}
