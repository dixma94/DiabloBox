using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkNPCWizardQuestStep : QuestStep
{

    [SerializeField] private TextAsset text;

    public override void InitializeQuestStep(string questId)
    {
        base.questId = questId;
        NPCInteractable nPC = NPC_Manager.GetNpc(NPC_Class.Wizard);
        nPC.QuestTextQueue.Enqueue(new TextQuestStep() { questStep = this, textAsset = text });

    }
    
}


