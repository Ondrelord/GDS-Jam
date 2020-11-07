using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemMenuResizer : MonoBehaviour
{
    [SerializeField] GridLayoutGroup grid;

    // Start is called before the first frame update
    void Start()
    {
        print((transform.childCount / 4 * (grid.cellSize.y + grid.spacing.y)) + grid.padding.top + grid.padding.bottom);
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, (Mathf.CeilToInt(transform.childCount / 4f) * (grid.cellSize.y + grid.spacing.y)) + grid.padding.top + grid.padding.bottom);
    }

    // Update is called once per frame
    void OnValidate()
    {
        
    }
}
