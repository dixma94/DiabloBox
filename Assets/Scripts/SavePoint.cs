using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SavePoint : SelectableObject
{
    private SavePointsManager _manager;

    [Inject]
    public void Construct(SavePointsManager manager, SelectebleObjectsDictionary selectebleObjectsDictionary)
    {
        _manager = manager;
        selectebleObjectsDictionary.AddToDictionary(this);
    }

    public override void Interact(PlayerController player)
    {
        _manager.currentSavePoint  = this.transform.position;
    }

    public override void ShowInfo()
    {
        tipUI.ShowInfoAboutNPC(info);
    }
}
