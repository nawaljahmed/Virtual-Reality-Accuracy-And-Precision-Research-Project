using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTouser : MonoBehaviour
{
	void Update ()
    {
        transform.LookAt(Camera.main.transform);
	}
}
