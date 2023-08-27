using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SelectableObject : MonoBehaviour, IInteractable
{
    public string info;
    public virtual void Interact()
    {
        throw new System.NotImplementedException();
    }

    public virtual void RotateToPlayer(PlayerController player)
    {
        throw new System.NotImplementedException();
    }
}
