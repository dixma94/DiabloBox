using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public void RotateToPlayer(PlayerController player);
    public void Interact();
}
