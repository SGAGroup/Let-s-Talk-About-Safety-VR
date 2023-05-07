using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokeGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> BoxVariants = new List<GameObject>();

    [SerializeField]
    private uint splitFactor = 2;

    [SerializeField]
    private Transform offset = null;

    void Start()
    {
        float boxSize = 1f / splitFactor;

        Vector3 basePos = offset ? offset.position : transform.position; //If offset is set -> using it, otherwise using parent transform

        List<int> indexes_debug = new();

        string debug_result = "Indexes = [";
        for (int dx = 0; dx < splitFactor; dx++)
            for (int dy = 0; dy < splitFactor; dy++)
                for (int dz = 0; dz < splitFactor; dz++)
                {
                    int index = Random.Range(0, BoxVariants.Count);
                    debug_result += $"{index},";
                    indexes_debug.Add(index);
                    Vector3 addPos = new Vector3(boxSize * dx, boxSize * dy, boxSize * dz);
                    
                    GameObject newBox = Instantiate(BoxVariants[index], basePos + addPos, transform.rotation);
                    newBox.transform.localScale = new Vector3(boxSize, boxSize, boxSize);
                    newBox.transform.parent = transform;
                }
    }
}
