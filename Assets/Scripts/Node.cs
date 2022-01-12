using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject TaretCrator;
    public GameObject Taret;

    public float TaretCount;

    bool Done = true;

    void Start ()
    {
        
    }

    void FixedUpdate() {
       Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        TaretCrator.transform.position = new Vector3(worldPosition.x , worldPosition.y , 10);
        if(Input.GetButton("Fire1")){
            StartCoroutine(spawn());
        }
        
    }

  
    IEnumerator spawn(){

        if(TaretCount >= 1){
                TaretCount -= 1;
                Instantiate(Taret , transform.position , Quaternion.identity);
                yield return new WaitForSeconds(.5f);
            }
    }
}
