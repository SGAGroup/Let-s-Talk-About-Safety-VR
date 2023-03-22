using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPresser : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    void Start()
    {
        //Получаем компонент звука в переменную sound
        sound = GetComponent<AudioSource>();

        isPressed = false;
    }

    //При нажатии на кнопку
    private void OnTriggerEnter(Collider other)
    {
        //Проверяем не нажата ли уже кнопка
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;

            //Запускаем событие onPress
            onPress.Invoke();

            //Проигрываем звук
            sound.Play();

            //Говорим, что кнопка нажата
            isPressed = true;
        }
    }

    //При отпускании кнопки
    private void OnTriggerExit(Collider other)
    {
        if (other == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);

            //Запускаем событие onRelease
            onRelease.Invoke();

            //Говорим, что кнопка не нажата
            isPressed = false;
        }
    }

    //Функция спавна сферы
    public void SpawnSphere()
    {
        //Говорим что sphere - это спавн примитива сфера
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //Параметры создаваемой сферы: изменяем размер, позицию и добавляем компоненты физики и возможности взять
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.AddComponent<Rigidbody>();

    }

}