using System;
using UnityEngine;
using Zenject;

public class Cannon : MonoBehaviour, IWeapon
{
    public int AttacksCount { get; set; }
    
    public event Action onAttack;

    private IProjectileFactory projectileFactory;

    private IInputService inputService;

    private Camera camera;

    public float shootForce = 10;

    private const float minAttackDirY = -0.15f;

    [Inject]
    public void Construct(IProjectileFactory projectileFactory, IInputService inputService, Camera camera)
    {
        this.projectileFactory = projectileFactory;
        this.camera = camera;
        this.inputService = inputService;
        
        projectileFactory.Load();
        
        Subscribe();
    }

    private void Subscribe()
    {
        inputService.onAttack += Attack;
    }
    
    private void Unsubscribe()
    {
        inputService.onAttack -= Attack;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
    
    public void Attack(Vector3 pointerPos)
    {
        Ray ray = camera.ScreenPointToRay(pointerPos);
        
        Vector3 dir = (ray.GetPoint(1) - ray.GetPoint(0)).normalized;

        if (AttacksCount <= 0) return;

        if (dir.y < minAttackDirY) return;
        
        AttacksCount--;

        GameObject bullet = projectileFactory.Create();
        
        bullet.GetComponent<Rigidbody>().AddForce(dir * shootForce + Vector3.up * 3, ForceMode.Impulse);
        
        onAttack?.Invoke();
    }
}