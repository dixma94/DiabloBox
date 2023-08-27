using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : SelectableObject
{
    public override void Interact()
    {
        GameEventManager.instance.ratsEvents.RatKilled();
        Destroy(gameObject);
    }
}
