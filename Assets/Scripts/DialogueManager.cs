using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField] TextMeshProUGUI dialogueNPCName;
    [SerializeField] TextMeshProUGUI dialogueText;
    
    private void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartConversation(DialogueScriptableObject dialogue)
    {
        foreach (string sentence in dialogue.GetSentences())
        {
            sentences.Enqueue(sentence);
        }

        dialogueNPCName.text = dialogue.GetName();
        ContinueConversation();
    }


    public void ContinueConversation()
    {
        if (sentences.Count == 0)
        {
            EndConversation();
            return;
        }


        string sentence = sentences.Dequeue();

        
        dialogueText.text = sentence;
    }

    public void EndConversation()
    {
        print("end conversation");
    }


}
