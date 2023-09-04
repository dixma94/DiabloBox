using System;

public class QuestEvents
{


    public event Action<string> onAdvanceQuest;
    public void AdvanceQuest(string id)
    {
        onAdvanceQuest?.Invoke(id);
    }


    public event Action<Quest> onQuestStateChange;
    public void QuestStateChange(Quest quest)
    {
        onQuestStateChange?.Invoke(quest);
    }

    public event Action<NPCType> onTalkWithNPCDone;

    public void TalkWithNPC(NPCType npcType)
    {
        onTalkWithNPCDone?.Invoke(npcType);
    }

}