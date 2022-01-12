using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{
    public GameObject TaretCrator;
    public GameObject Taret;

    public float TaretCount;

    private bool doo = true;
    private bool Coliders = true;

    void Start ()
    {
        
    }

    void FixedUpdate() {
       Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        TaretCrator.transform.position = new Vector3(worldPosition.x , worldPosition.y , 0);
        if(Input.GetButton("Fire1")){
            StartCoroutine(spawn(worldPosition));
        }
        
    }

  
    IEnumerator spawn(Vector3 a){

        if(TaretCount >= 1 && doo == true && Coliders == true){
                doo = false;
                TaretCount -= 1;
                Instantiate(Taret , a , Quaternion.identity);
                yield return new WaitForSeconds(1f);
                doo = true;
            }
            
    }

    void OnTriggerEnter(Collider other) {
       Debug.Log("çarptım");
    }

    void OnCollisionEnter(Collision other) {
         Debug.Log(other.gameObject.tag);
        Debug.Log("çarptım");
    }
}
