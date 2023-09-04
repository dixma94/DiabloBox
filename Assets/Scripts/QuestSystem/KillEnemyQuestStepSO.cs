using UnityEngine;

[CreateAssetMenu(fileName = "KillEnemy", menuName = "ScriptableObjects/QuestStepSO/ KillEnemy", order = 2)]
public class KillEnemyQuestStepSO : ScriptableObject
{
    public SelectableObject enemy;
    public int count;
    
}
