using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] Canvas GameHUD;
    [SerializeField] Canvas WinMenu;

    [SerializeField] Button RestartBtn;
    
    enum MenuState {
        HUD,
        Win,
    }

    MenuState CurrentMenu;

    void Start()
    {
        ChangeToHUD();
    }
    
    void MenuCheck()
    {
        if (CurrentMenu == MenuState.HUD)
        {
            GameHUD.enabled = true;
            WinMenu.enabled = false;

            RestartBtn.gameObject.SetActive(false);

        } else if (CurrentMenu == MenuState.Win)
        {
            GameHUD.enabled = false;
            WinMenu.enabled = true;

            RestartBtn.gameObject.SetActive(true);

        }
    }
    

    public void ChangeToHUD()
    {
        CurrentMenu = MenuState.HUD;
        MenuCheck();
    }

    public void ChangeToWin()
    {
        CurrentMenu = MenuState.Win;
        MenuCheck();
    }

    // public void StartGame()
    // {
    //     SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    // }
}