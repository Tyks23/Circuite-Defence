using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public GameObject basicEnemy;

    public float timeBetweenWaves;
    public float timeBeforeRoundStarts;
    public float timeVariable;

    public bool isRoundGoing;
    public bool isIntermission;
    public bool isStartOfRound;

    public int round;

    private void Start()
    {
        isRoundGoing = false;
        isIntermission = false;
        isStartOfRound = true;

        timeVariable = Time.time + timeBeforeRoundStarts;

        round = 1;
    }

    private void SpawnEnemies()
    {
        GameObject newEnemy = Instantiate(basicEnemy, MapGenerator.startTile.transform.position, Quaternion.identity);
        StartCoroutine("ISpawnEnemies");
    }

    IEnumerator ISpawnEnemies()
    {
        for (int i = 0; i < round; i++)
        {
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        if (isStartOfRound)
        {
            if (Time.time >= timeVariable)
            {
                isStartOfRound = false;
                isRoundGoing = true;
                SpawnEnemies();
                
                return;
            }
        }
        else if (isIntermission)
        {
            if (Time.time >= timeVariable)
            {
                isIntermission = false;
                isRoundGoing = true;

                SpawnEnemies();
            }
        }
        else if (isRoundGoing)
        {
            if(Enemies.enemies.Count > 0)
            {

            }
            else
            {
                isIntermission = true;
                isRoundGoing = false;

                timeVariable = Time.time + timeBetweenWaves;
                round++;
            }
        }
    }
}
