using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieManager : MonoBehaviour
{
    [SerializeField] private GameObject dieCanvas;
    private static GameObject _dieCanvas;

    private void Awake()
    {
        _dieCanvas = dieCanvas;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Play");
    }

    public static void Die()
    {
        Time.timeScale = 0;
        _dieCanvas.SetActive(true);
    }
}
