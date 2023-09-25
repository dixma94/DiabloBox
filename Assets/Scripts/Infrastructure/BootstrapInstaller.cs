using UnityEngine;
using Zenject;

public class BootstrapInstaller: MonoInstaller
{
    public MouseInput mouseInputPrefab;

    public override void InstallBindings()
    {
        BindMouseService();

    }
    private void BindMouseService()
    {
        Container
            .Bind<ImouseService>()
            .To<MouseInput>()
            .FromComponentInNewPrefab(mouseInputPrefab)
            .AsSingle();
    }
}


public class Greeter
{

}
