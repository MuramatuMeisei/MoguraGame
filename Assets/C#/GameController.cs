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
        //���O���̓���
        float yOffSet = Mathf.Sin(Time.time * moveSpeed) * amplitude;
        Vector3 newPosition = transform.position;
        newPosition.y = positionY + yOffSet;
        transform.position = newPosition;

         // Target�̕���������
        if (Input.GetMouseButtonDown(0) && !hit) // ���O�����@����Ă��Ȃ��ꍇ�ɂ̂ݔ���
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Target"))
                {
                    // ���O����@������X�R�A�����Z���A���O�����������ނ܂ōēx�@���Ȃ��悤�ɂ���
                    AddPoints(pointValue);
                    hit = true; // ���O�����@���ꂽ���Ƃ������t���O�𗧂Ă�
                }
            }
        }
    }

    //�_�������Z
    private void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsText();
    }
    
    //UI��Score��\���AUI�̐������X�V
    private void UpdatePointsText()
    {
        if(textPoint != null)
        {
            textPoint.text = "Point:" + points;
        }
    }
}
