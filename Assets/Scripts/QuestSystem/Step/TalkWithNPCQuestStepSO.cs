using System.ComponentModel;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TalkWithNPC", menuName = "ScriptableObjects/QuestStepSO/TalkWithNPC", order = 1) ]
public class TalkWithNPCQuestStepSO : QuestStepSO
{
    public NPCType npcType;
    public TextAsset textForDialogue;

    public override void InitializeQuestStep( string questId, GameEventManager gameEventManager)
    {
        base.questId = questId;
        base.gameEventManager = gameEventManager;
        base.gameEventManager.questEvents.QuestStepForDialogueCreate(this);
        base.gameEventManager.questEvents.onTalkWithNPCDone += TalkWithNPCDone;

    }

    private void TalkWithNPCDone(TalkWithNPCQuestStepSO so)
    {
        if (this == so)
        {
            FinishedQuestStep();
            gameEventManager.questEvents.onTalkWithNPCDone -= TalkWithNPCDone;
        }
    }

}


