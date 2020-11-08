using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> speakerNames;

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

    GameManager gm;

    private void Start()
    {
        sentences = new Queue<string>();
        speakerNames = new Queue<string>();

        dialogueWindowOpenPos = dialogueWindow.position;
        dialogueWindowClosePos = dialogueWindowClose.position;

        gm = FindObjectOfType<GameManager>();
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
        speakerNames.Clear();

        foreach (string sentence in dialogue.GetSentences())
            sentences.Enqueue(sentence);

        foreach (string speaker in dialogue.GetSpeakerNames())
            speakerNames.Enqueue(speaker);

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

        string speaker;

        string sentence = sentences.Dequeue();
        if(speakerNames.Count == 0)
        {
            speaker = "";
        }
        else
        {
            speaker = speakerNames.Dequeue();
        }
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, speaker));
    }

    IEnumerator TypeSentence(string sentence, string speaker)
    {
        Sprite sprite = gm.GetSpeakerSprite(speaker);

        if (sprite != null)
        {
            dialogueNPCImage.sprite = sprite;
            dialogueNPCImage.enabled = true;
        }
        else
            dialogueNPCImage.enabled = false;

        dialogueNPCName.text = speaker;
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
