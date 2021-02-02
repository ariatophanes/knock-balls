using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneBootstrapInstaller : MonoInstaller
{
    public GameObject gameUiView;

    public override void InstallBindings()
    {
        BindCamera();
        BindProjectileFactory();
        BindWeapon();
        BindUIFactory();
        BindBlockContainer();
    }

    private void BindGame()
    {
        Container.Bind<Game>().FromComponentInHierarchy().AsSingle().NonLazy();
    }

    private void BindBlockContainer()
    {
        Container.Bind<BlockContainer>().FromComponentInHierarchy().AsSingle();
    }

    private void BindWeapon()
    {
        Container
            .Bind<IWeaponFactory>()
            .To<CannonFactory>()
            .AsSingle();
    }
    
    private void BindProjectileFactory()
    {
        Container
            .Bind<IProjectileFactory>()
            .To<CannonProjectileFactory>()
            .AsSingle();
    }

    private void BindCamera()
    {
        Container
            .Bind<Camera>()
            .FromInstance(Camera.main)
            .AsSingle();
    }
    private void BindUIFactory()
    {
        Container
            .BindFactory<GameUiView, GameUIViewFactory>()
            .FromComponentInNewPrefab(gameUiView)
            .AsSingle();
    }

}