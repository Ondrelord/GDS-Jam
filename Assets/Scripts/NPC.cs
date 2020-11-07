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

    private void OnMouseDown()
    {
        FindObjectOfType<ChoiceWheelManager>().OpenWheel(this);
    }

    public void GetRumour()
    {
        FindObjectOfType<DialogueManager>().StartConversation(rumour);

        if (rumour.HaveFollowupDialogue())
            rumour = rumour.GetFollowupDialogue();
    }

    public void GetBribe()
    {
        FindObjectOfType<DialogueManager>().StartConversation(bribe);

        if (bribe.HaveFollowupDialogue())
            bribe = bribe.GetFollowupDialogue();
    }

    public void GetShop()
    {
        FindObjectOfType<DialogueManager>().StartConversation(shop);

        if (shop.HaveFollowupDialogue())
            shop = shop.GetFollowupDialogue();
    }
}
