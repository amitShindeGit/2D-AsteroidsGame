using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// HUD commands.
/// </summary>
public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    float elapsedTime = 0;
    bool running = true;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = 0.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedTime += Time.deltaTime;
            scoreText.text = "Score : " + elapsedTime.ToString();
        }
    }

    public void StopGameTimer()
    {
        running = false;
    }

}
