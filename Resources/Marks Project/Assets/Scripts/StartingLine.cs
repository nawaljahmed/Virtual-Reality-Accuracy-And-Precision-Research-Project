using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLine : MonoBehaviour
{
    ObstacleCourseSetup OCS;
    private void Start()
    {
        OCS = GetComponentInParent<ObstacleCourseSetup>();
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            OCS.startLine = false;
        }
    }

}
