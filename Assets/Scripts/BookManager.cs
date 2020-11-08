using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    [SerializeField] GameObject book;

    [SerializeField] TextMeshProUGUI bookText_0;
    [SerializeField] TextMeshProUGUI bookText_1;

    public void OpenBook(DialogueScriptableObject dialogue)
    {
        string text = "";

        GameObject.FindGameObjectWithTag("Rayblocker").GetComponent<Image>().enabled = true;

        foreach (string sentence in dialogue.GetSentences())
        {
            text += sentence;
            text += "\n";
        }

        book.SetActive(true);
        bookText_0.text = text;
        bookText_1.text = text;
    }

    public void CloseBook()
    {
        book.SetActive(false);
    }
}
