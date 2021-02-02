using System;

public interface ILevelLoaderService
{
    int CurrentLevel { get; set; }
    int CurrentIntermediateLevel { get; set; }

    event Action onNextLevel;

    void Reload();

    void NextLevel();
}