using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class QuestTipUI : MonoBehaviour
{
    private Dictionary<Quest, QuestUIText> QuestUITextMap;
    private QuestManager questManager;
    [SerializeField] private QuestUIText prefabQuestText;
    [SerializeField] private GameObject panel;
    private bool isHaveData = false;

    [Inject] 
    public void Construct(QuestManager questManager)
    {
        this.questManager = questManager;
        this.questManager.OnStartQuest += QuestManager_OnStartQuest;
        this.questManager.OnChangeStep += QuestManager_OnChangeStep;
        this.questManager.OnFinishQuest += QuestManager_OnFinishQuest;
        QuestUITextMap = new Dictionary<Quest, QuestUIText>();
    }

    private void QuestManager_OnFinishQuest(Quest quest)
    {
        if (quest!=null && QuestUITextMap.ContainsKey(quest))
        {
            Destroy(QuestUITextMap[quest].gameObject);
            QuestUITextMap.Remove(quest);
        }
    }

    private void QuestManager_OnChangeStep(Quest quest)
    {
        if (!isHaveData)
        {
            QuestUIText questUIText = Instantiate(prefabQuestText, panel.transform);
            QuestUITextMap.Add(quest, questUIText);
            questUIText.SetQuestText(quest.info.QuestInfo);
            questUIText.SetStepText(quest.GetCurrentStepSO().StepInfo);
            isHaveData = true;
        }
        QuestUITextMap[quest].SetStepText(quest.GetCurrentStepSO().StepInfo);

    }

    private void QuestManager_OnStartQuest(Quest quest)
    {
       

    }


}
