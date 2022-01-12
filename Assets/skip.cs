using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skip : MonoBehaviour
{
  public GameObject ogretici;
  public GameObject ogretici2;
  

   public void atla()
   {
        ogretici.SetActive(false);
   }
   public void atla2()
   {
       ogretici2.SetActive(true);
   }
   public void atla3()
   {
       ogretici2.SetActive(false);
   }
}
