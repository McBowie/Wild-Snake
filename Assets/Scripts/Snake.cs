using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Snake : MonoBehaviour
{
    [SerializeField] float velocity = 100.0f;

    Vector2 direction = Vector2.zero;
    List<Transform> segments = new List<Transform>();

    [SerializeField] Transform segmentPrefab;
    [SerializeField] UserInterface userInterface;
    [SerializeField] AudioSource audioSource;
    [SerializeField] CameraPulse cameraPulse;
   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Movement), 0.0f, 1 / velocity);
        InvokeRepeating(nameof(UpdatePosition), 0.0f, 1 / velocity);
        segments.Add(transform);
        
    }


    void Movement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if (inputX > 0 && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
        else if (inputX < 0 && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        else if (inputY > 0 && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if (inputY < 0 && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Body"))
        {
            GameOver();
            Debug.Log("Wall");
            /*direction = new Vector2(-Mathf.Sign(transform.position.x) * Mathf.Abs(direction.y), -Mathf.Sign(transform.position.y) * Mathf.Abs(direction.x));*/

        }
        else if (collision.CompareTag("Food"))
        {
            audioSource.Play();
            Grow();
            cameraPulse.shakeDuration = 0.5f;
        }
    }

    void GameOver()
    {
        CancelInvoke(nameof(UpdatePosition));
        userInterface.OnGameOver();
    }

    void Grow()
    {
        Vector3 newSegmentPos = transform.position;

        if(direction == Vector2.right)
        {
            newSegmentPos += Vector3.left;
        }
        else if (direction == Vector2.up)
        {
            newSegmentPos += Vector3.down;
        }
        else if (direction == Vector2.down)
        {
            newSegmentPos += Vector3.up;
        }
        else if (direction == Vector2.left)
        {
            newSegmentPos += Vector3.right;
        }

        Transform newSegment = Instantiate(segmentPrefab, newSegmentPos, Quaternion.identity);
        segments.Insert(1, newSegment) ;
        userInterface.IncreaseScore((segments.Count - 1) * 10);
        newSegment.name = segments.Count.ToString();
    }

    void UpdatePosition()
    {
        Vector3 currPos = transform.position;
        Vector3 newPos = new Vector3(currPos.x + direction.x, currPos.y + direction.y, 0);
        
        transform.position = newPos;

        if (segments.Count <= 1)
            return;

        Transform lastSegment = segments[segments.Count - 1];
        lastSegment.position = currPos;

        segments.Insert(1, lastSegment);
        segments.RemoveAt(segments.Count-1);

    }

}