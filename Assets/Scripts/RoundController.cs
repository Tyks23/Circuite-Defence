using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    public GameObject basicEnemy;

    public float timeBetweenWaves = 5f;
    public float timeBeforeRoundStarts;
    private float countdown = 2f;

    public Text WaveCountdown;
    public Text WaveNumber;

    private int waveNumber = 0;

    void Update()
    {
        if( countdown <= 0f){
            StartCoroutine("SpawnWave");
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        WaveCountdown.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave(){
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            Debug.Log("in enumerator" + waveNumber);
            yield return new WaitForSeconds(0.9f);
        }


        WaveNumber.text = waveNumber.ToString();
    }

    void SpawnEnemy(){
        GameObject newEnemy = Instantiate(basicEnemy, MapGenerator.startTile.transform.position, Quaternion.identity);
    }
}