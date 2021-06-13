using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMove>())
        {
            other.gameObject.GetComponent<TriggerCam>().Crystal++;
            Destroy(this.gameObject);
        }
    }
}
