using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
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
        if (cgo.locomotionSetting == 1)
        {
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Vector3 axis = this.transform.forward;
                axis.Normalize();
                axis.y = 0;
                Debug.Log(axis);
                Vector3 difference = cameraRigTransform.position - headTransform.position;
                difference.y = 0;
                cameraRigTransform.position += axis;
            }
        }
    }
}
