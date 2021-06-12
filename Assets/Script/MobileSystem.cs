using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MobileSystem : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image[] batteryIndicator = new Image[8];
    [SerializeField] private int LifeTime;

    private int stikActive;
    private float lifeTimeStick;
    private Vector3 _posStandart, _posOld;
    private bool IsGrab = false;
    private float timer = 0;
    
    private void Awake()
    {
        _posStandart = transform.localPosition;
        stikActive = batteryIndicator.Length;
        lifeTimeStick = LifeTime / batteryIndicator.Length;
    }

    private void Update()
    {
        #region come Back
        if (!IsGrab)
        {
            if (timer > 0)
                timer -= Time.deltaTime*3;
            transform.localPosition = Vector3.Lerp(_posStandart, _posOld, timer);
        }
        #endregion

        #region Show Power
        
        #endregion
    }

    private void showStickPower(int sticks)
    {
        for (int i = 0; i < batteryIndicator.Length; i++)
        {
            if (i == sticks - 1)
                batteryIndicator[i].enabled = true;
            else
                batteryIndicator[i].enabled = false;
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        IsGrab = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.pointerCurrentRaycast.worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _posOld = transform.localPosition;
        timer = 1;
        IsGrab = false;
    }
}
