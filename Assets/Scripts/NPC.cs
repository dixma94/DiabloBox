using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NPC : SelectableObject
{

    [SerializeField] private GameObject questHint;
    [SerializeField] private NPCDialogUI dialogUI;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private WayPointNPC[] wayPointArray;
      
    private bool IsMoveToWaypoint = false;
    private bool IsMoveToSpawnOnject = false;
    private int currentWaypointIndex = 0;

    [Header("Config")]
    public TextAsset defaultText;
    public NPCType npcType;

    public Queue<TalkWithNPCQuestStepSO> QuestTextQueue = new Queue<TalkWithNPCQuestStepSO>();   
    
    public Vector3 GetPosition()
    {
        return transform.position; 
    }
    
    public override void Interact(PlayerController player)
    {

        if (QuestTextQueue.Count > 0)
        {
            TalkWithNPCQuestStepSO so = QuestTextQueue.Dequeue();
            dialogUI.EnterDialogueMode(so.textForDialogue,so);
        }
        
        else 
        {
            dialogUI.EnterDialogueMode(defaultText,npcType);
        }
    }

    private void Update()
    {


        float MaxRangeToPlayer = 10f;
        float MaxDistanceNpcCanGoAway = 15f;

        if (Vector3.Distance(transform.position, spawnPoint.transform.position) > MaxDistanceNpcCanGoAway)
        {
            StartCoroutine(MoveToSpawnPoint());
        }

        if (IsPlayerInRange(MaxRangeToPlayer, out PlayerController player))
        {
            if (!IsMoveToSpawnOnject)
            {
                RotateNpcToPlayer(player);
                if (IsHaveQuest())
                {
                    MoveToPlayer(player);
                    ShowQuestTip();
                }
                else
                {
                    HideQuestTip();
                }
            }

        }
        else
        {
            if (!IsMoveToWaypoint)
            {
                StartCoroutine(MoveToWayPoint());
            }

            HideQuestTip();
            if (dialogUI.npcType == this.npcType && dialogUI.IsPlaying)
            {
                dialogUI.ExitDialogueMode();
            }
        }


    }

    private IEnumerator MoveToWayPoint()
    {
        IsMoveToWaypoint = true;
        agent.destination = wayPointArray[currentWaypointIndex].transform.position;
        
        float positonShift = 1f;
        yield return new WaitUntil(()
        => Vector3.Distance(transform.position, wayPointArray[currentWaypointIndex].transform.position) < positonShift);
        
        yield return new WaitForSeconds(Random.Range(5,15));
        if (currentWaypointIndex == wayPointArray.Length-1)
        {
            currentWaypointIndex = 0;
        }
        else
        {
            currentWaypointIndex++;
        }
        IsMoveToWaypoint = false;
    }

    private IEnumerator MoveToSpawnPoint()
    {
        IsMoveToSpawnOnject = true;
        agent.destination = spawnPoint.transform.position;

        float positonShift = 1f;
        yield return new WaitUntil(()
        => Vector3.Distance(transform.position, spawnPoint.transform.position) < positonShift);
        IsMoveToSpawnOnject = false;

    }

    private void MoveToPlayer(PlayerController player)
    {
        float distanceToInteract = 4f;
        agent.destination = Vector3.MoveTowards(player.transform.position, transform.position, distanceToInteract);
    }

    private bool IsPlayerInRange(float MaxRangeToPlayer, out PlayerController player)
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, MaxRangeToPlayer);
        
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out PlayerController playerComponent))
            {
                player = playerComponent;
                return true;
            }
        }
        player = null;
        return false;
    }

  

    private bool IsHaveQuest()
    {
        return QuestTextQueue.Count > 0;
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
    public override void ShowInfo()
    {
        tipUI.ShowInfoAboutNPC(info);
    }



}
