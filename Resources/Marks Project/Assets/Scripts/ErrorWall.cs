using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorWall : MonoBehaviour
{
    private ObstacleCourseSetup OCS;

    void Start()
    {
        OCS = GetComponentInParent<ObstacleCourseSetup>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("MainCamera"))
        {
            OCS.errors++;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
}
