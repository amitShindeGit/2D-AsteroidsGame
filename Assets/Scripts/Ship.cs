using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Applying Thrust to the ship.
/// </summary>
public class Ship : MonoBehaviour
{
    Rigidbody2D rb;
    const float ThrustForce = 2;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float RotateDegreesPerSecond = 20;

    [SerializeField]
    GameObject prefabBullet;

    [SerializeField]
    HUD hud;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
       // radius = gameObject.GetComponent<CircleCollider2D>().radius;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Rotate") != 0)
        {
            float rotationInput = Input.GetAxis("Rotate");
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;

            if (rotationInput < 0)
            {

                rotationAmount *= -1; 
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            //move in specific direction after rotating

            float newThrustDirection = Mathf.Deg2Rad * (transform.eulerAngles.z);
            thrustDirection.x = Mathf.Cos(newThrustDirection);
            thrustDirection.y = Mathf.Sin(newThrustDirection);
         
        }

        

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            AudioManager.Play(AudioClipName.PlayerShot);
            GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
        }



    }

    

    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") != 0)
        {
            rb.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
        }
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            hud.StopGameTimer();
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(gameObject);
        }
    }

}
