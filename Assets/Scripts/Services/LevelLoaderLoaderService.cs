using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelLoaderLoaderService : ILevelLoaderService
{ 
    public int CurrentLevel
    {
        get => PlayerPrefs.GetInt("Level", 0);
        set => PlayerPrefs.SetInt("Level", value);
    }
    public int CurrentIntermediateLevel { get; set; }
    public event Action onNextLevel;

    public void Reload()
    {
        CurrentIntermediateLevel = 0;
        LoadScene();
    }

    public void NextLevel()
    {
        CurrentIntermediateLevel += 1;

        if (CurrentIntermediateLevel == 5)
        {
            CurrentLevel++;
            CurrentIntermediateLevel = 0;
            onNextLevel?.Invoke();
        }
        
        LoadScene();
    }
    
    private void LoadScene()
    {
        SceneManager.LoadScene(CurrentLevel * 5 + CurrentIntermediateLevel);
    }
}
