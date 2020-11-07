using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemMenuResizer : MonoBehaviour
{
    [SerializeField] GridLayoutGroup grid;

    void Start()
    {
        UpdateSize();
    }

    public void UpdateSize()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, (Mathf.CeilToInt(transform.childCount / 4f) * (grid.cellSize.y + grid.spacing.y)) + grid.padding.top + grid.padding.bottom);
    }
}
