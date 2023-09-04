using UnityEngine;

public class TalkNPCQuestStep : QuestStep
{
    public TalkNPCQuestStep(TextAsset text, NPCType nPCType)
    {
        NPC_Manager.GetNpc(nPCType).QuestTextQueue.Enqueue(text);

        GameEventManager.instance.questEvents.onTalkWithNPCDone += TalkWithNPCDone;
    }

    public override void InitializeQuestStep(string questId)
    {
        base.questId = questId;
    }

    private void TalkWithNPCDone(NPCType type)
    {
        FinishedQuestStep();
    }
}


