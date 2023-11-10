using UnityEngine;
using Zenject;

public partial class LocationInstaller : MonoInstaller
{ 
    public Transform StartPoint;
    public GameObject HeroPrefab;
    public NPC_Manager nPC_Manager;
    public TipUI tipUI;
    public NPCDialogUI npcDialogUI;

    public override void InstallBindings()
    {
        BindLocationInstaller();
        BindAsSingle<GameEventManager>();
        BindFromInstance(tipUI);
        BindFromInstance(npcDialogUI);
        BindAsSingle<NpcFactory>();
        BindAsSingle<EnemyFactory>();
        BindFromInstance(nPC_Manager);
        BindAsSingle<SelectebleObjectsDictionary>();
        BindAsSingle<DataSaveLoadManager>();
        BindAsSingle<SavePointsManager>();
        BindHero();
        BindAsSingle<QuestManager>();


    }
    private void BindFromInstance<T>(T instance)
    {
        Container.
            Bind<T>().
            FromInstance(instance).
            AsSingle();
    }


    private void BindLocationInstaller()
    {
        Container
            .BindInterfacesTo<LocationInstaller>()
            .FromInstance(this)
            .AsSingle();
    }

    private void BindHero()
    {
        SavePointsManager savePointsManager = Container.Resolve<SavePointsManager>();
        if (savePointsManager.currentSavePoint== Vector3.zero)
        {
            savePointsManager.currentSavePoint = StartPoint.position;
        }

        PlayerController playerController = Container.
             InstantiatePrefabForComponent<PlayerController>(HeroPrefab, savePointsManager.currentSavePoint, Quaternion.identity, null);

        Container
             .Bind<PlayerController>()
             .FromInstance(playerController)
             .AsSingle();
    }

    private void BindAsSingle<T>()
    {
            Container
            .Bind<T>()
            .AsSingle();
    }


}


