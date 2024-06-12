using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float amplitude = 1.0f;
    private float positionY;
    private bool hit = false;

    public int pointValue = 10;
    public Text textPoint;
    private int points = 0;

    private void Start()
    {
        UpdatePointsText();
        positionY = transform.position.y;
    }

    private void Update()
    {
        //モグラの動き
        float yOffSet = Mathf.Sin(Time.time * moveSpeed) * amplitude;
        Vector3 newPosition = transform.position;
        newPosition.y = positionY + yOffSet;
        transform.position = newPosition;

         // Targetの物だけ反応
        if (Input.GetMouseButtonDown(0) && !hit) // モグラが叩かれていない場合にのみ反応
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Target"))
                {
                    // モグラを叩いたらスコアを加算し、モグラが引っ込むまで再度叩けないようにする
                    AddPoints(pointValue);
                    hit = true; // モグラが叩かれたことを示すフラグを立てる
                }
            }
        }
    }

    //点数を加算
    private void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsText();
    }
    
    //UIにScoreを表示、UIの数字を更新
    private void UpdatePointsText()
    {
        if(textPoint != null)
        {
            textPoint.text = "Point:" + points;
        }
    }
}
