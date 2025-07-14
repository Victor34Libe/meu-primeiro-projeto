using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 3f;
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball");
    }

    void Update()
    {
        if (ball != null)
        {
            float target = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f);
            Vector2 targetPosition = new Vector2(transform.position.x, target);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }

}
