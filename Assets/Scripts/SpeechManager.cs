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
        Debug.Log(str);
        string[] dial = str.Split('!');
        if (dial.Length == 0)
        {
            return;
        }
        Debug.Log(dial[0]);
        //Debug.Log("\n\n");
        //Debug.Log(dial.Length);
        dialoque = ScriptableObject.CreateInstance<DialogueScriptableObject>();

        int i = 0;
        foreach (string sentence in dial)
        {
            int startPos = sentence.IndexOf(":", 0, sentence.Length);

            if (startPos < 0 && sentence!="" )
            {
                string errMsg = "ERROR: invalid format in: \"";
                errMsg += sentence;
                errMsg += "\"";
                Debug.Log(errMsg);
                Debug.Log(startPos);
            }
            else
            {
                dialoque.speakerName[i] = sentence.Substring(0, startPos-1);
                dialoque.sentences[i] = sentence.Substring(startPos, sentence.Length);
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
            monsterDialogs[i] = new Monsters();
            monsterDialogs[i].loadBuildings(monster);
            i++;
        }
    }
}
