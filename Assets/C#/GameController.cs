using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float clickCoolTime = 1f;
    private float lastClickTime = 0f;
    private bool hit = false;

    public int pointValue = 10;
    public Text textPoint;
    private int points = 0;

    private void Start()
    {
        UpdatePointsText();
    }

    private void Update()
    {
        if (Time.time - lastClickTime < clickCoolTime)
        {
            return;
        }

        hit = false;

        // Target�̕���������
        if (Input.GetMouseButtonDown(0) && !hit)
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Target"))
                {
                    AddPoints(pointValue);
                    hit = true;
                    lastClickTime = Time.time;
                }
            }
        }
    }

    // �_�������Z���郁�\�b�h
    private void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsText();
    }

    // UI�ɃX�R�A��\�����郁�\�b�h
    private void UpdatePointsText()
    {
        if (textPoint != null)
        {
            textPoint.text = "Point: " + points;
        }
    }
}
