using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string name;
    [SerializeField] private GameObject SelectedVisual;


    private void Start()
    {
        SelectedVisual.SetActive(false);
    }

    private PlayerController player;
    public void RotateToPlayer(PlayerController player)
    {
        this.player = player;
        
    }

    public string Interact()
    {
        return "Hi I'm "+name;
    }

    private void Update()
    {
        float rotateSpeed = 1.5f;
        float rotateRange = 20f;
        if (player!=null && (Vector3.Distance(transform.position,player.transform.position)< rotateRange))
        {
            var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

            

    }
}
