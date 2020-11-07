using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IChoicesForWheel
{
    void GetRumour();
    void GetBribe();
    void GetShop();

}


public class NPC : MonoBehaviour, IChoicesForWheel
{
    [SerializeField] string npcName;
    [SerializeField] int bribe_price;

    [SerializeField] DialogueScriptableObject rumour;
    [SerializeField] DialogueScriptableObject bribe;
    [SerializeField] DialogueScriptableObject shop;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerConversation(DialogueScriptableObject dialogue)
    {
        FindObjectOfType<DialogueManager>().StartConversation(dialogue);

        if (dialogue.HaveFollowupDialogue())
            dialogue = dialogue.GetFollowupDialogue();
    }

    private void OnMouseDown()
    {
        FindObjectOfType<ChoiceWheelManager>().OpenWheel(this);
    }

    public void GetRumour()
    {
        TriggerConversation(rumour);
    }

    public void GetBribe()
    {
        TriggerConversation(bribe);
    }

    public void GetShop()
    {
        TriggerConversation(shop);
    }
}
