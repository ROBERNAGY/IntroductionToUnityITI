using TMPro;
using UnityEngine;

public class PlayerForwardDetector : MonoBehaviour
{
    [SerializeField] private float detectionRange = 5.0f;
    [SerializeField] private LayerMask obstacleLayers;
    [SerializeField] private Vector3 rayOffset = new Vector3(0, 1.0f, 0);
    public string lastHitObjectName{get; private set;}
    [SerializeField]private TextMeshProUGUI logText;
    void Start()
    {
        logText.SetText("None");
    }
    void Update()
    {
        DetectObjectInFront();
        logText.SetText(lastHitObjectName);
    }

    void DetectObjectInFront()
    {
        Vector3 origin = transform.position + rayOffset;

        Vector3 direction = transform.forward;

        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, detectionRange, obstacleLayers))
        {
            lastHitObjectName = hitInfo.collider.gameObject.name;
        }
        else
        {
            lastHitObjectName = "None";
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position + rayOffset;
        Vector3 direction = transform.forward;

        bool isHit = Physics.Raycast(origin, direction, out RaycastHit hit, detectionRange, obstacleLayers);

        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(origin, hit.point);
            
            Gizmos.DrawSphere(hit.point, 0.1f);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(origin, origin + (direction * detectionRange));
        }
    }
}