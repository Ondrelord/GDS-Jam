using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField] Transform dialogueWindow;
    [SerializeField] Transform dialogueWindowClose;
    Vector2 dialogueWindowOpenPos;
    Vector2 dialogueWindowClosePos;

    [SerializeField] Image dialogueNPCImage;
    [SerializeField] TextMeshProUGUI dialogueNPCName;
    [SerializeField] TextMeshProUGUI dialogueText;

    bool opened = false;
    float t = 0;
    bool isShop = false;

    private void Start()
    {
        sentences = new Queue<string>();

        dialogueWindowOpenPos = dialogueWindow.position;
        dialogueWindowClosePos = dialogueWindowClose.position;
    }

    private void Update()
    {
        t = opened ? t + Time.deltaTime * 7f : t - Time.deltaTime * 7f;
        t = Mathf.Clamp(t, 0, 1);
        dialogueWindow.position = Vector2.Lerp(dialogueWindowClosePos, dialogueWindowOpenPos, t);
    }


    public void StartConversation(DialogueScriptableObject dialogue, bool isShop = false)
    {
        GameObject.FindGameObjectWithTag("Rayblocker").GetComponent<Image>().enabled = true;
        sentences.Clear();

        foreach (string sentence in dialogue.GetSentences())
            sentences.Enqueue(sentence);

        this.isShop = isShop;
        opened = true;

        dialogueNPCImage.sprite = dialogue.GetImage();
        dialogueNPCName.text = dialogue.GetName();
        ContinueConversation();
    }


    public void ContinueConversation()
    {
        if (sentences.Count == 0)
        {
            EndConversation();
            return;
        }

        string sentence = sentences.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;  //type letter every frame
        }

    }

    public void EndConversation()
    {
        if (isShop)
        {
            FindObjectOfType<ShopManager>().OpenShop();
            isShop = false;
        }

        opened = false;
        GameObject.FindGameObjectWithTag("Rayblocker").GetComponent<Image>().enabled = false;
    }


}
