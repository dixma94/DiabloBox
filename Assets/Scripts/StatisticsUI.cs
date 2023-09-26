using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class StatisticsUI : MonoBehaviour, IDataPersistence
{
    [SerializeField] TextMeshProUGUI _textMeshPro;
    private int RatsKilledCount;
    private void Start()
    {
        UpdateCount();

    }
    [Inject]
    public void Construct(GameEventManager gameEventManager)
    {
        gameEventManager.enemyEvents.onEnemyKilled += RatKilled;
    }

    private void RatKilled(EnemyType type)
    {
        RatsKilledCount++;
        UpdateCount();
    }

    private void UpdateCount()
    {
        _textMeshPro.text = "Rats Killed = " + RatsKilledCount;
    }

    public void LoadData(GameData data)
    {
        this.RatsKilledCount = data.ratsKilled;
    }

    public void SaveData(ref GameData data)
    {
        data.ratsKilled = this.RatsKilledCount;
    }
}
