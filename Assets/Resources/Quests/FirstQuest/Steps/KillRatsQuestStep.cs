using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRatsQuestStep : QuestStep
{
    private int RatKilledCount;
    private int RatNeedToKill = 5;
    public override void InitializeQuestStep(string questId)
    {
        base.questId = questId;
        GameEventManager.instance.ratsEvents.onRatKilled += RatKill;
    }

    private void RatKill()
    {
        RatKilledCount++;
        if (RatKilledCount>= RatNeedToKill)
        {
            FinishedQuestStep();
        }
    }
}
