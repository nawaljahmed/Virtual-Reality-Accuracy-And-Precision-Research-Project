using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwing : MonoBehaviour
{
    public SteamVR_TrackedObject trackedObj;

    public Transform cameraRigTransform;

    public Transform headTransform;

    public Transform rightController;

    public Transform leftController;

    public bool left;

    private ControllerGrabObject cgo;

    private Vector3 previousRightTransform;
    private Vector3 previousLeftTransform;

    private bool rightPressed;
    private bool leftPressed;

    private SteamVR_Controller.Device ControllerRight
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private SteamVR_Controller.Device ControllerLeft
    {
        get { return SteamVR_Controller.Input((int)leftController.GetComponent<ArmSwing>().trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        cgo = this.GetComponent<ControllerGrabObject>();
    }

    void Start()
    {
        //previousTransform = rightController.position;
        previousRightTransform = new Vector3(rightController.position.x, rightController.position.y, rightController.position.z);
        previousLeftTransform = new Vector3(rightController.position.x, rightController.position.y, rightController.position.z);
    }
    void Update()
    {
        if (cgo.locomotionSetting == 3 && !left)
        {
            if(ControllerRight.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if (!rightPressed)
                    previousRightTransform = new Vector3(rightController.position.x, rightController.position.y, rightController.position.z);
                rightPressed = true;
            }
            else
            {
                rightPressed = false;
            }
            if (ControllerLeft.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if (!leftPressed)
                    previousLeftTransform = new Vector3(leftController.position.x, leftController.position.y, leftController.position.z);
                leftPressed = true;
            }
            else
            {
                leftPressed = false;
            }

            //Current position *= Distance * Direction
            //where distance = (rightPos - prevRightPos).magnitude and for both, it is added.
            if(rightPressed && leftPressed)
            {
                /* Heading is based on where you're looking. Lets go with where the controller is pointed.
                Vector3 heading = headTransform.forward;
                heading.y = 0;
                heading.Normalize();
                */

                Vector3 heading = (rightController.forward + leftController.forward) / 2;
                heading.y = 0;

                float distance = (rightController.position - previousRightTransform).magnitude + (leftController.position - previousLeftTransform).magnitude;

                cameraRigTransform.position += heading * distance;
                previousRightTransform = new Vector3(rightController.position.x, rightController.position.y, rightController.position.z);
                previousLeftTransform = new Vector3(leftController.position.x, leftController.position.y, leftController.position.z);
            }
            else if(rightPressed)
            {
                Vector3 heading = rightController.forward;
                heading.y = 0;

                float distance = (rightController.position - previousRightTransform).magnitude;

                cameraRigTransform.position += heading * distance;
                previousRightTransform = new Vector3(rightController.position.x, rightController.position.y, rightController.position.z);
            }
            else if(leftPressed)
            {
                Vector3 heading = leftController.forward;
                heading.y = 0;

                float distance = (leftController.position - previousLeftTransform).magnitude;

                cameraRigTransform.position += heading * distance;
                previousLeftTransform = new Vector3(leftController.position.x, leftController.position.y, leftController.position.z);
            }
        }
    }
}
