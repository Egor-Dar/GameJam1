using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum buttonType
{
    Play,
    Authors,
    backToMenu,
    Exit
}

public class Selected : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject Authors;
    public buttonType _ButtonType;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.alignment = TextAnchor.MiddleRight;
        _text.fontStyle = FontStyle.Bold;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.alignment = TextAnchor.MiddleLeft;
        _text.fontStyle = FontStyle.Normal;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (_ButtonType)
        {
            case buttonType.Play:
                SceneManager.LoadScene("Play");
                break;
            case buttonType.Authors:
                Authors.SetActive(true);
                break;
            case buttonType.backToMenu:
                Authors.SetActive(false);
                break;
            case buttonType.Exit:
                Application.Quit();
                break;
        }
    }
}
