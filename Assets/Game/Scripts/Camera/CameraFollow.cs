using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraFollowMultipleTargets : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform ball; 

    [SerializeField] private Collider2D mapBoundsCollider;
    private Bounds mapBounds;

    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private float padding = 2f;
    [SerializeField] private float minOrthographicSize = 5f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (mapBoundsCollider != null)
        {
            mapBounds = mapBoundsCollider.bounds;
        }
    }

    void LateUpdate()
    {
        if (player1 == null || player2 == null || ball == null)
        {
            return;
        }

        Bounds targetBounds = new Bounds(player1.position, Vector3.zero); 
        targetBounds.Encapsulate(player2.position); 
        targetBounds.Encapsulate(ball.position);    

        Vector3 midpoint = targetBounds.center;

        float requiredSizeX = (targetBounds.size.x * 0.5f + padding) / cam.aspect;
        float requiredSizeY = targetBounds.size.y * 0.5f + padding;
        
        float desiredSize = Mathf.Max(requiredSizeX, requiredSizeY);
        float finalSize = Mathf.Max(desiredSize, minOrthographicSize);

        float camHeight = finalSize * 2f;
        float camWidth = camHeight * cam.aspect;

        float mapMinX = mapBounds.min.x + (camWidth / 2f);
        float mapMaxX = mapBounds.max.x - (camWidth / 2f);
        float mapMinY = mapBounds.min.y + (camHeight / 2f);
        float mapMaxY = mapBounds.max.y - (camHeight / 2f);

        float clampedX = Mathf.Clamp(midpoint.x, mapMinX, mapMaxX);
        float clampedY = Mathf.Clamp(midpoint.y, mapMinY, mapMaxY);
        
        Vector3 targetPosition = new Vector3(clampedX, clampedY, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, finalSize, smoothSpeed * Time.deltaTime);
    }
}