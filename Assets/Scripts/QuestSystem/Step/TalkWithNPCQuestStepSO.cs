using System.ComponentModel;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TalkWithNPC", menuName = "ScriptableObjects/QuestStepSO/TalkWithNPC", order = 1) ]
public class TalkWithNPCQuestStepSO : QuestStepSO
{
    public NPCType npcType;
    public TextAsset textForDialogue;

    public override void InitializeQuestStepSO()
    {
        base.InitializeQuestStepSO();
        questStep = new TalkNPCQuestStep();

    }

}

public class TalkNPCQuestStep : QuestStep
{

    TalkWithNPCQuestStepSO so;


    public override void InitializeQuestStep(QuestStepSO infoSO, string questId,GameEventManager gameEventManager)
    {
        base.questId = questId;
        base.gameEventManager = gameEventManager;
        so = infoSO as TalkWithNPCQuestStepSO;

        //nPC_Manager.GetNpc(so.npcType).QuestTextQueue.Enqueue(so);
        base.gameEventManager.questEvents.QuestStepForDialogueCreate(so);
        base.gameEventManager.questEvents.onTalkWithNPCDone += TalkWithNPCDone;

    }

    private void TalkWithNPCDone(TalkWithNPCQuestStepSO so)
    {
        if (this.so == so)
        {
            FinishedQuestStep();
            gameEventManager.questEvents.onTalkWithNPCDone -= TalkWithNPCDone;
        }
    }
}
