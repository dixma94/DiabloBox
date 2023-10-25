using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest 
{
    public QuestInfoSO info;
    public QuestState state;

    private int currentQuestStepIndex;

    public Quest(QuestInfoSO questinfo)
    {
        this.info = questinfo;
        this.state = QuestState.CAN_START;
        this.currentQuestStepIndex = 0;

    }

    public void MoveToNextStep()
    {
        currentQuestStepIndex++;
    }

    public bool CurrentStepExists()
    {
        return (currentQuestStepIndex < info.QuestSteps.Length);
    }

    public void InstantiateCurrentQuestStep(GameEventManager gameEventManager)
    {
        if (state == QuestState.IN_PROGRESS)
        {
            QuestStepSO so = info.QuestSteps[currentQuestStepIndex];
            so.InitializeQuestStep(info.id, gameEventManager);
        }
    }
    public QuestStepSO GetCurrentStepSO()
    {
        return info.QuestSteps[currentQuestStepIndex];
    }
    public int GetCurrentStepIndex()
    {
        return currentQuestStepIndex;
    }


}
