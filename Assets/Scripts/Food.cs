using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D gameArea;

    void Start()
    {
        RandomizeFoodPosition();
    }


    void RandomizeFoodPosition()
    {
        Bounds bounds = gameArea.bounds;
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));


        transform.position = new Vector2(x, y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            RandomizeFoodPosition();
        }
    }

}
