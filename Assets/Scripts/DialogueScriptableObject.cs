using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialog")]
public class DialogueScriptableObject : ScriptableObject
{
    [SerializeField] string npcName;
    [TextArea]
    [SerializeField] string[] sentences;

    [SerializeField] DialogueScriptableObject followupDialoge;

    public string[] GetSentences() => sentences;
    public string GetName() => npcName;
}