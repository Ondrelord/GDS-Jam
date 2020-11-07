using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDisplayController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] ItemScriptableObject item;

    float timer = 0.7f;

    bool pointerOver = false;
    [SerializeField] bool inShop = false;

    public void Initialize( ItemScriptableObject item, bool inShop = false)
    {
        this.item = item;
        this.inShop = inShop;
        Start();
    }

    public void Start()
    {
        GetComponent<Image>().sprite = item.GetSprite();
    }

    public void Update()
    {
        if (pointerOver)
        {
            if (timer <= 0)
                FindObjectOfType<TooltipManager>().ShowTooltip(item.GetName(), item.GetDescription(), item.GetPrice().ToString());
            else
                timer -= Time.deltaTime;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerOver = false;
        timer = 0.7f;
        FindObjectOfType<TooltipManager>().HideTooltip();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (inShop)
        {
            GameManager GM = FindObjectOfType<GameManager>();
            if (GM.SpendMoney(item.GetPrice()))
            {
                GM.NewItem(item);
                Destroy(gameObject);
            }
        }
    }
}
