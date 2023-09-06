using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class QuestTipUI : MonoBehaviour
{
    private List<QuestUIText> QuestUITextList;
    [SerializeField] private QuestManager QuestManager;
    [SerializeField] private QuestUIText prefabQuestText;
    [SerializeField] private GameObject panel;
    private void Start()
    {
        QuestManager.OnStartQuest += QuestManager_OnStartQuest;
        QuestManager.OnChangeStep += QuestManager_OnChangeStep;
        QuestUITextList = new List<QuestUIText>();

    }

    private void QuestManager_OnChangeStep(Quest obj)
    {
        QuestUITextList.FirstOrDefault().SetStepText(obj.GetCurrentStepSO().name);
    }

    private void QuestManager_OnStartQuest(Quest quest)
    {
        QuestUIText questUIText = Instantiate(prefabQuestText);
        QuestUITextList.Add(questUIText);
        questUIText.transform.parent = panel.transform;
        questUIText.SetQuestText(quest.info.name);
        questUIText.SetStepText(quest.GetCurrentStepSO().name);

    }

    public void AddQuest()
    {

    }

}
