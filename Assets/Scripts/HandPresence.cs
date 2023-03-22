using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    [SerializeField] private List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    private GameObject spawnedController;
    public InputDeviceCharacteristics controllerCharacteristics;

    void Start()
    {
        {
            StartCoroutine(GetDevices(1.0f));
        }
    }
    IEnumerator GetDevices(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        //Создаём список всех VR-устройтв
        List<InputDevice> devices = new List<InputDevice>();

        //Получаем характеристики всех устройств и записываем в список
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        //Если в списке больше одного устройства
        if (devices.Count > 0)
        {
            Debug.Log("Найдены устройства. Давай посмотрим, что у тебя там");
            foreach (var item in devices)
            {
                Debug.Log(item.name + item.characteristics);
            }
            Debug.Log("Н-да ну и хлам!");

            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                Debug.Log(targetDevice.name);
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.Log(controllerPrefabs.Count);
                Debug.LogError("У тебя какой-то палёный шлемак. Ищем универсальные руки..");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
        }
    }

    void Update()
    {

        //Слушаем нажатия кнопки
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
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
