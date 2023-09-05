using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest 
{
    public QuestInfoSO info;
    public QuestState state;

    private int currentQuestStepIndex;
    private QuestStep[] questStepArray;

    public Quest(QuestInfoSO questinfo)
    {
        this.info = questinfo;
        this.state = QuestState.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;

        questStepArray = new QuestStep[questinfo.QuestSteps.Length];
        InstantiateCurrentQuestStep();
    }

    public void MoveToNextStep()
    {
        currentQuestStepIndex++;
    }

    public bool CurrentStepExists()
    {
        return (currentQuestStepIndex < info.QuestSteps.Length);
    }

    public void InstantiateCurrentQuestStep()
    {
        //questStepArray[currentQuestStepIndex] = info.QuestSteps[currentQuestStepIndex].questStep;
        QuestStepSO so = info.QuestSteps[currentQuestStepIndex];
        so.questStep.InitializeQuestStep(so,info.id);
    }


}
