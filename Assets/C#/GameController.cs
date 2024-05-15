using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float targetSpeed = 5.0f;
    public float maxAmplitude = 3.0f;
    public float lowestAmplitude = -3.0f;
    public int point = 0;
    public Text score;

    private void Start()
    {
        score.text = "Score:" + point;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ScorePoint();
        }

        score.text = "Score:" + point;
    }

    void ScorePoint()
    {
        if(gameObject.CompareTag("Target"))
        {
            point += 1;
        }
    }
}
