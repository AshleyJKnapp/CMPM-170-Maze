using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //add UI package
using TMPro;

public class Counter : MonoBehaviour
{

    [SerializeField] private TMP_Text healthLabel;
    [SerializeField] double timer;
    public UIManagerScript uiScript;
    void Start()
    {

    }
    void Update(){
        if(!uiScript.checkHunterWin()){
            timer -= Time.deltaTime;
        }
        double seconds = timer % 60;
        healthLabel.text = seconds.ToString();
        if(timer <= 0){
            uiScript.ChangeToWinHide();

        }   
    }
}