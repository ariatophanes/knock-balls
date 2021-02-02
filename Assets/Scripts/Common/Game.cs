using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
    private IWeapon weapon;
    private GameUiView ui;
    private BlockContainer blockContainer;
    private ILevelLoaderService levelLoaderService;

    private int attacksCount;

    [Inject]
    public void Construct(IWeaponFactory weaponFactory,
        GameUIViewFactory gameUiViewFactory,
        BlockContainer blockContainer,
        ILevelLoaderService levelLoaderService)
    {
        this.levelLoaderService = levelLoaderService;
        this.blockContainer = blockContainer;
        
        ui = gameUiViewFactory.Create();

        weaponFactory.Load();
        
        weapon = weaponFactory.Create();
        
        Subscribe();
        
        ConfigureAttacksCount();
        
        SetupUI();
    }

    private void SetupUI()
    {
        UpdateAttacksCountText();
        
        ui.currentLevelText.text = (levelLoaderService.CurrentLevel + 1).ToString();
        ui.nextLevelText.text = (levelLoaderService.CurrentLevel + 2).ToString();

        for (int i = 0; i <= levelLoaderService.CurrentIntermediateLevel; i++)
        {
            ui.intermediateLevelImages[i].color = ui.intermediateLevelFinishedColor;
        }
    }

    private void UpdateAttacksCountText()
    {
        ui.attacksCount.text = attacksCount.ToString();
    }

    private void Subscribe()
    {
        weapon.onAttack += HandleWeaponAttackEvent;
        blockContainer.onAllBlocksFell += HandleAllBlocksFellEvent;
    }

    private void Unsubscribe()
    {
        weapon.onAttack -= HandleWeaponAttackEvent;
        blockContainer.onAllBlocksFell -= HandleAllBlocksFellEvent;
    }
    
    private void HandleAllBlocksFellEvent()
    {
        WinTimer();
    }

    private void HandleWeaponAttackEvent()
    {
        attacksCount--;
        
        UpdateAttacksCountText();

        if (attacksCount == 0) FailTimer();
    }
    

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void ConfigureAttacksCount()
    {
        attacksCount = CalculateAttacksCount();
        weapon.AttacksCount = attacksCount;
    }

    private void WinTimer()
    {
        if(levelLoaderService.CurrentIntermediateLevel == 4) 
            ui.nextLevelImage.color = ui.levelFinishedColor;
        
        Invoke("Win", 0.5f);
    }

    private void FailTimer()
    {
        Invoke("Fail", 3);
    }

    private void Fail()
    {
        levelLoaderService.Reload();
    }

    private void Win()
    {
        levelLoaderService.NextLevel();
    }

    private int CalculateAttacksCount()
    {
        return 3 * (levelLoaderService.CurrentLevel + 1);
    }
}