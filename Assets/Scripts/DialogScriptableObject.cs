using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialog")]
public class DialogScriptableObject : ScriptableObject
{
    [TextArea]
    [SerializeField] string text;
    [TextArea]
    [SerializeField] string[] choices;

    public int GetChoicesCount() => choices.Length;
    public string[] GetChoices() => choices;
    public string GetText() => text;
}
