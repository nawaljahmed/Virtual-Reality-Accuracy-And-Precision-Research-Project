using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_TrackedObject controllerRight;
    private SteamVR_TrackedObject controllerLeft;

    public GameObject leftController;
    public GameObject rightController;

    public GameObject userMenu;
    public GameObject locomotionMenu;
    public GameObject levelMenu;

    public bool userMenuActive = false;
    public bool locomotionMenuActive = false;

    public bool rightMenuActive = false;
    public bool leftMenuActive = false;

    public bool XRoomConsole = false;
    //public Button teleport;
    //public Button worldGrab;
    //public Button blink;
    //public Button armSwing;
    //public Button slide;
    //public Button exit;
    //fuck alex

    Menu menu;
    ControllerGrabObject cGOL;
    ControllerGrabObject cGOR;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        controllerLeft = leftController.GetComponent<SteamVR_TrackedObject>();
        controllerRight = rightController.GetComponent<SteamVR_TrackedObject>();
        userMenu.SetActive(false);
        locomotionMenu.SetActive(false);
        levelMenu.SetActive(false);
        locomotionMenu.SetActive(false);
    }
    void Start()
    {
        menu = leftController.GetComponent<Menu>();
        cGOL = leftController.GetComponent<ControllerGrabObject>();
        cGOR = rightController.GetComponent<ControllerGrabObject>();
    }
    void Update()
    {
        if(RightController.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            if(!rightMenuActive)
            {
                rightMenuActive = true;
            }
            else
            {
                rightMenuActive = false;
            }
            if ((rightMenuActive && !userMenuActive && !locomotionMenuActive && !XRoomConsole) || (leftMenuActive && !userMenuActive && !locomotionMenuActive && !XRoomConsole))
            {
                userMenu.SetActive(true);
                userMenuActive = true;
            }
            else if (!rightMenuActive && !leftMenuActive)
            {
                userMenu.SetActive(false);
                locomotionMenu.SetActive(false);
                levelMenu.SetActive(false);
                userMenuActive = false;
            }
        }
        if (LeftController.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            if(!leftMenuActive)
            {
                leftMenuActive = true;
            }
            else
            {
                leftMenuActive = false;
            }
            if ((rightMenuActive && !userMenuActive && !locomotionMenuActive && !XRoomConsole) || (leftMenuActive && !userMenuActive && !locomotionMenuActive && !XRoomConsole))
            {
                userMenu.SetActive(true);
                userMenuActive = true;
            }
            else if(!rightMenuActive && !leftMenuActive)
            {
                userMenu.SetActive(false);
                locomotionMenu.SetActive(false);
                levelMenu.SetActive(false);
                userMenuActive = false;
            }
        }
        
    }
    private SteamVR_Controller.Device LeftController
    {
        get { return SteamVR_Controller.Input((int)controllerLeft.index); }
    }
    private SteamVR_Controller.Device RightController
    {
        get { return SteamVR_Controller.Input((int)controllerRight.index); }
    }
    //public void LocomotionMenuToggle()
    //{
    //    if (!locomotionMenuActive)
    //    {
    //        locomotionMenu.SetActive(true);
    //        locomotionMenuActive = true;
    //        userMenu.SetActive(false);
    //        userMenuActive = false;
    //    }
    //    else
    //    {
    //        locomotionMenu.SetActive(false);
    //        locomotionMenuActive = false;
    //        userMenu.SetActive(true);
    //        userMenuActive = true;
    //    }
    //}
    public void onLocomotionPress()
    {
        userMenu.SetActive(false);
        locomotionMenu.SetActive(true);
    }
    public void onLevelSelectPress()
    {
        userMenu.SetActive(false);
        levelMenu.SetActive(true);
    }
    public void onTeleportPress()
    {
        cGOL.locomotionSetting = 0;
        cGOR.locomotionSetting = 0;
        userMenu.SetActive(true);
        locomotionMenu.SetActive(false);
    }
    public void onWorldGrabPress()
    {
        cGOL.locomotionSetting = 4;
        cGOR.locomotionSetting = 4;
        Debug.Log("World Grab Press");
        userMenu.SetActive(true);
        locomotionMenu.SetActive(false);
    }
    public void onBlinkPress()
    {
        cGOL.locomotionSetting = 1;
        cGOR.locomotionSetting = 1;
        userMenu.SetActive(true);
        locomotionMenu.SetActive(false);
    }
    public void onArmSwingPress()
    {
        cGOL.locomotionSetting = 3;
        cGOR.locomotionSetting = 3;
        userMenu.SetActive(true);
        locomotionMenu.SetActive(false);
    }
    public void onSlidePress()
    {
        cGOL.locomotionSetting = 2;
        cGOR.locomotionSetting = 2;
        userMenu.SetActive(true);
        locomotionMenu.SetActive(false);
    }
    public void onLocoExitPress()
    {
        userMenu.SetActive(true);
        locomotionMenu.SetActive(false);
    }
    public void onXRoomPress()
    {
        SceneManager.LoadScene("XRoom");
    }
    public void onObsatclePress()
    {
        SceneManager.LoadScene("ObstacleCourse");
    }
    public void onDemoPress()
    {
        SceneManager.LoadScene("DemoRoom");
    }
    public void onLevelExitPress()
    {
        userMenu.SetActive(true);
        levelMenu.SetActive(false);
    }
}
