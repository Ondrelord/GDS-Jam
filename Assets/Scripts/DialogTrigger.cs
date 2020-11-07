using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogueScriptableObject dialogue;

    public void TriggerConversation()
    {
        FindObjectOfType<DialogueManager>().StartConversation(dialogue);

        if (dialogue.HaveFollowupDialogue())
            dialogue = dialogue.GetFollowupDialogue();
    }

}
