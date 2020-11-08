using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLibrary : NPC
{
    public override void GetRumour()
    {
        FindObjectOfType<BookManager>().OpenBook(rumour);
    }

    public override bool canBribe() => false;
    public override bool canShop() => false;
}
