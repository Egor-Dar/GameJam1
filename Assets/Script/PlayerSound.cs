using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
   [SerializeField] private AudioClip step, jump, falling;
   [SerializeField] private AudioSource _source;

   public void PlayStep()
   {
      _source.PlayOneShot(step);
      Debug.Log("step");
   }

   public void JumpSound()
   {
      _source.PlayOneShot(jump);
      Debug.Log("jump");
   }

   public void FallingSound(bool play)
   {
      switch (play)
      {
         case true:
            _source.Play(0);
            break;
         case false:
            
            break;
      }
   }
}
