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
    [SerializeField] Canvas WinHider;

    [SerializeField] Button RestartBtn;
    
    enum MenuState {
        HUD,
        Win,

        Hide,
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
            WinHider.enabled = false;

            RestartBtn.gameObject.SetActive(false);

        } else if (CurrentMenu == MenuState.Win)
        {
            GameHUD.enabled = false;
            WinMenu.enabled = true;
            WinHider.enabled = false;

            RestartBtn.gameObject.SetActive(true);

        } else if (CurrentMenu == MenuState.Hide)
        {
            GameHUD.enabled = false;
            WinMenu.enabled = false;
            WinHider.enabled = true;

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
    public void ChangeToWinHide()
    {
        CurrentMenu = MenuState.Hide;
        MenuCheck();
    }
    public bool checkHunterWin(){//Check if the hunter win menu enabled, to be used with counter script
        return WinMenu.enabled;
    }

    // public void StartGame()
    // {
    //     SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    // }
}