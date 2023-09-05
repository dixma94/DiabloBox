using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStep
{
    private bool IsFinished = false;
    protected string questId;

    public virtual void InitializeQuestStep(QuestStepSO infoSO, string questId)
    {

      
    }
    [ContextMenu("FinishedQuestStep")]
    public void FinishedQuestStep()
    {
        if (!IsFinished)
        {
            IsFinished = true;
            GameEventManager.instance.questEvents.AdvanceQuest(questId);

        }
    }
}
