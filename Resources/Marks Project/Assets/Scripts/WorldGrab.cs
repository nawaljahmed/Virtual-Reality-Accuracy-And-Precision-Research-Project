using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrab : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;

    public Transform cameraRigTransform;

    public Transform headTransform;

    public Transform rightController;

    private ControllerGrabObject cgo;

    private bool grabbed;

    private Vector3 previousTransform;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        cgo = this.GetComponent<ControllerGrabObject>();
    }

    void Start()
    {
        //previousTransform = rightController.position;
        previousTransform = new Vector3(rightController.position.x, rightController.position.y, rightController.position.z);
    }
    void Update()
    {
        if (cgo.locomotionSetting == 4)
        {
            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Grip) || Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if (!grabbed)
                    previousTransform = new Vector3(rightController.position.x, rightController.position.y, rightController.position.z);
                grabbed = true;
            }
            else
            {
                grabbed = false;
            }

            if (grabbed)
            {
                if(rightController.position.x != previousTransform.x && rightController.position.z != previousTransform.z)
                {
                    Vector3 difference = previousTransform - rightController.position ;
                    difference.y = 0;
                    difference *= 5f;
                    cameraRigTransform.position = cameraRigTransform.position + difference;
                    //previousTransform = rightController.position;
                    previousTransform = new Vector3(rightController.position.x, rightController.position.y, rightController.position.z);
                }
            }
        }
    }
}
