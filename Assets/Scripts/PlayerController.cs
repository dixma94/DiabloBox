
using System;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{

    [SerializeField] private MouseInput input;
    [SerializeField] private NPCDialogUI nPCDialogUI;
    [SerializeField] private PlayerMover mover;
    [SerializeField] private BattleComponent battleComponent;

    public ObjectBattleStats battleStats;

    float distanceToInteract = 10f;
    public bool IsDialog;

    private void Start()
    {

        input.OnObjectClick += InteractWithObject;
        input.OnAttackableClick += AttackObject; ;
        IsDialog = false;
    }

    private void AttackObject(IDamageble damageble)
    {

        Vector3 pointAttack = damageble.GetPoint();
        float distance = Vector3.Distance(transform.position, pointAttack);
        float moveShift = 0.1f;
        if (distance <= battleStats.distanceToAttack)
        {
            battleComponent.AttackObject(damageble);
        }
        else
        {
            mover.MoveToPoint(Vector3.MoveTowards(pointAttack, transform.position, battleStats.distanceToAttack -moveShift));
        }
        
    }

    private void InteractWithObject(IInteractable interactableObject)
    {   
        float distanceToStop = 5f;

        if (!IsDialog) 
        {
            Vector3 pointInteract = interactableObject.GetPoint();
            if (Vector3.Distance(transform.position, pointInteract) <= distanceToInteract)
            {
                interactableObject.Interact();
            }
            else
            {
               mover.MoveToPoint(Vector3.MoveTowards(pointInteract, transform.position, distanceToStop));
            }
        }
        
    }


}

