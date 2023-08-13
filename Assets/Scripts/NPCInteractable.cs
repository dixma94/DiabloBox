using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPC_Class
{
    Wizard,
    Smitt
}
public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject SelectedVisual;
    public TextAsset defaultText;

    [Header("Config")]
    public NPC_Class NPC_Class;
    public NPCDialogUI dialogUI;
    
   
    public Queue<TextQuestStep> QuestTextQueue = new Queue<TextQuestStep>();



    private void Start()
    {
        SelectedVisual.SetActive(false);
    }

    private PlayerController player;
    public void RotateToPlayer(PlayerController player)
    {
        this.player = player;
        
    }

    public void Interact()
    {

        if (QuestTextQueue.Count > 0)
        {
            TextQuestStep textQUestStep = QuestTextQueue.Dequeue();
            dialogUI.EnterDialogueMode(textQUestStep.questStep, textQUestStep.textAsset);
        }
        
        else 
        {
            dialogUI.EnterDialogueMode(defaultText);
        }
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
