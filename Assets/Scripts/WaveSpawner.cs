using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public GameObject WinLevel;

    public Transform spawnPoint;


    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    public Button NexWaveButton;
    bool d = true;
    
    void Start() {
        Button btn = NexWaveButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);   
    }

    void TaskOnClick(){
		if (d)
        {
            StartCoroutine(SpawnWave());
        }
	}

    void Update(){


       
        if (countdown<=0f){
             

            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
     }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        d = false;
         for(int i = 0; i<waveIndex; i++)  
        {    
             SpawnEnemy();
             yield return new WaitForSeconds(0.5f);
        } 
        yield return new WaitForSeconds(1f);
        d = true;

        if(waveIndex == 5)
        {
            WinLevel.SetActive(true);
             Time.timeScale = 0;
        }

 }

    void SpawnEnemy ()
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}

}
