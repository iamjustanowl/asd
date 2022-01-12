using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }
    public void YenidenDene()
    {
        SceneManager.LoadScene(2);
        Node.Health = 100; 
    }
}
