using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]private float speed;

    private void Start()
    {
        Destroy(gameObject, 1.8f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Impact");
    }

    private void Update()
    {
        transform.position += transform.right * speed;
    }
}
