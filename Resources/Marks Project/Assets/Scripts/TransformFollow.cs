using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFollow : MonoBehaviour
{
    public GameObject gameObjectToFollow;
    public GameObject gameObjectToChange;
    public float maxAllowedPerFrameDistanceDifference;
    public float maxAllowedPerFrameAngleDifference;
    Transform transformToFollow;
    Transform transformToChange;

    void Start()
    {

    }
    void Update()
    {
        CacheTransforms();
        Follow();
    }
    void Follow()
    {
        if (gameObjectToFollow == null)
        {
            return;
        }
        FollowPosition();
        FollowRotation();
    }

    Vector3 targetPosition { get; set; }
    Quaternion targetRotation { get; set; }

    void FollowPosition()
    {
        var positionToFollow = GetPositionToFollow();
        Vector3 newPosition;

        var alpha = Mathf.Clamp01(Vector3.Distance(targetPosition, positionToFollow) / maxAllowedPerFrameDistanceDifference);
        newPosition = Vector3.Lerp(targetPosition, positionToFollow, alpha);

        targetPosition = newPosition;
        SetPositionOnGameObject(newPosition);
    }
    void FollowRotation()
    {
        var rotationToFollow = GetRotationToFollow();
        Quaternion newRotation;

        var alpha = Mathf.Clamp01(Quaternion.Angle(targetRotation, rotationToFollow) / maxAllowedPerFrameAngleDifference);
        newRotation = Quaternion.Lerp(targetRotation, rotationToFollow, alpha);

        targetRotation = newRotation;
        SetRotationOnGameObject(newRotation);
    }
    Vector3 GetPositionToFollow()
    {
        return transformToFollow.position;
    }
    void SetPositionOnGameObject(Vector3 newPosition)
    {
        transformToChange.position = newPosition;
    }
    Quaternion GetRotationToFollow()
    {
        return transformToFollow.rotation;
    }
    void SetRotationOnGameObject(Quaternion newRotation)
    {
        transformToChange.rotation = newRotation;
    }
    void CacheTransforms()
    {
        if (gameObjectToFollow == null || gameObjectToChange == null
            || (transformToFollow != null && transformToChange != null))
        {
            return;
        }

        transformToFollow = gameObjectToFollow.transform;
        transformToChange = gameObjectToChange.transform;
    }
}
