using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnValidateSortOrderByYAxis : MonoBehaviour
{
    private void OnValidate()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 100 - Mathf.RoundToInt(transform.position.y * 100);
    }
}
