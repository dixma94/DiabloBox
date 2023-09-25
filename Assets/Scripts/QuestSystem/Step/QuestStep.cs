using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class QuestStep
{
    private bool IsFinished = false;
    protected string questId;
    protected GameEventManager gameEventManager;


    public virtual void InitializeQuestStep(QuestStepSO infoSO, string questId, GameEventManager gameEventManager)
    {
        
      
    }
    [ContextMenu("FinishedQuestStep")]
    public void FinishedQuestStep()
    {
        if (!IsFinished)
        {
            IsFinished = true;
            gameEventManager.questEvents.AdvanceQuest(questId);

        }
    }
}
