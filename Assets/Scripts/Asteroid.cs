using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Asteroids.
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite asteroid1;

    [SerializeField]
    Sprite asteroid2;

    [SerializeField]
    Sprite asteroid3;

    Rigidbody2D rbd;
    SpriteRenderer sprite;

    float radius;
   

    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        //Random sprite generation
        int spriteNumber = Random.Range(0, 3);

        if (spriteNumber == 0)
        {
            GetComponent<SpriteRenderer>().sprite = asteroid1;
        }
        else if (spriteNumber == 1)
        {
            GetComponent<SpriteRenderer>().sprite = asteroid2;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = asteroid3;
        }



    }

    public void Initialize(Direction direction, Vector3 position)
    {
        transform.position = new Vector3(position.x, position.y, 0f);
        float angle = 0;

        
        if (direction == Direction.Up)
        {
            angle = Random.Range(75 * Mathf.Deg2Rad, 105 * Mathf.Deg2Rad);
            StartMoving(angle);
        }

        if (direction == Direction.Down)
        {
            angle = Random.Range(255 * Mathf.Deg2Rad, 285 * Mathf.Deg2Rad);
            StartMoving(angle);
        }

        if (direction == Direction.Left)
        {
            angle = Random.Range(165 * Mathf.Deg2Rad, 195 * Mathf.Deg2Rad);
            StartMoving(angle);

        }

        if (direction == Direction.Right)
        {
            angle = Random.Range(-15 * Mathf.Deg2Rad, 15 * Mathf.Deg2Rad);
            StartMoving(angle);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);   
            Vector3 scale = transform.localScale;
            scale.x /= 2;
            scale.y /= 2;
            transform.localScale = scale;

            radius = gameObject.GetComponent<CircleCollider2D>().radius;
            radius = radius / 2;

            

            Destroy(coll.gameObject);

            if (transform.localScale.x < 0.5)
            {
                Destroy(gameObject);
            }
            else
            {
                GameObject asteroid1 = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
                asteroid1.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2f) * Mathf.PI);
                GameObject asteroid2 = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
                asteroid2.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2f) * Mathf.PI);
            }

            Destroy(gameObject);

            

        }

    }

    public void StartMoving(float angle)
    {
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;

        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }


}