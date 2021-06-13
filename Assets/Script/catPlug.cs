using System;
using UnityEngine;

public class catPlug : MonoBehaviour
{
    private PlayerMove _PlayerMove;
    private SpriteRenderer _spriteRendererCat, _spriteRendererMan;
    private void Awake()
    {
        _spriteRendererCat = GetComponent<SpriteRenderer>();
        _spriteRendererMan = transform.parent.GetComponent<SpriteRenderer>();
        _PlayerMove = transform.parent.GetComponent<PlayerMove>();
    }

    private void Update()
    {
        _spriteRendererCat.flipX = _spriteRendererMan.flipX;
    }

    public void ReturnMan()
    {
        GetComponent<Animator>().SetBool("jump",false);
        _PlayerMove.SwitchCat(false);
    }
}
