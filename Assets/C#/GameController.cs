using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int points = 0;

    public int pointValue = 10;
    public Text textPoint;

    private void Start()
    {
        UpdatePointsText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Target"))
                {
                    AddPoints(pointValue);
                }
            }
        }
    }

    private void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        if(textPoint != null)
        {
            textPoint.text = "Point:" + points;
        }
    }
}
