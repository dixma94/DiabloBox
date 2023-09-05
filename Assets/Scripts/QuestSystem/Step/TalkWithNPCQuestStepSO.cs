using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkWithNPC", menuName = "ScriptableObjects/QuestStepSO/TalkWithNPC", order = 1) ]
public class TalkWithNPCQuestStepSO : QuestStepSO
{
    public NPCType npcType;
    public TextAsset textForDialogue;


    private void OnValidate()
    {
        questStep = new TalkNPCQuestStep();
    }
}

public class TalkNPCQuestStep : QuestStep
{

    TalkWithNPCQuestStepSO so;

    public override void InitializeQuestStep(QuestStepSO infoSO, string questId)
    {
        base.questId = questId;
        so = infoSO as TalkWithNPCQuestStepSO;

        NPC_Manager.GetNpc(so.npcType).QuestTextQueue.Enqueue(so);
        GameEventManager.instance.questEvents.onTalkWithNPCDone += TalkWithNPCDone;

    }

    private void TalkWithNPCDone(TalkWithNPCQuestStepSO so)
    {
        if (this.so == so)
        {
            FinishedQuestStep();
            GameEventManager.instance.questEvents.onTalkWithNPCDone -= TalkWithNPCDone;
        }
    }
}