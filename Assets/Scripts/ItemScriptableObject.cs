using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] string itemName;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] int price = 0;
    [SerializeField] Sprite itemIcon;
    
    [SerializeField] List<string> tags;

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

    public int GetPrice() => price;
    public Sprite GetSprite() => itemIcon;
}
