
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{

    [SerializeField] private MouseInput input;
    [SerializeField] private NPCDialogUI nPCDialogUI;
    [SerializeField] private PlayerMover mover;
    [SerializeField] private BattleComponent battleComponent;
    [SerializeField] private SelectebleObjectsDictionary selectebleObjectsDictionary;

    public ObjectBattleStats battleStats;

    float distanceToInteract = 10f;
    public bool IsDialog;

    private void Start()
    {

        input.OnClick += Click;
        IsDialog = false;
    }

    private void Click(int objectID, Vector3 point)
    {
        if (selectebleObjectsDictionary.dictionary.TryGetValue(objectID, out SelectableObject newSelect))
        {
            if (newSelect is IInteractable)
            {
                InteractWithObject(newSelect as IInteractable);
            }
            if (newSelect is IDamageble)
            {
                AttackObject(newSelect as IDamageble);
            }
        }
        else
        {
            mover.MoveToPoint(point);
        }
    }


    private void AttackObject(IDamageble damageble)
    {
        StartCoroutine(AttackCoroutine(damageble));     
    }
    private void InteractWithObject(IInteractable interactableObject)
    {   
        StartCoroutine(InteractCoroutine(interactableObject));  
    }

    IEnumerator AttackCoroutine(IDamageble damageble)
    {
        Vector3 positionAttack = damageble.GetPosition();
        MoveForAttack(damageble);
        yield return new WaitUntil(() 
            => Vector3.Distance(transform.position, positionAttack) <= battleStats.distanceToAttack);
        battleComponent.AttackObject(damageble);
    }

    private void MoveForAttack(IDamageble damageble)
    {
        Vector3 pointAttack = damageble.GetPosition();
        float moveShift = 0.1f;
        mover.MoveToPoint(Vector3.MoveTowards(pointAttack, transform.position, battleStats.distanceToAttack - moveShift));
    }


    IEnumerator InteractCoroutine(IInteractable interactable)
    {
        Vector3 positionInteract = interactable.GetPosition();

        MoveForInteract(interactable);
        yield return new WaitUntil(()
            => Vector3.Distance(transform.position, positionInteract) <= distanceToInteract);
        interactable.Interact();
    }

    private void MoveForInteract(IInteractable interactable)
    {
        Vector3 positionInteract = interactable.GetPosition();
        float moveShift = 0.1f;
        mover.MoveToPoint(Vector3.MoveTowards(positionInteract, transform.position, distanceToInteract - moveShift));
    }
}

