using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    public GameObject laserPrefab;   
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;
    public Transform cameraRigTransform;   
    public GameObject teleportReticlePrefab;   
    private GameObject reticle;  
    private Transform teleportReticleTransform;   
    public Transform headTransform;   
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;    
    private bool shouldTeleport;
    private bool errorTeleport;
    public GameObject Course;

    private ControllerGrabObject cgo;
    private ObstacleCourseSetup OBS;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        cgo = this.GetComponent<ControllerGrabObject>();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "ObstacleCourse")
        {
            OBS = Course.GetComponent<ObstacleCourseSetup>();
        }
    }

    void Start ()
    {
        laser = Instantiate(laserPrefab);
        reticle = Instantiate(teleportReticlePrefab);
        laserTransform = laser.transform;
        teleportReticleTransform = reticle.transform;
    }
	
	void Update ()
    {
        //Debug.DrawRay(trackedObj.transform.position, transform.forward, Color.red, 100);
        if(cgo.locomotionSetting==0)
        {
            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                RaycastHit hit;

                if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 20, teleportMask))
                {
                    if(hit.transform.gameObject.layer == 8)
                    {
                        shouldTeleport = true;
                        errorTeleport = false;
                    }
                    else if(hit.transform.gameObject.layer == 9)
                    {
                        errorTeleport = true;
                        shouldTeleport = false;
                    }
                    hitPoint = hit.point;

                    ShowLaser(hit);

                    reticle.SetActive(true);

                    teleportReticleTransform.position = hitPoint + teleportReticleOffset;

                    //shouldTeleport = true;
                }
            }
            else
            {
                laser.SetActive(false);

                reticle.SetActive(false);
            }
            if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && shouldTeleport)
            {
                Teleport();
                
            }
            else if(Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && errorTeleport)
            {
                Debug.Log("ERROR TELEPORT!!!!!!!!!!");
                OBS.errors++;
            }

        }
        
    }

    private void Teleport()
    {
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = hitPoint + difference;
    }

    private void ShowLaser(RaycastHit hit)
    {

        laser.SetActive(true);

        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);

        laserTransform.LookAt(hitPoint);

        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }
}
