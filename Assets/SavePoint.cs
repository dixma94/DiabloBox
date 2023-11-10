using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SavePoint : SelectableObject
{
    private SavePointsManager _manager;

    [Inject]
    public void Construct(SavePointsManager manager)
    {
        _manager = manager;
    }

    public override void Interact(PlayerController player)
    {

        _manager.currentSavePoint  = this.transform.position;
    }

}
