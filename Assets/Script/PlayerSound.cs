using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
   [SerializeField] private AudioClip step, jump, falling;
   [SerializeField] private AudioSource _source;

   public void PlayStep() => _source.PlayOneShot(step);

   public void JumpSound() => _source.PlayOneShot(jump);

   public void FallingSound(bool play)
   {
      switch (play)
      {
         case true:
            _source.clip=falling;
            _source.loop = true;
            _source.Play();
            break;
         case false:
            _source.Stop();
            _source.loop = false;
            _source.clip=null;
            break;
      }
   }
}
