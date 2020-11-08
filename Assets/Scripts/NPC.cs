using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour, IChoicesForWheel
{
    [SerializeField] string npcName;
    [SerializeField] int bribe_price;

    [SerializeField] protected DialogueScriptableObject rumour;
    [SerializeField] protected DialogueScriptableObject bribe;
    [SerializeField] protected DialogueScriptableObject shop;

    [SerializeField] ItemScriptableObject[] itemsInShop;

    private void OnMouseDown()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        FindObjectOfType<ChoiceWheelManager>().OpenWheel(this);
    }

    public virtual void GetRumour()
    {
        FindObjectOfType<DialogueManager>().StartConversation(rumour);

        if (rumour.HaveFollowupDialogue())
            rumour = rumour.GetFollowupDialogue();
    }

    public virtual void GetBribe()
    {
        FindObjectOfType<DialogueManager>().StartConversation(bribe);

        if (bribe.HaveFollowupDialogue())
            bribe = bribe.GetFollowupDialogue();
    }

    public virtual void GetShop()
    {
        FindObjectOfType<DialogueManager>().StartConversation(shop, true);
        print(gameObject.name);
        FindObjectOfType<ShopManager>().SetShopwares(itemsInShop);

        if (shop.HaveFollowupDialogue())
            shop = shop.GetFollowupDialogue();
    }

    public virtual bool canShop() => true;

    public virtual bool canBribe() => true;

    public virtual bool canRumour() => true;
}
