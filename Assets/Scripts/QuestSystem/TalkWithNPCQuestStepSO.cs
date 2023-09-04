using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkWithNPC", menuName = "ScriptableObjects/QuestStepSO/TalkWithNPC", order = 1) ]
public class TalkWithNPCQuestStepSO : ScriptableObject
{
    public NPCType npcType;
    public TextAsset textForDialogue;
    
}
