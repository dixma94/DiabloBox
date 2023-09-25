using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameEventManager 
{
    public  QuestEvents questEvents;
    public  EnemyEvents enemyEvents;

    public GameEventManager()
    {
        questEvents = new QuestEvents();
        enemyEvents = new EnemyEvents();

    }

}


