using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Assembler : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshPro> energyLabels = new();

    [SerializeField]
    private float timeToProcess = 2f;

    [SerializeField]
    private float consumption = 10f;
    private float remainedEnergy = 0;

    [SerializeField]
    private EnergyBoxConsumer energyBoxConsumer;
    [SerializeField]
    private CubeConsumer componentCubeConsumer;
    
    [SerializeField]
    private GameObject goldBoxPrefab;
    [SerializeField]
    private Transform goldSpawnPoint;


    void Start()
    {
        energyBoxConsumer.SetParent(this);
        componentCubeConsumer.SetParent(this);

        UpdateLabels();
    }

    public void AddEnergy(float energy)
    {
        remainedEnergy += energy;
        UpdateLabels();
    }

    private void RemoveEnergy(float energy)
    {
        remainedEnergy -= energy;
        UpdateLabels();
    }

    public IEnumerator InitiateProcessing(ComponentBox cube)
    {
        if (remainedEnergy >= consumption)
        {
            if (!goldBoxPrefab.GetComponent<GoldBox>())
            {
                Debug.LogWarning("Gold box prefab does not have 'GoldBox' component!");
                yield return null;
            }

            int valueOfCube = ComponentBox.ValuableTable[cube.type];

            yield return new WaitForSeconds(timeToProcess);

            Destroy(cube.gameObject);
            GameObject newBox = Instantiate(goldBoxPrefab, goldSpawnPoint);
            var goldBox = newBox.GetComponent<GoldBox>();
            goldBox.value = valueOfCube;

            RemoveEnergy(consumption);
        }
    }

    private void UpdateLabels()
    {
        bool isEmpty = remainedEnergy < consumption;
        foreach(var label in energyLabels)
        {
            label.text = remainedEnergy.ToString();
            if(isEmpty) label.color = Color.red;
            else label.color = Color.white;
        }
    }
}
