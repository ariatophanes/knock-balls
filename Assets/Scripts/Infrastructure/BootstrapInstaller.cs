using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindPlayerInput();
        BindLevelConstructor();
        BindFacebookWrapper();
    }

    private void BindFacebookWrapper()
    {
        Container.Bind<FacebookWrapper>().AsSingle().NonLazy();
    }

    private void BindPlayerInput()
    {
        Container.BindInterfacesTo<TouchInputService>().AsSingle();
    }
    private void BindLevelConstructor()
    {
        Container
            .Bind<ILevelLoaderService>()
            .To<LevelLoaderLoaderService>()
            .AsSingle();
    }
}
