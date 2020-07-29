using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenWrapper : MonoBehaviour
{
    float radius;


    // Start is called before the first frame update
    void Start()
    {
        radius = gameObject.GetComponent<CircleCollider2D>().radius;


    }

    void OnBecameInvisible()
    {
        Vector2 position = transform.position;
        if (position.x + radius / 2 > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenLeft + radius / 2;
        }
        else if (position.x - radius / 2 < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenRight - radius / 2;

        }
        if (position.y + radius / 2 > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenBottom + radius / 2;
        }
        else if (position.y - radius / 2 < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenTop - radius / 2;
        }

        transform.position = position;


    }

}
