using UnityEngine;
using UnityEngine.VFX;

public class WireOpenPart : MonoBehaviour
{
    [SerializeField]
    private Wire wire;
    public Wire Wire { get { return wire; } }


    [SerializeField]
    private VisualEffect electricityEffectExample;
    private VisualEffect electricityEffect = null;

    private WireOpenPart other = null;


    private void OnTriggerEnter(Collider collider)
    {
        // ���� ��� ���� ������� � ������ - �� �����, � ��� ������
        if (other != null) return;

        // �������� �������� ���� �� ���������
        var otherOpenPart = collider.gameObject.GetComponent<WireOpenPart>();
        if (!otherOpenPart) return; //���� ��� �� ������ �������� ������� - �� ������ �����

        // ���� ��� �������� ������� ��� ����������� - ����� �������
        bool conflict = IsConnected() && otherOpenPart.IsConnected();
        if (!conflict) return;

        // ���������� �����
        electricityEffect = Instantiate(electricityEffectExample, transform.position, Quaternion.identity);
        electricityEffect.transform.localScale = Vector3.one;

        other = otherOpenPart;
    }

    private void OnTriggerExit(Collider collider)
    {
        var otherOpenPart = collider.gameObject.GetComponent<WireOpenPart>();
        if (!otherOpenPart) return;
        
        if (otherOpenPart == other)
        {
            other = null;

            Destroy(electricityEffect);
            electricityEffect = null;
        }
    }

    public void Connect(ElectricityGenerator generator)
    {
        wire.Connect(generator);
    }
    public ElectricityGenerator Unconnect()
    { 
        return wire.Unconnect();
    }

    public bool IsConnected()
    {
        return wire.isConnected;
    }
}
