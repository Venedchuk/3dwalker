﻿using UnityEngine;
using System.Collections;

public class MoveMouse : MonoBehaviour
{

    /// <summary>
    /// Скрипт управления камерой через мышку
    /// GameObject - объект, к которому привязана камера (вращаемся вокруг этого объекта)
    /// sensitivity - чувствительность мышки
    /// </summary>

    public GameObject go;
    public float sensitivity = 5F;
    private Camera goCamera;
    private Vector3 MousePos;
    private float MyAngle = 0F;

    void Start()
    {
        // Инициализируем кординаты мышки и ищем главную камеру
        goCamera = GetComponent<Camera>();
        go = goCamera.transform.parent.gameObject;
    }

    void Update()
    {
        MousePos = Input.mousePosition;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            MyAngle = 0;
            // расчитываем угол, как:
            // разница между позицией мышки и центром экрана, делённая на размер экрана
            //  (чем дальше от центра экрана тем сильнее поворот)
            // и умножаем угол на чуствительность из параметров
            MyAngle = sensitivity * ((MousePos.x - (Screen.width / 2)) / Screen.width);
            goCamera.transform.RotateAround(go.transform.position, goCamera.transform.up, 0);
            MyAngle = sensitivity * ((MousePos.y - (Screen.height / 2)) / Screen.height);
            goCamera.transform.RotateAround(go.transform.position, goCamera.transform.right, -0);
        }
    }
}