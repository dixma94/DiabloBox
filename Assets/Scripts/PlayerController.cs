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

    private void Start()
    {
        input.OnEnvironmentClick += Input_OnEnvironmentClick;
        input.OnInteractableClick += Input_OnInteractableClick;
    }

    private void Input_OnInteractableClick(IInteractable interactableObject, Vector3 point)
    {
        float distanceToInteract = 15f;
        point.y = 0f;
        if (Vector3.Distance(transform.position,point)<=distanceToInteract)
        {
            interactableObject.Interact();
        }
        else
        {
            Input_OnEnvironmentClick(Vector3.MoveTowards(point, transform.position, 3f));


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

    }

}
