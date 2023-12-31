
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public partial class PlayerController : MonoBehaviour
{

    public ObjectBattleStats battleStats;

    [SerializeField] private MoveComponent mover;
    [SerializeField] private BattleComponent battleComponent;

    private SelectebleObjectsDictionary selectebleObjectsDictionary;

    [Inject]
    public void Construct(ImouseService input, SelectebleObjectsDictionary selectebleObjectsDictionary)
    {
        input.OnClick += Click;
        this.selectebleObjectsDictionary = selectebleObjectsDictionary;
    }



    private void Click(int objectID, Vector3 point)
    {
        if (selectebleObjectsDictionary.dictionary.TryGetValue(objectID, out SelectableObject newSelect))
        {
            InteractWithObject(newSelect);

        }
        else
        {
            mover.MoveToPoint(point);
        }
    }

    private void InteractWithObject(SelectableObject selectableObject)
    {   
        StartCoroutine(InteractCoroutine(selectableObject));  
    }

    IEnumerator InteractCoroutine(SelectableObject selectableObject)
    {
        Vector3 position = selectableObject.transform.position;
        if (selectableObject.IsPlayerCanAttack())
        {
            MoveForInteract(position, battleStats.distanceToAttack);
            yield return new WaitUntil(()
                => Vector3.Distance(transform.position, position) <= battleStats.distanceToAttack);

            battleComponent.AttackObject(selectableObject as IDamageble);
        }
        else
        {
            MoveForInteract(position, selectableObject.rangeToInteract);
            yield return new WaitUntil(()
                => Vector3.Distance(transform.position, position) <= selectableObject.rangeToInteract);

            selectableObject.Interact(this);
        }

    }
    private void MoveForInteract(Vector3 positionInteract, float distanceToInteract)
    {
        float moveShift = 0.1f;
        mover.MoveToPoint(Vector3.MoveTowards(positionInteract, transform.position, distanceToInteract - moveShift));
    }
}

