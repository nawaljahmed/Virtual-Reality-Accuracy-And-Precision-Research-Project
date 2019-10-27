using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLIne : MonoBehaviour
{
    ObstacleCourseSetup OCS;
    private void Start()
    {
        OCS = GetComponentInParent<ObstacleCourseSetup>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            OCS.finishLine = true;
            
        }
    }

}
