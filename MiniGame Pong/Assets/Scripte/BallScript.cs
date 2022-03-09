using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallScript : MonoBehaviour
{
    [SerializeField] float speed = 30.0f;
    int scoreplayer1 = 0;
    int scoreplayer2 = 0;

    [SerializeField] TextMeshProUGUI TextScorePlayer1;
    [SerializeField] TextMeshProUGUI TextScorePlayer2;

    [SerializeField] GameObject Won;
    [SerializeField] GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreplayer1 == 10)
        {
            Won.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if (scoreplayer2 == 10)
        {
            lose.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
       Debug.Log(collision.gameObject.name);

        if(collision.gameObject.name == "PongPlayer 1") 
        {
            //Aufprall mit Spieler1
            float y = hitObjekt(transform.position, collision.transform.position, collision.collider.bounds.size.y);
           
            //Richtung berechnen
            Vector2 dir = new Vector2(1, y);

            //Richtungsvektor auf der Physik anwenden
            GetComponent<Rigidbody2D>().velocity = dir * speed;


        }

        if (collision.gameObject.name == "PongPlayer 2")
        {
            //Aufprall mit Spieler2
            float y = hitObjekt(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            //Richtung berechnen
            Vector2 dir = new Vector2(-1, y);

            //Richtungsvektor auf der Physik anwenden
            GetComponent<Rigidbody2D>().velocity = dir * speed;

        }

        if(collision.gameObject.name == "WandRechts")
        {
            print("Tor für spieler eins");
            scoreplayer1 = scoreplayer1 + 1;
            TextScorePlayer1.text = scoreplayer1.ToString();

            //neustart
            Restart();

        }

        if(collision.gameObject.name == "WandLinks")
        {
            print("Tor für spieler 2");
            scoreplayer2++;
            TextScorePlayer2.text = scoreplayer2.ToString();

            //neustart
            Restart();
        }


    }

     float hitObjekt(Vector2 ballpos, Vector2 schlägerpos, float schlägerhöhe)
    {
       return (ballpos.y - schlägerpos.y) / schlägerhöhe;
    }


    void Restart()
    {
        //Ball an die anstoßposition beförden
        Vector2 ballPosition = new Vector2(0, 0);
        gameObject.transform.position = ballPosition;
    }
}

