using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Attributes")]
	public float range=15f;



	
	


    void Start()
    {

    }

 


    void Update()
    {
       
	}

	
	 void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
    
}
