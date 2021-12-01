using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float enemyHealth;

    [SerializeField]
    private float movementSpeed;

    private int killReward = 20; // The amount of money the player gets when the enemy is killed

    private int damage; // the amount of damage the enemy does when it reaches the end

    private GameObject targetTile;

    private void Awake()
    {
        Enemies.enemies.Add(gameObject);
    }

    private void Start()
    {
        initializeEnemy();
    }

    private void initializeEnemy()
    {
        targetTile = MapGenerator.startTile;
    }

    public void takeDamage(float amount)
    {
        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
            
            die();
        }
    }

    private void die()
    {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
    }

    private void moveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementSpeed * Time.deltaTime);
    }

    private void checkPosition()
    {
        if(targetTile != null && targetTile != MapGenerator.endTile)
        {
            float distance = (transform.position - targetTile.transform.position).magnitude;

            if(distance < 0.001f)
            {
                int currentIndex = MapGenerator.pathTiles.IndexOf(targetTile);

                targetTile = MapGenerator.pathTiles[currentIndex + 1];
            }
        }
    }

    private void Update()
    {
        checkPosition();
        moveEnemy();    
    }
}
