using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject shop;
    [SerializeField] Transform shopware;

    [SerializeField] GameObject ItemDisplayPrefab;

    public void OpenShop()
    {
        GameObject.FindGameObjectWithTag("Rayblocker").GetComponent<Image>().enabled = true;
        shop.SetActive(true);
    }

    public void CloseShop()
    {
        GameObject.FindGameObjectWithTag("Rayblocker").GetComponent<Image>().enabled = false;
        shop.SetActive(false);
    }

    public void SetShopwares(ItemScriptableObject[] itemsInShop)
    {
        for (int i = 0; i < shopware.childCount; ++i)
            Destroy(shopware.GetChild(i).gameObject);

        for (int i = 0; i < itemsInShop.Length; ++i)
            Instantiate(ItemDisplayPrefab, shopware).GetComponent<ItemDisplayController>().Initialize(itemsInShop[i], true);
    }
}
