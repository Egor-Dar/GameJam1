using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerAxe : MonoBehaviour
{
   private bool IsForceRight;
   [SerializeField] private float force;
   
   public void ForceRight()
   {
      IsForceRight=true;
   }
   public void ForceLeft()
   {
      IsForceRight=false;
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.GetComponent<PlayerMove>())
      {
         other.gameObject.GetComponent<Rigidbody2D>().velocity =
            IsForceRight ? Vector2.right * force : Vector2.left * force;
         other.gameObject.GetComponent<PlayerMove>().Die();  
      }
   }
}
