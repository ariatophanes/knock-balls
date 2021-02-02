using UnityEngine;
using Zenject;

public class CannonFactory : IWeaponFactory
{
    private const string CannonPrefabPath = "Weapons/Cannon";

    private DiContainer diContainer;
    private GameObject cannonPrefab;

    public CannonFactory(DiContainer diContainer)
    {
        this.diContainer = diContainer;
    }
    
    public void Load()
    {
        cannonPrefab = Resources.Load<GameObject>(CannonPrefabPath);
    }

    public Cannon Create()
    {
        return diContainer.InstantiatePrefab(cannonPrefab).GetComponent<Cannon>();
    }
}