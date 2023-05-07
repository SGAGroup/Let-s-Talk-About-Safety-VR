using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingCube : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private Material dissolvingMaterial;

    [SerializeField]
    private float dissolvingTime = 2f;

    private void Start()
    {
        if (!dissolvingMaterial) //If material not set by Unity editor - tries to get by 'GetComponent'
            dissolvingMaterial = GetComponent<MeshRenderer>().materials[0];

        dissolvingMaterial.SetFloat("_TimeOfDissapering", dissolvingTime);
        dissolvingMaterial.SetFloat("_InstantiateTime", Time.fixedTime);
        StartCoroutine(DestroyRoutine());
    }

    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(dissolvingTime);
        Destroy(parent);
    }
}
