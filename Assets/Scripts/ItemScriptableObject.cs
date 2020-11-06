using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] List<string> tags;

    [SerializeField] string itemName;
    [SerializeField] string description;

    public string GetName() => itemName;
    public string GetDescription() => description;

    public bool HaveTag(string tag)
    {
        return tags.Contains(tag);
    }

    public int CountMatchingTags(string[] tagArray)
    {
        int count = 0;
        for (int i = 0; i < tagArray.Length; ++i)
        {
            if (tags.Contains(tagArray[i]))
                count++;
        }

        return count;
    }
}
