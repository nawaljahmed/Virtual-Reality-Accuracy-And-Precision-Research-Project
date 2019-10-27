using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform nodeA;
    public Transform nodeB;
    public Transform nodeC;
    public Transform nodeD;
    public int moveSpeed;
    public int rotationSpeed;
    Transform myTransform;
    public int patrolNode = 1;
    Rigidbody rBody;
    Vector3 velocity = Vector3.zero;
    Vector3 posOffset = new Vector3();
    float minDistance = .01f;
    void Start ()
    {
        myTransform = transform;
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("The Character needs a rigidbody.");
        }
    }
	void FixedUpdate ()
    {
        rBody.velocity = transform.TransformDirection(velocity);
        Patrol();
    }
    void Patrol()
    {
        float step = moveSpeed * Time.deltaTime;
        if (patrolNode == 1)
        {
            //posOffset.Set(nodeA.position.x, myTransform.position.y, nodeA.position.z);
            transform.position = Vector3.MoveTowards(transform.position, nodeA.position, step);
            Debug.DrawLine(nodeA.position, myTransform.position, Color.red);
            if (Vector3.Distance(nodeA.position, myTransform.position) < minDistance)
            {
                patrolNode = 2;
            }
        }
        else if (patrolNode == 2)
        {
            //posOffset.Set(nodeB.position.x, myTransform.position.y, nodeB.position.z);
            transform.position = Vector3.MoveTowards(transform.position, nodeB.position, step);
            Debug.DrawLine(nodeB.position, myTransform.position, Color.red);
            if (Vector3.Distance(nodeB.position, myTransform.position) < minDistance)
            {
                patrolNode = 3;
            }
        }
        else if (patrolNode == 3)
        {
            //posOffset.Set(nodeC.position.x, myTransform.position.y, nodeC.position.z);
            transform.position = Vector3.MoveTowards(transform.position, nodeC.position, step);
            Debug.DrawLine(nodeC.position, myTransform.position, Color.red);
            if (Vector3.Distance(nodeC.position, myTransform.position) < minDistance)
            {
                patrolNode = 4;
            }
        }
        else if (patrolNode == 4)
        {
            //posOffset.Set(nodeD.position.x, myTransform.position.y, nodeD.position.z);
            transform.position = Vector3.MoveTowards(transform.position, nodeD.position, step);
            Debug.DrawLine(nodeD.position, myTransform.position, Color.red);
            if (Vector3.Distance(nodeD.position, myTransform.position) < minDistance)
            {
                patrolNode = 1;
            }
        }
        //myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(posOffset - myTransform.position), rotationSpeed * Time.deltaTime);
        //velocity.z = moveSpeed;
    }
}
