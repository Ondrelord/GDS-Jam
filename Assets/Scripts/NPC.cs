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

    public string description;

    public bool b_canRumour = false;
    public bool b_canBribe = false;
    public bool b_canShop = false;

    Vector3 originalScale;

    public void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        FindObjectOfType<ChoiceWheelManager>().OpenWheel(this);
    }

    private void OnMouseEnter()
    {
        transform.localScale = originalScale * 1.1f;
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale;
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

    public void setRumor(DialogueScriptableObject d)
    {
        rumour = d;
    }

    public void setBribe(DialogueScriptableObject d)
    {
        bribe = d;
    }

    public void setShop(DialogueScriptableObject d)
    {
        shop = d;
    }


    public bool canRumour() => b_canRumour;
    public bool canBribe() => b_canBribe;

    public bool canShop() => b_canShop;

}
