using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    [SerializeField] private List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    private GameObject spawnedController;

    void Start()
    {
        {
            //При запуске void Start() шлем не успевает очухаться и мы пропускаем всё что там написано, поэтому
            //запускаем коорутину, чтобы подождать пока шлем придёт в себя
            StartCoroutine(GetDevices(1.0f));
        }

        IEnumerator GetDevices(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);

            //Получаем список всех VR-устройтв (шлем + контроллеры)
            List<InputDevice> devices = new List<InputDevice>();

            //Получаем в devices характеристику лишь правого контроллера
            InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
            InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);


            Debug.Log("Давай посмотрим, что у тебя там за сетапчик");
            foreach (var item in devices)
            {
                //Отображаем в консоли название предмета + его характеристики
                Debug.Log(item.name + item.characteristics);
            }
            Debug.Log("Garbage!");

            if (devices.Count > 0)
            {
                targetDevice = devices[0];
                //Выбираем модель рук, в зависимости от устройства, которым мы пользуемся
                //При добавлении новых моделей быть внимательным: Название префаба = название устроства в юнити, иначе работать не будет
                GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
                Debug.Log(targetDevice.name);
                //Нашли совпадение в названии, значит создаем соответствующий префаб в сцене
                if (prefab)
                {
                    spawnedController = Instantiate(prefab, transform);
                }
                else
                {
                    Debug.LogError("Что за мусор ты на себя нацепил?");
                    //Создаём унифицированный префаб контроллера (для этого он должен быть первый в листе)
                    spawnedController = Instantiate(controllerPrefabs[0], transform);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

        //Слушаем нажатия кнопки
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton , out bool primaryButtonValue) && primaryButtonValue)
        {
            //Вывод значения в консоль о нажатии
            Debug.Log("Йоу йоу йоу я нажимаю на кнопшку. Основную!");
        }

        //Слушаем триггер на контроллере
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            //Вывод значения в консоль о нажатии на триггер
            Debug.Log("Кто стреляет?" + triggerValue);
        }
            
        //Слушаем джойстик на контроллере
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        {
            //Вывод значения в консоль о передвижении джойстика
            Debug.Log("Кручу я гачу верчу!" + primary2DAxisValue);
        }
            
    }
}
