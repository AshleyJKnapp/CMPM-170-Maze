using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerScript : MonoBehaviour
{
    public Camera playerCamera;
    public int maxRaycastDistance = 10;
    Vector3 pos = new Vector3(Screen.width/4, Screen.height/2, 0);
    public GameObject clickTarget;

    public KeyCode targetKey = KeyCode.Space;
    public UIManagerScript uiScript;

    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(pos);
        Debug.DrawRay(ray.origin, ray.direction * maxRaycastDistance, Color.yellow);

        RaycastHit hit;
		if (Physics.Raycast(ray, out hit, maxRaycastDistance)){
            if (Input.GetKey(targetKey) && hit.collider.gameObject == clickTarget) {
                Debug.Log("Hiding player lost!");
                WinGame();
            }
        }
    }

    void WinGame(){
        uiScript.ChangeToWin();
    }

}
