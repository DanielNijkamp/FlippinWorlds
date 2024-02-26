using UnityEngine;

public class ObstacleGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int numObstacles;
    [SerializeField] private float offset = 1f;
    
    [SerializeField] private bool rotateObstacles;
    [SerializeField] private float rotateSpeed;
    
    private void Start()
    {
        Generate();
    }
    
    private void OnDrawGizmosSelected()
    {
        Vector3 center = transform.position;
        DrawWireDisk(center, offset, Color.blue);
        
        Gizmos.color = Color.cyan;
        switch (numObstacles)
        {
            case 1:
                Gizmos.DrawWireCube(center, Vector3.one);
                break;
            default:
                float angleIncrement = 360f / numObstacles;
                for (int i = 0; i < numObstacles; i++)
                {
                    float angle = i * angleIncrement;
                    float x = Mathf.Sin(Mathf.Deg2Rad * angle) * offset;
                    float z = Mathf.Cos(Mathf.Deg2Rad * angle) * offset;
                    Vector3 position = center + new Vector3(x, 0, z);
                    Gizmos.DrawWireCube(position, Vector3.one);
                }
                break;
        }
    }
    public void Generate()
    {
        switch (numObstacles)
        {
            case 1:
                SpawnObstacle(Vector3.zero);
                break;
            default:
                float angleIncrement = 360f / numObstacles;
                for (int i = 0; i < numObstacles; i++)
                {
                    float angle = i * angleIncrement;
                    float x = Mathf.Sin(Mathf.Deg2Rad * angle) * offset;
                    float z = Mathf.Cos(Mathf.Deg2Rad * angle) * offset;
                    Vector3 position = new Vector3(x, 0, z);
                    SpawnObstacle(position);
                }
                break;
        }
    }

    private void Update()
    {
        if (rotateObstacles && numObstacles > 1)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
        }
    }

    private void SpawnObstacle(Vector3 position)
    {
        var obstacle = Instantiate(obstaclePrefab, transform.position + position, Quaternion.identity);
        obstacle.transform.parent = transform;
    }
    private void DrawWireDisk(Vector3 position, float radius, Color color)
    {
        Color oldColor = Gizmos.color;
        Gizmos.color = color;
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(position, Quaternion.identity, new Vector3(1, 0.0001f, 1));
        Gizmos.DrawWireSphere(Vector3.zero, radius);
        Gizmos.matrix = oldMatrix;
        Gizmos.color = oldColor;
    }
}
