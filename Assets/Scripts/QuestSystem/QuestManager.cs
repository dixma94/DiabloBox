using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class QuestManager 
{
    public event Action<Quest> OnStartQuest;
    public event Action<Quest> OnChangeStep;
    public event Action<Quest> OnFinishQuest;
    private Dictionary<string, Quest> questMap;
    private GameEventManager gameEventManager;
    private DataSaveLoadManager dataSaveLoadManager;

    public QuestManager(GameEventManager gameEventManager, DataSaveLoadManager dataSaveLoadManager)
    {
        this.gameEventManager = gameEventManager;
        this.gameEventManager.questEvents.onAdvanceQuest += AdvanceQuest;
        this.dataSaveLoadManager = dataSaveLoadManager;
        questMap = CreateQuestMap();
    }



    public void UpdateState()
    {
        foreach (Quest quest in questMap.Values)
        {
            if (quest.state == QuestState.IN_PROGRESS)
            {
                if (quest.CurrentStepExists())
                {
                    quest.InstantiateCurrentQuestStep(gameEventManager);
                    OnChangeStep?.Invoke(quest);
                }
                else
                {
                    ChangeQuestState(quest.info.id, QuestState.FINISHED);
                    FinishQuest(quest.info.id);
                    UpdateState();
                }
            }
            if (quest.state == QuestState.CAN_START && CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.id, QuestState.IN_PROGRESS);
                if (quest.CurrentStepExists())
                {
                    quest.InstantiateCurrentQuestStep(gameEventManager);
                }
                OnStartQuest?.Invoke(quest);

            }
        }
    }

    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
       
    }


    private void AdvanceQuest(string id)
    {
        Quest quest = GetQuestById(id);

        quest.MoveToNextStep();

        if (quest.CurrentStepExists())
        {
            quest.InstantiateCurrentQuestStep(gameEventManager);
            OnChangeStep?.Invoke(quest);
        }
        else
        {
            ChangeQuestState(quest.info.id, QuestState.FINISHED);
            FinishQuest(quest.info.id);
            UpdateState();
        }
    }

    private void FinishQuest(string id)
    {
        OnFinishQuest?.Invoke(GetQuestById(id));
        Debug.Log("Finish");
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        // start true and prove to be false
        bool meetsRequirements = true;


        // check quest prerequisites for completion
        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisites)
        {
            if (GetQuestById(prerequisiteQuestInfo.id).state != QuestState.FINISHED)
            {
                meetsRequirements = false;
            }
        }

        return meetsRequirements;
    }

    private Dictionary<string, Quest> CreateQuestMap()
    {

        if (dataSaveLoadManager.GetGameData().quests.Count ==0)
        {
            // loads all QuestInfoSO Scriptable Objects under the Assets/Resources/Quests folder
            QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
            // Create the quest map
            Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
            foreach (QuestInfoSO questInfo in allQuests)
            {
                if (idToQuestMap.ContainsKey(questInfo.id))
                {
                    Debug.LogWarning("Duplicate ID found when creating quest map: " + questInfo.id);
                }
                idToQuestMap.Add(questInfo.id, new Quest(questInfo, dataSaveLoadManager));
            }
            return idToQuestMap;
        }
        else
        {
            Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
            foreach (Quest quest in dataSaveLoadManager.GetGameData().quests)
            {
                idToQuestMap.Add(quest.info.id, quest);
                quest.dataSaveLoadManager = dataSaveLoadManager;
            }
            return idToQuestMap;
        }
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if (quest == null)
        {
            Debug.LogError("ID not found in the Quest Map: " + id);
        }
        return quest;
    }
}
