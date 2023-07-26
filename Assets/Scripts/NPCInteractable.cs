using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private NavMeshAgent agent;

    private PlayerController player;
    public void RotateToPlayer(PlayerController player)
    {
        this.player = player;
        
    }

    public void Interact()
    {
        Debug.Log(this);
    }

    private void Update()
    {
        float rotateSpeed = 1.5f;
        float rotateRange = 25f;
        if (player!=null && (Vector3.Distance(transform.position,player.transform.position)< rotateRange))
        {
            var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

            

    }
}
