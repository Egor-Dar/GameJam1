using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            other.GetComponent<PlayerMove>().Die();
        }
    }
}
