using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
   public GameObject gameOverUI;

    
    void Update()
    {
        if(Node.Health == 0)
        {
            gameOverUI.SetActive(true);

        }
    }
}
