using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialog")]
public class DialogueScriptableObject : ScriptableObject
{
    [SerializeField] public Sprite npcImage;
    [SerializeField] public string npcName;
    [SerializeField] public string monsterName;

    [TextArea]
    [SerializeField] public List<string> speakerName;
    [SerializeField] public List<string> sentences;

    [SerializeField] DialogueScriptableObject followupDialoge;

    public List<string> GetSentences() => sentences;
    public List<string> GetSpeakerNames() => speakerName;
    public string GetName() => npcName;
    public Sprite GetImage() => npcImage;
    public bool HaveFollowupDialogue() => followupDialoge != null;
    public DialogueScriptableObject GetFollowupDialogue() => followupDialoge;

    internal void Init()
    {
        speakerName = new List<string>();
        sentences = new List<string>();
    }
}