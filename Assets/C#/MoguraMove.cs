using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float maxHeight = 1f;
    private Vector3 positionY;

    public Vector3[] positions;
    private int currentPositionIndex = 0;

    private void Start()
    {
        //初期位置
        positionY = transform.position;

        MoleMove();
    }

    private void Update()
    {
        //モグラのY軸の動き
        float currentY = transform.position.y;

        if(currentY < positionY.y + maxHeight)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }

        else
        {
            MoleMove();
        }
    }

    void MoleMove()
    {
        //モグラを特定の座標にワープ
        currentPositionIndex = (currentPositionIndex + 1) % positions.Length;
        transform.position = positions[currentPositionIndex];
        positionY = transform.position;
    }
}
