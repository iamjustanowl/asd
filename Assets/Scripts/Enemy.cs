using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
        public float speed = 10f;

        private Transform target;
	private int wavepointIndex = 0;

        public GameObject TaretCreator;

     

       
       

        void Start()
        {

            target = Waypoints.points[0];
        }

        void Update()
        {
            Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
                GetNextWaypoint();
        }

        void GetNextWaypoint()
	{
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        if(wavepointIndex<39)
        {
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
            
            
            
        }if(wavepointIndex == 39){
                Node.Health -= 20;
                Destroy(this.gameObject);
        }
        
        
}


        }
        
    
}
