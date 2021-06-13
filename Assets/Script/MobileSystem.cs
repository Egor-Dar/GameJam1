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
    [SerializeField] private float LifeTime;

    public float[] lifeTimeStick;
    private Vector3 _posStandart, _posOld;
    private bool IsGrab = false;
    private float timer = 0;
    
    private void Awake()
    {
        _posStandart = transform.localPosition;
        receiveLifeTimeStick();
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
        if(LifeTime>lifeTimeStick[1])
            shovStickPower(8);
        else if(LifeTime<lifeTimeStick[1] && LifeTime>=lifeTimeStick[2])
            shovStickPower(7);
        else if(LifeTime<lifeTimeStick[2] && LifeTime>=lifeTimeStick[3])
            shovStickPower(6);
        else if(LifeTime<lifeTimeStick[3] && LifeTime>=lifeTimeStick[4])
            shovStickPower(5);
        else if(LifeTime<lifeTimeStick[4] && LifeTime>=lifeTimeStick[5])
            shovStickPower(4);
        else if(LifeTime<lifeTimeStick[5] && LifeTime>=lifeTimeStick[6])
            shovStickPower(3);
        else if(LifeTime<lifeTimeStick[6] && LifeTime>=lifeTimeStick[7])
            shovStickPower(2);
        else if(LifeTime<lifeTimeStick[7] && LifeTime>=0)
            shovStickPower(1);
        else
        {
            shovStickPower(0);
            //mobile don`t work
        }

        #endregion

        if(IsGrab)
            LifeTime -= Time.deltaTime;
    }

    private void shovStickPower(int sticks)
    {
        switch (sticks)
        {
            case 8:
                batteryIndicator[0].enabled = false;
                batteryIndicator[1].enabled = false;
                batteryIndicator[2].enabled = false;
                batteryIndicator[3].enabled = false;
                batteryIndicator[4].enabled = false;
                batteryIndicator[5].enabled = false;
                batteryIndicator[6].enabled = false;
                batteryIndicator[7].enabled = true;
                break;
            case 7:
                batteryIndicator[0].enabled = false;
                batteryIndicator[1].enabled = false;
                batteryIndicator[2].enabled = false;
                batteryIndicator[3].enabled = false;
                batteryIndicator[4].enabled = false;
                batteryIndicator[5].enabled = false;
                batteryIndicator[6].enabled = true;
                batteryIndicator[7].enabled = false;
                break;
            case 6:
                batteryIndicator[0].enabled = false;
                batteryIndicator[1].enabled = false;
                batteryIndicator[2].enabled = false;
                batteryIndicator[3].enabled = false;
                batteryIndicator[4].enabled = false;
                batteryIndicator[5].enabled = true;
                batteryIndicator[6].enabled = false;
                batteryIndicator[7].enabled = false;
                break;
            case 5:
                batteryIndicator[0].enabled = false;
                batteryIndicator[1].enabled = false;
                batteryIndicator[2].enabled = false;
                batteryIndicator[3].enabled = false;
                batteryIndicator[4].enabled = true;
                batteryIndicator[5].enabled = false;
                batteryIndicator[6].enabled = false;
                batteryIndicator[7].enabled = false;
                break;
            case 4:
                batteryIndicator[0].enabled = false;
                batteryIndicator[1].enabled = false;
                batteryIndicator[2].enabled = false;
                batteryIndicator[3].enabled = true;
                batteryIndicator[4].enabled = false;
                batteryIndicator[5].enabled = false;
                batteryIndicator[6].enabled = false;
                batteryIndicator[7].enabled = false;
                break;
            case 3:
                batteryIndicator[0].enabled = false;
                batteryIndicator[1].enabled = false;
                batteryIndicator[2].enabled = true;
                batteryIndicator[3].enabled = false;
                batteryIndicator[4].enabled = false;
                batteryIndicator[5].enabled = false;
                batteryIndicator[6].enabled = false;
                batteryIndicator[7].enabled = false;
                break;
            case 2:
                batteryIndicator[0].enabled = false;
                batteryIndicator[1].enabled = true;
                batteryIndicator[2].enabled = false;
                batteryIndicator[3].enabled = false;
                batteryIndicator[4].enabled = false;
                batteryIndicator[5].enabled = false;
                batteryIndicator[6].enabled = false;
                batteryIndicator[7].enabled = false;
                break;
            case 1:
                batteryIndicator[0].enabled = true;
                batteryIndicator[1].enabled = false;
                batteryIndicator[2].enabled = false;
                batteryIndicator[3].enabled = false;
                batteryIndicator[4].enabled = false;
                batteryIndicator[5].enabled = false;
                batteryIndicator[6].enabled = false;
                batteryIndicator[7].enabled = false;
                break;
            case 0:
                batteryIndicator[0].enabled = false;
                batteryIndicator[1].enabled = false;
                batteryIndicator[2].enabled = false;
                batteryIndicator[3].enabled = false;
                batteryIndicator[4].enabled = false;
                batteryIndicator[5].enabled = false;
                batteryIndicator[6].enabled = false;
                batteryIndicator[7].enabled = false;
                break;
        }
    }

    private void receiveLifeTimeStick()
    {
        float allLifeTime = LifeTime;
        float lifetimeStick = LifeTime / lifeTimeStick.Length;
        for (int i = 0; i < lifeTimeStick.Length; i++)
        {
            lifeTimeStick[i] = allLifeTime;
            allLifeTime -= lifetimeStick;
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
