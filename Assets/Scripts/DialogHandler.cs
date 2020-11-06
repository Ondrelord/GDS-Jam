using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Transform choiceFather;
    [SerializeField] DialogScriptableObject dialogData;

    [SerializeField] GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (string choice in dialogData.GetChoices())
        {
            GameObject button = Instantiate(buttonPrefab);
            button.GetComponentInChildren<TextMeshProUGUI>().text = choice;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
