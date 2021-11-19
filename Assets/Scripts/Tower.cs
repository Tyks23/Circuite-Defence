using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

   [SerializeField] private float range;
   [SerializeField] private float damage;
   [SerializeField] private float timeBetweenShots;
   public GameObject currentTarget;


    private float nextTimeToShoot;
    // Start is called before the first frame update
    private void Start()
    {
        nextTimeToShoot = Time.time;
    }

    private void updateNearestEnemy()
    {
        GameObject currentNearestEnemy = null;

        float distance = Mathf.Infinity;

        foreach (GameObject enemy in Enemies.enemies)
        {
            float _distance = (transform.position + enemy.transform.position).magnitude;

            if(_distance < distance)
            {
                distance = _distance;
                currentNearestEnemy = enemy;
            }
            else
            {
                currentTarget = null;
            }
        }

        if(distance <= range)
        {
            currentTarget = currentNearestEnemy;
        }
    }

    protected virtual void shoot()
    {
        if(currentTarget != null)
        {
            Enemy enemyScript = currentTarget.GetComponent<Enemy>();

            enemyScript.takeDamage(damage);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        updateNearestEnemy();

        if(Time.time >= nextTimeToShoot)
        {
            if(currentTarget != null)
            {
                shoot();
                nextTimeToShoot = Time.time + timeBetweenShots;
            }
        }
    }
}
