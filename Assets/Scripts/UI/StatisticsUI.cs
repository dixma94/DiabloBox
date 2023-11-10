using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StatisticsUI : MonoBehaviour, IDataSave
{
    [SerializeField] TextMeshProUGUI _textMeshPro;
    [SerializeField] Button quitButton;
    private int RatsKilledCount;
    private DataSaveLoadManager dataPersistenceManager;

    private void Start()
    {
        UpdateCount();
        quitButton.onClick.AddListener(QuitGame);

    }
    [Inject]
    public void Construct(GameEventManager gameEventManager, DataSaveLoadManager dataPersistenceManager)
    {
        gameEventManager.enemyEvents.onEnemyKilled += RatKilled;
        this.dataPersistenceManager = dataPersistenceManager;
        RatsKilledCount = this.dataPersistenceManager.GetGameData().ratsKilled;
        this.dataPersistenceManager.AddSaveDataObject(this);
    }


    private void QuitGame()
    {
        this.dataPersistenceManager.SaveGame();
        Application.Quit();
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

    public void SaveData(ref GameData data)
    {
        data.ratsKilled = this.RatsKilledCount;
    }
}
