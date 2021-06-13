using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System;

public class TriggerCam : MonoBehaviour
{
    public static Action<bool ,string> onTrigger;
    private bool isTrigger;
    private string isTriggerName;
    private string TagCol;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CameraZoom"))
        {
            isTrigger = true;
            if (onTrigger != null)
                TagCol = collision.tag;
                onTrigger(isTrigger ,TagCol);
        }

        if (collision.CompareTag("CameraDown"))
        {
            isTrigger = true;
            if (onTrigger != null)
                TagCol = collision.tag;
                onTrigger(isTrigger ,TagCol);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CameraZoom"))
        {
            isTrigger = false;
            if (onTrigger != null)
                TagCol = collision.tag;
                onTrigger(isTrigger, TagCol);
        }

        if (collision.CompareTag("CameraDown"))
        {
            isTrigger = false;
            if (onTrigger != null)
                TagCol = collision.tag;
                onTrigger(isTrigger, TagCol);
        }
        else
        {
            TagCol = "";
        }
    }
    private void Update()
    {
        onTrigger(isTrigger, TagCol);
    }
}
