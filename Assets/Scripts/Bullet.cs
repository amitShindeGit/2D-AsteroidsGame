using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bullet movements.
/// </summary>
public class Bullet : MonoBehaviour
{
    const float alive_Time = 2f;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = alive_Time;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    public void ApplyForce(Vector2 direction)
    {
        const int force = 10;
        GetComponent<Rigidbody2D>().AddForce(force * direction, ForceMode2D.Impulse);

    }
}
