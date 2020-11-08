using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster")]
public class MonsterSO : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] int strength = 3;

    [SerializeField] DialogueScriptableObject winText;
    [SerializeField] DialogueScriptableObject drawText;
    [SerializeField] DialogueScriptableObject loseText;

    [SerializeField] string[] tags;

    public string[] GetTags() => tags;
    public int GetStrength() => strength;

    public DialogueScriptableObject GetWin() => winText;
    public DialogueScriptableObject GetLose() => loseText;
    public DialogueScriptableObject GetDraw() => drawText;

    public void setWinText(DialogueScriptableObject d)
    {
        winText = d;
    }

    public void setLoseText(DialogueScriptableObject d)
    {
        loseText = d;
    }

    public void setDrawText(DialogueScriptableObject d)
    {
        drawText = d;
    }

}
