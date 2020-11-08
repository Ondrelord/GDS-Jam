using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialog")]
public class DialogueScriptableObject : ScriptableObject
{
    [SerializeField] public Sprite npcImage;
    [SerializeField] public string npcName;

    [TextArea]
    [SerializeField] public string[] speakerName;
    [SerializeField] public string[] sentences;

    [SerializeField] DialogueScriptableObject followupDialoge;

    public string[] GetSentences() => sentences;
    public string GetName() => npcName;
    public Sprite GetImage() => npcImage;
    public bool HaveFollowupDialogue() => followupDialoge != null;
    public DialogueScriptableObject GetFollowupDialogue() => followupDialoge;
}