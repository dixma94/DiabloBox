using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    public Transform StartPoint;
    public GameObject HeroPrefab;
    public MouseInput mouseInput;
    public SelectebleObjectsDictionary selectebleObjects;

    public override void InstallBindings()
    {
        BindSelectebleObjects();
        BindMouseInput();
        BindHero();
    }

    private void BindMouseInput()
    {
        Container
            .Bind<MouseInput>()
            .FromInstance(mouseInput)
            .AsSingle();
    }
    private void BindSelectebleObjects()
    {
        Container
            .Bind<SelectebleObjectsDictionary>()
            .FromInstance(selectebleObjects)
            .AsSingle();
    }

    private void BindHero()
    {
        PlayerController playerController = Container.
             InstantiatePrefabForComponent<PlayerController>(HeroPrefab, StartPoint.position, Quaternion.identity, null);

        Container
             .Bind<PlayerController>()
             .FromInstance(playerController)
             .AsSingle();
    }
}


