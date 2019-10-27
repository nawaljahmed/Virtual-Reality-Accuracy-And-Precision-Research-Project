using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGrabObject : MonoBehaviour
{

    public GameObject leftController;

    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;

    private GameObject collidingUI;

    private GameObject lastUITouched;

    private GameObject objectInHand;

    Menu menu;

    public int locomotionSetting = 0;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        menu = leftController.GetComponent<Menu>();
    }

    void Update()
    {  
        //if(collidingUI && collidingUI.tag =="Button")
        //{
        //    collidingUI.GetComponent<Renderer>().material.color = Color.red;
        //    if(Controller.GetHairTriggerDown())
        //    {
        //        if (collidingUI.name == "LocomotionButton")
        //        {
        //            menu.LocomotionMenuToggle();
        //        }
        //        if (collidingUI.name == "TeleportButton")
        //        {
        //            locomotionSetting = 0;
        //            menu.LocomotionMenuToggle();
        //        }
        //        if(collidingUI.name == "BlinkButton")
        //        {
        //            locomotionSetting = 1;
        //            menu.LocomotionMenuToggle();
        //        }
        //        if(collidingUI.name == "SlideButton")
        //        {
        //            locomotionSetting = 2;
        //            menu.LocomotionMenuToggle();
        //        }
        //        if (collidingUI.name == "CAOTSButton")
        //        {
        //            locomotionSetting = 3;
        //            menu.LocomotionMenuToggle();
        //        }
        //        if(collidingUI.name == "GrabWorldButton")
        //        {
        //            locomotionSetting = 4;
        //            menu.LocomotionMenuToggle();
        //        }
        //        if (collidingUI.name == "ExitButton")
        //        {
        //            menu.LocomotionMenuToggle();
        //        }
        //    }
        //}
        if (lastUITouched && lastUITouched.tag == "Button")
        {
            lastUITouched.GetComponent<Renderer>().material.color = Color.blue;
            lastUITouched = null;
        }
        else if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void SetCollidingObject(Collider col)
    {
        if (!(collidingObject || !col.GetComponent<Rigidbody>()))
        {

            collidingObject = col.gameObject;
        }
        else if(col.gameObject.tag == "Button")
        {
            if(collidingUI)
                collidingUI.GetComponent<Renderer>().material.color = Color.blue;
            collidingUI = col.gameObject;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        /*if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
        */
        if(collidingObject)
        {
            collidingObject = null;
        }
        if(collidingUI)
        {
            if (lastUITouched)
                lastUITouched.GetComponent<Renderer>().material.color = Color.blue;
            lastUITouched = collidingUI;
            collidingUI = null;
        }
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        objectInHand = null;
    }
}
