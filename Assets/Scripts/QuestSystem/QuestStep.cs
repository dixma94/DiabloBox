using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    private bool IsFinished = false;
    private string questId;

    public void InitializeQuestStep(string questId)
    {
        this.questId = questId;
      
    }
    protected void FinishedQuestStep()
    {
        if (!IsFinished)
        {
            IsFinished = true;
            GameEventManager.instance.questEvents.AdvanceQuest(questId);
            Destroy(this.gameObject);
        }
    }
}
