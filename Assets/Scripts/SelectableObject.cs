using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SelectableObject : MonoBehaviour, IInteractable
{
    public string info;
    public virtual void Interact()
    {
        throw new System.NotImplementedException();
    }


}
