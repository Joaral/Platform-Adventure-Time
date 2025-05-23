using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector2 areaCenter;
    private Vector2 targetPosition;
    private Vector2 currentPosition;

    public float rightMax;
    public float leftMax;
    public float upMax;
    public float downMax;

    public float speed = 5f;
    public float alpha = 7.0f;

    public Transform center;
    public Transform leftLimit;
    public Transform rightLimit;
    public Transform upLimit;
    public Transform downLimit;

    void Awake()
    {
        if (target != null)
        {
            currentPosition.x = target.transform.position.x;
            currentPosition.y = target.transform.position.y;
            transform.position = new Vector3(currentPosition.x, currentPosition.y, -1);
        }
        if (leftLimit == null || rightLimit == null || areaCenter == null)
        {
            Debug.LogError("No se han asignado todos los objetos en Camera_mode.");
        }

    }

    void Move_Cam()
    {
      

        if (target)
        {
            targetPosition.x = target.transform.position.x;
            targetPosition.y = target.transform.position.y;
            //targetPosition.y = areaCenter.y; // Mantener Y en el centro del área

            // Restringimos X e Y dentro de los nuevos límites
            float clampedX = Mathf.Clamp(targetPosition.x, leftMax, rightMax);
            float clampedY = Mathf.Clamp(targetPosition.y, downMax, upMax);
            currentPosition.x = clampedX;
            currentPosition.y = clampedY;

            // Movemos la cámara hacia la posición del jugador sin transiciones forzadas
            transform.position = Vector3.Lerp(transform.position, new Vector3(currentPosition.x, currentPosition.y, -1), speed * Time.unscaledDeltaTime);
        }
    }

    private void Start()
    {
        leftMax = leftLimit.position.x;
        rightMax = rightLimit.position.x;
        upMax = upLimit.position.y;
        downMax = downLimit.position.y;

        Debug.Log("Área asignada: " + areaCenter.x + ", " + areaCenter.y);
    }
    void Update()
    {
        Move_Cam();
    }
}