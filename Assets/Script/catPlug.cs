using System;
using UnityEngine;

public class catPlug : MonoBehaviour
{
    private PlayerMove _PlayerMove;
    private PlayerSound _playerSound;
    private SpriteRenderer _spriteRendererCat, _spriteRendererMan;
    private void Awake()
    {
        _spriteRendererCat = GetComponent<SpriteRenderer>();
        _spriteRendererMan = transform.parent.GetComponent<SpriteRenderer>();
        _PlayerMove = transform.parent.GetComponent<PlayerMove>();
        _playerSound = transform.parent.GetComponent<PlayerSound>();
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

    public void StepPlay()
    {
        _playerSound.PlayStep();
    }

    public void GameOver()
    {
        _PlayerMove.GameOver();
    }
}
