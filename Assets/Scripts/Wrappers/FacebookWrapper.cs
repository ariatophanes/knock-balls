using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;

public class FacebookWrapper
{
    public FacebookWrapper(ILevelLoaderService levelLoaderService)
    {
        FB.Init(
            () => FB.ActivateApp(),
            shown => Time.timeScale = shown ? 1 : 0
            );

        levelLoaderService.onNextLevel += HandleNextLevelEvent;
    }

    private void HandleNextLevelEvent()
    {
        FB.LogAppEvent(Facebook.Unity.AppEventName.AchievedLevel);
    }
}
