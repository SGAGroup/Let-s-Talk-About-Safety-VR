using UnityEngine;

public class PrimaryBox : MonoBehaviour
{
    public BoxGenerator boxGenerator;

    public void OnBreakHook()
    {
        boxGenerator.RemoveBox(gameObject);
    }
}
