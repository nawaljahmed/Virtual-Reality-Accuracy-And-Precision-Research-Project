using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRoomSetup : MonoBehaviour
{
    public GameObject consoleFab;
    public GameObject leftController;
    public GameObject cameraRig;

    ConsoleBehavior CB;

    int consolePosX;
    int consolePosZ;

    int userX;
    int userZ;

	void Start ()
    {
        GenerateConsolePostion();
        cameraRig.transform.position = new Vector3(userX, 0, userZ);
        

        GameObject go = Instantiate(consoleFab, new Vector3(consolePosX,0,consolePosZ), Quaternion.identity);
        CB = go.GetComponentInChildren<ConsoleBehavior>();
        CB.controllerLeft = leftController;
        CB.consoleX = consolePosX;
        CB.consoleZ = consolePosZ;
        CB.userX = userX;
        CB.userZ = userZ;
        CB.cameraRig = cameraRig;

    }
    void GenerateConsolePostion()
    {
        System.Random rnd = new System.Random();
        consolePosX = rnd.Next(-4, 4);
        consolePosZ = rnd.Next(-4, 4);

        do
        {
            userX = rnd.Next(-4, 4);
            userZ = rnd.Next(-4, 4);
        }
        while (userX != consolePosX && userZ != consolePosZ);
    }
}
