﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public GotoShopScene UIManager;
    public void QuitGame()
    {
        GameData.Instance.PlayerSave();
        Application.Quit();
    }
    public void KeepPlay()
    {
        UIManager.CloseUI();
    }
}
