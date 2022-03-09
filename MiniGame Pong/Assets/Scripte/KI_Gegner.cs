using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KI_Gegner : MonoBehaviour
{
    [SerializeField] Transform ball;
    float ballPositionY;
    public float speed;

    [SerializeField] Transform KiGegener;
    [SerializeField] Rigidbody2D KiGegenerRB;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("ball").transform;
        KiGegener = gameObject.transform;
        KiGegenerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ballPositionY = ball.position.y;

        if(ballPositionY > KiGegener.position.y + 0.2)
        {
            KiGegenerRB.velocity = new Vector2(0, speed);
        }
        else if(ballPositionY< KiGegener.position.y - 0.2)
        {
            KiGegenerRB.velocity = new Vector2(0, -speed);
        }
        else
        {
            KiGegenerRB.velocity = new Vector2(0, 0);
        }
    }
}
