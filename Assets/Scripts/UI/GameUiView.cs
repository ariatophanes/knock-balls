using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameUiView : MonoBehaviour
{
    public Text nextLevelText, currentLevelText, attacksCount;
    public Image[] intermediateLevelImages;
    public Image currentLevelImage, nextLevelImage;
    public Color intermediateLevelFinishedColor, levelFinishedColor;

    [Inject]
    public void Construct()
    {

    }
}