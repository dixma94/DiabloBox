using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Quest: IDataSave
{
    [SerializeField] public QuestInfoSO info;
    [SerializeField] public QuestState state;
    public DataSaveLoadManager dataSaveLoadManager;

    [SerializeField] private int currentQuestStepIndex;

    public Quest(QuestInfoSO questinfo, DataSaveLoadManager dataSaveLoadManager)
    {
        this.info = questinfo;
        this.state = QuestState.CAN_START;
        this.currentQuestStepIndex = 0;
        this.dataSaveLoadManager = dataSaveLoadManager;
        dataSaveLoadManager.AddSaveDataObject(this);

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
            so.InitializeQuestStep(info.id, gameEventManager,dataSaveLoadManager);
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

    public void SaveData(ref GameData data)
    {
        data.AddQuestToSave(this);
    }
}
