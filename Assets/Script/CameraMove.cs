using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraMove : MonoBehaviour
{
    public Transform Player;
    [SerializeField] private Vector3 shiftCam;
    
    private void Update()
    {
        transform.position = new Vector3(Player.position.x + shiftCam.x * (Player.GetComponent<SpriteRenderer>().flipX? -1:1), Player.position.y + shiftCam.y, shiftCam.z);
    }
}
