using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("On Screen Controls")]
    public GameObject OnScreenControls;

    [Header("Button Control Events")]
    public static bool jumpbuttonDown;


    // Start is called before the first frame update
    void Start()
    {
        CheckPlatform();
    }

    //private methods

    private void CheckPlatform()
    {
        switch(Application.platform)
        {
            case RuntimePlatform.Android:
                OnScreenControls.SetActive(true);
                break;
            case RuntimePlatform.IPhonePlayer:
                OnScreenControls.SetActive(true);
                break;
            case RuntimePlatform.WindowsEditor:
                OnScreenControls.SetActive(true);
                break;

            default:
                OnScreenControls.SetActive(false);
                break;
        }
    }


    //event functions

    public void OnJumpButton_Down()
    {
        jumpbuttonDown = true;
    }

    public void OnJumpButton_Up()
    {
        jumpbuttonDown = false;
    }
}
