using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStep : MonoBehaviour
{
    [SerializeField] private CrystalCollectionSystem _crystalCollectionSystem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            other.GetComponent<PlayerMove>().enabled = false;
            _crystalCollectionSystem.ShowCrystal(2);
        }
    }
}
