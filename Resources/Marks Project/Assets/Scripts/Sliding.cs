using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;

    public Transform cameraRigTransform;

    public Transform headTransform;

    private ControllerGrabObject cgo;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        cgo = this.GetComponent<ControllerGrabObject>();
    }
    void Update()
    {
        if (cgo.locomotionSetting == 2)
        {
            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Vector3 axis = this.transform.forward;
                axis.Normalize();
                axis.y = 0;
                //Vector3 difference = cameraRigTransform.position - headTransform.position;
                //difference.y = 0;
                cameraRigTransform.position += axis / 10;
            }
        }
    }
}
