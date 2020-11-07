using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDisplayController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] ItemScriptableObject item;

    float timer = 0.7f;

    bool pointerOver = false;

    public void Initialize( ItemScriptableObject item)
    {
        this.item = item;
    }

    public void Update()
    {
        if (pointerOver)
        {
            if (timer <= 0)
                FindObjectOfType<TooltipManager>().ShowTooltip(item.GetName(), item.GetDescription());
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
}
