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
    [SerializeField] private QuestInfoSO questInfo;
    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;
    private string questId;
    private QuestState currentQuestState;
    public NPC_Class NPC_Class;
    public NPCDialogUI dialogUI;
    
   
    public Queue<TextQUestStep> DialogueQueue = new Queue<TextQUestStep>();

    private void Awake()
    {
        questId = questInfo.id;
    }
    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange += QuestStateChange;
    }


    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }
    private void QuestStateChange(Quest quest)
    {
        // only update the quest state if this point has the corresponding quest
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            //questIcon.SetState(currentQuestState, startPoint, finishPoint);
        }
    }

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
        // start or finish a quest
        if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            GameEventManager.instance.questEvents.StartQuest(questId);
            if (DialogueQueue.Count > 0)
            {
                TextQUestStep textQUestStep = DialogueQueue.Dequeue();
                dialogUI.EnterDialogueMode(textQUestStep.questStep, textQUestStep.textAsset);
            }
        }
        else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
        {
            GameEventManager.instance.questEvents.FinishQuest(questId);
        }
        else if (DialogueQueue.Count > 0)
        {
                TextQUestStep textQUestStep = DialogueQueue.Dequeue();
                dialogUI.EnterDialogueMode(textQUestStep.questStep, textQUestStep.textAsset);
        }
        else 
        {
            dialogUI.EnterDialogueMode(null, defaultText);
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
