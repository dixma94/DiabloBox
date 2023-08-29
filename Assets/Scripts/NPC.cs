using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC : SelectableObject, IInteractable
{

    [SerializeField] private GameObject questHint;
    [SerializeField] private NPCDialogUI dialogUI;

    [Header("Config")]
    public TextAsset defaultText;
    public NPCType NPCType;

    public Queue<TextQuestStep> QuestTextQueue = new Queue<TextQuestStep>();

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
        float MaxRangeToPlayer = 20f;
        PlayerController player = FindPlayerInRange(MaxRangeToPlayer);

        if (player!=null)
        {
            RotateNpcToPlayer(player);
            ShowHideQuestTip();
        }
        else
        {
            HideQuestTip();
        }


    }

    private PlayerController FindPlayerInRange(float MaxRangeToPlayer)
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, MaxRangeToPlayer);
        PlayerController player;
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out player))
            {
                return player;
            }
        }
        return null;
    }

    private void ShowHideQuestTip()
    {
        if (QuestTextQueue.Count > 0)
        {
            ShowQuestTip();
        }
        else
        {
            HideQuestTip();
        }
    }

    private void HideQuestTip()
    {
        questHint.SetActive(false);
    }

    private void ShowQuestTip()
    {
        questHint.SetActive(true);
    }

    private void RotateNpcToPlayer(PlayerController player)
    {  
        float rotateSpeed = 1.5f;
        var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);  
    }


}
