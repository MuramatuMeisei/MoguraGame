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
        //�����ʒu
        positionY = transform.position;

        MoleMove();
    }

    private void Update()
    {
        //���O����Y���̓���
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
        //���O�������̍��W�Ƀ��[�v
        currentPositionIndex = (currentPositionIndex + 1) % positions.Length;
        transform.position = positions[currentPositionIndex];
        positionY = transform.position;
    }
}
