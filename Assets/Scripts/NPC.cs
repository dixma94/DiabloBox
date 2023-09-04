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
    public NPCType npcType;

    public Queue<TextAsset> QuestTextQueue = new Queue<TextAsset>();   
    
    public Vector3 GetPosition()
    {
        return transform.position; 
    }
    
    public void Interact()
    {

        if (QuestTextQueue.Count > 0)
        {
            dialogUI.EnterDialogueMode(QuestTextQueue.Dequeue(), this.npcType);
        }
        
        else 
        {
            dialogUI.EnterDialogueMode(defaultText,npcType);
        }
    }

    private void Update()
    {
        float MaxRangeToPlayer = 10f;
        PlayerController player = FindPlayerInRange(MaxRangeToPlayer);

        if (player!=null)
        {
            RotateNpcToPlayer(player);
            ShowHideQuestTip();
        }
        else
        {
            HideQuestTip();
            if (dialogUI.npcType == this.npcType && dialogUI.IsPlaying)
            {
                dialogUI.ExitDialogueMode();
            }
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
