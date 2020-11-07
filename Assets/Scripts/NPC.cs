using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] string npcName;
    [SerializeField] int bribe_price;

    [SerializeField] DialogueScriptableObject Rumor;
    [SerializeField] DialogueScriptableObject Bribe;
    [SerializeField] DialogueScriptableObject Shop;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
