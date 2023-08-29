using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkNPCSmittQuestStep : QuestStep
{

    [SerializeField] private TextAsset text;

    public override void InitializeQuestStep(string questId)
    {
        base.questId = questId;
        NPC nPC = NPC_Manager.GetNpc(NPCType.Smith);
        nPC.QuestTextQueue.Enqueue(new TextQuestStep() { questStep = this, textAsset = text });

    }
}
