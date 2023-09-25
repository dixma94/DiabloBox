using System;
using UnityEngine.UI;

public class QuestEvents
{


    public event Action<string> onAdvanceQuest;
    public void AdvanceQuest(string id)
    {
        onAdvanceQuest?.Invoke(id);
    }



    public event Action<TalkWithNPCQuestStepSO> onTalkWithNPCDone;

    public void TalkWithNPC(TalkWithNPCQuestStepSO so)
    {
        onTalkWithNPCDone?.Invoke(so);
    }

    public event Action<TalkWithNPCQuestStepSO> onQuestStepForDialogueCreate;

    public void QuestStepForDialogueCreate(TalkWithNPCQuestStepSO so)
    {
        onQuestStepForDialogueCreate?.Invoke(so);
    }
}