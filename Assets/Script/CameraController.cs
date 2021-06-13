using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 targetPosition;
    [SerializeField] private float offsetZ;
    [SerializeField] private float offsetY;
    [SerializeField] private float minFow = 20f;
    [SerializeField] private float normalFow = 30f;
    [SerializeField] private float maxFow = 100f;
    [SerializeField] private float smoothTime = 0.125f;
    private Vector3 smoothedPosition { get; set; }

    private void OnEnable()
    {
        TriggerCam.onTrigger += TargetPosition;
    }

    private void Start()
    {
        offsetZ = maxFow;
        offsetY = 20f;
    }

    private void TargetPosition(bool isTrigger ,string triggerName)
    {
        if (isTrigger && triggerName == "CameraZoom")
        {
            offsetY = 0f;
            offsetZ = minFow;
        }
        else if(isTrigger && triggerName == "CameraDown")
        {
            offsetY = 20f;
            offsetZ = maxFow;
        }
        else if(!isTrigger&& triggerName=="")
        {
            offsetY = 0f;
            offsetZ = normalFow;
        }
    }

    private void FixedUpdate()
    { 
        targetPosition.Set(target.position.x, target.position.y + offsetY, -offsetZ);
        smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothTime);
        transform.position = smoothedPosition;
        Debug.Log(targetPosition);
    }
}
