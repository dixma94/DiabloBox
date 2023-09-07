using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class QuestTipUI : MonoBehaviour
{
    private Dictionary<Quest,QuestUIText> QuestUITextMap;
    [SerializeField] private QuestManager QuestManager;
    [SerializeField] private QuestUIText prefabQuestText;
    [SerializeField] private GameObject panel;
    private void Start()
    {
        QuestManager.OnStartQuest += QuestManager_OnStartQuest;
        QuestManager.OnChangeStep += QuestManager_OnChangeStep;
        QuestManager.OnFinishQuest += QuestManager_OnFinishQuest;
        QuestUITextMap = new Dictionary<Quest, QuestUIText>();

    }

    private void QuestManager_OnFinishQuest(Quest quest)
    {
        Destroy(QuestUITextMap[quest].gameObject);
        QuestUITextMap.Remove(quest);
    }

    private void QuestManager_OnChangeStep(Quest quest)
    {
        if (quest.GetCurrentStepIndex() == 1)
        {
            QuestUIText questUIText = Instantiate(prefabQuestText, panel.transform);
            QuestUITextMap.Add(quest, questUIText);
            questUIText.SetQuestText(quest.info.QuestInfo);
            questUIText.SetStepText(quest.GetCurrentStepSO().StepInfo);
        }
        QuestUITextMap[quest].SetStepText(quest.GetCurrentStepSO().StepInfo);

    }

    private void QuestManager_OnStartQuest(Quest quest)
    {
        if (quest.GetCurrentStepIndex()!=0)
        {
            QuestUIText questUIText = Instantiate(prefabQuestText, panel.transform);
            QuestUITextMap.Add(quest, questUIText);
            questUIText.SetQuestText(quest.info.QuestInfo);
            questUIText.SetStepText(quest.GetCurrentStepSO().StepInfo);
        }


    }


}
