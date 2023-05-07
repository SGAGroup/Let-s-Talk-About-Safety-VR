using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    public enum TimeMeasurment
    {
        Seconds = 1,
        Milliseconds = 1000
    }

    [SerializeField]
    private TimeMeasurment measurment = TimeMeasurment.Seconds;
    [SerializeField]
    private float timeToSpawn = 1f;
    [SerializeField]
    private GameObject objToSpawn;
    [SerializeField]
    private int maxBoxes = 5;

    private float trueTime => timeToSpawn / (int)measurment;
    private bool isTurnedOn = true;
    private List<GameObject> liveBoxes = new();

    void Start()
    {
        StartCoroutine(Generate(objToSpawn));
    }

    IEnumerator Generate(GameObject spawnable)
    {
        while (isTurnedOn)
        {
            if (liveBoxes.Count < maxBoxes)
            {
                var newBox = Instantiate(spawnable, transform);
                newBox.GetComponent<PrimaryBox>().boxGenerator = this;
                liveBoxes.Add(newBox);
                yield return new WaitForSeconds(trueTime);
            }
            else yield return new WaitForSeconds(0.1f);
        }
    }

    public void RemoveBox(GameObject box)
    {
        liveBoxes.Remove(box);
    }

    public void TurnOn()
    {
        isTurnedOn = true;
    }
    public void TurnOff()
    {
        isTurnedOn = false;
    }
}
