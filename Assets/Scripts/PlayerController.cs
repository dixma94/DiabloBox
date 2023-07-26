using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private MouseInput input;
    [SerializeField] private NPCDialogUI nPCDialogUI;

    private Vector3 NPCposition;
    private IInteractable npc;

    private void Start()
    {
        input.OnEnvironmentClick += Input_OnEnvironmentClick;
        input.OnInteractableClick += Input_OnInteractableClick;
    }

    private void Input_OnInteractableClick(IInteractable interactableObject, Vector3 pointInteract)
    {
        float distanceToInteract = 15f;
        float distanceToStop = 3f;
        NPCposition = pointInteract;
        npc = interactableObject;
        pointInteract.y = 0f;
        if (Vector3.Distance(transform.position,pointInteract)<=distanceToInteract)
        {
            nPCDialogUI.Show("HI");
        }
        else
        {
            Input_OnEnvironmentClick(Vector3.MoveTowards(pointInteract, transform.position, distanceToStop));
        }
    }

    private void Input_OnEnvironmentClick(Vector3 point)
    {
        agent.destination = point;
    }

    private void Update()
    {
        float interactRange = 14f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.RotateToPlayer(this);
            }

        }
        if (npc != null)
        {
            if(Vector3.Distance(NPCposition,transform.position)> interactRange)
            {
                nPCDialogUI.Hide();
                npc = null;
            }
        }
        

    }

}
