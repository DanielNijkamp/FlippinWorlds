using Randomization;
using UnityEngine;
using UnityEngine.Serialization;

public sealed class  ObstacleGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private VariableInt _numObstacles;
    [SerializeField] private VariableFloat _offset;
    
    [SerializeField] private bool _rotateObstacles;
    [SerializeField] private VariableFloat _rotateSpeed;
    
    private void Start()
    {
        Generate();
    }
    
    private void OnDrawGizmosSelected()
    {
        Vector3 center = transform.position;
        var offsetValue = _offset.VariableType == VariableType.Fixed ? _offset.Value : _offset.MaxValue;

        if (_numObstacles.VariableType == VariableType.Fixed)
        {
            Gizmos.color = Color.cyan;
            if (_numObstacles.Value == 1)
            {
                Gizmos.DrawWireCube(center, Vector3.one);
            }
            else
            {
                float angleIncrement = 360f / _numObstacles.Value;
                for (int i = 0; i < _numObstacles.Value; i++)
                {
                    float angle = i * angleIncrement;
                    float x = Mathf.Sin(Mathf.Deg2Rad * angle) * offsetValue;
                    float z = Mathf.Cos(Mathf.Deg2Rad * angle) * offsetValue;
                    Vector3 position = center + new Vector3(x, 0, z);
                    Gizmos.DrawWireCube(position, Vector3.one);
                }
            }
        }
        DrawWireDisk(center, _offset.VariableType == VariableType.Fixed ? _offset.Value : _offset.MaxValue, Color.blue);
    }

    public void Generate()
    {
        switch (_numObstacles.Value)
        {
            case 1:
                SpawnObstacle(Vector3.zero);
                break;
            default:
                float angleIncrement = 360f / _numObstacles.Value;
                for (int i = 0; i < _numObstacles.Value; i++)
                {
                    float angle = i * angleIncrement;
                    float x = Mathf.Sin(Mathf.Deg2Rad * angle) * _offset.Value;
                    float z = Mathf.Cos(Mathf.Deg2Rad * angle) * _offset.Value;
                    Vector3 position = new Vector3(x, 0, z);
                    SpawnObstacle(position);
                }
                break;
        }
    }

    private void Update()
    {
        if (!_rotateObstacles) return;
        if (_numObstacles.Value > 1)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed.Value);
        }
    }

    private void SpawnObstacle(Vector3 position)
    {
        var obstacle = Instantiate(_obstaclePrefab, transform.position + position, Quaternion.identity);
        obstacle.transform.parent = transform;
    }
    private static void DrawWireDisk(Vector3 position, float radius, Color color)
    {
        var oldColor = Gizmos.color;
        Gizmos.color = color;
        var oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(position, Quaternion.identity, new Vector3(1, 0.0001f, 1));
        Gizmos.DrawWireSphere(Vector3.zero, radius);
        Gizmos.matrix = oldMatrix;
        Gizmos.color = oldColor;
    }
}
