using UnityEngine;
using Zenject;

public class CannonProjectileFactory : IProjectileFactory
{
    private const string CannonBulletPrefabPath = "Projectiles/Cannon Bullet";
    
    private GameObject cannonProjectilePrefab;
    private DiContainer diContainer;

    public CannonProjectileFactory(DiContainer diContainer)
    {
        this.diContainer = diContainer;
    }

    public void Load()
    {
        cannonProjectilePrefab = Resources.Load<GameObject>(CannonBulletPrefabPath);
    }
    public GameObject Create()
    {
        return diContainer.InstantiatePrefab(cannonProjectilePrefab);
    }
}