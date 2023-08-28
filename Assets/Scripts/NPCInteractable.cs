using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPC_Class
{
    Wizard,
    Smitt
}
public class NPCInteractable : SelectableObject
{

    public TextAsset defaultText;

    [Header("Config")]
    public NPC_Class NPC_Class;
    public NPCDialogUI dialogUI;
    public GameObject questHint;

    public Queue<TextQuestStep> QuestTextQueue = new Queue<TextQuestStep>();




    private PlayerController player;
    public override void RotateToPlayer(PlayerController player)
    {
        this.player = player;
        
    }

    public override void Interact()
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
            if (QuestTextQueue.Count > 0)
            {
                questHint.SetActive(true);
            }
            else { questHint.SetActive(false); }
        }
        else { questHint.SetActive(false); }

    }
    
   
}
