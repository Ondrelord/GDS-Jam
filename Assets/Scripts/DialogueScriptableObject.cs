using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialog")]
public class DialogueScriptableObject : ScriptableObject
{
    [SerializeField] Sprite npcImage;
    [SerializeField] string npcName;

    [TextArea]
    [SerializeField] string[] sentences;

    [SerializeField] DialogueScriptableObject followupDialoge;

    public string[] GetSentences() => sentences;
    public string GetName() => npcName;
    public Sprite GetImage() => npcImage;
    public bool HaveFollowupDialogue() => followupDialoge != null;
    public DialogueScriptableObject GetFollowupDialogue() => followupDialoge;
}