using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LinearGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int numObstacles;
    [SerializeField] private float spacing;
    [SerializeField] private float lineRotationAngle;
    [SerializeField] private float obstacleRotationAngle;
    
    void Start()
    {
        Generate();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Quaternion lineRotation = Quaternion.Euler(0f, lineRotationAngle, 0f);
        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + lineRotation * Vector3.right * (numObstacles - 1) * spacing;
        Gizmos.DrawLine(startPosition, endPosition);
    
        for (int i = 0; i < numObstacles; i++)
        {
            Gizmos.color = Color.cyan;
            Vector3 position = transform.position + lineRotation * Vector3.right * i * spacing;
            Quaternion obstacleRotation = Quaternion.Euler(0f, obstacleRotationAngle, 0f);
        
            Matrix4x4 oldGizmosMatrix = Gizmos.matrix;  // Store the old matrix

            Gizmos.matrix = Matrix4x4.TRS(position, obstacleRotation, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        
            Gizmos.matrix = oldGizmosMatrix;  // Reset the matrix for DrawLine

            Gizmos.color = Color.green;
            Vector3 forwardPosition = position + (obstacleRotation * Vector3.right * 0.5f);
            Gizmos.DrawLine(position, forwardPosition);
        }
    }

    public void Generate()
    {
        Quaternion lineRotation = Quaternion.Euler(0f, lineRotationAngle, 0f);

        // Generate obstacles in the line
        for (int i = 0; i < numObstacles; i++)
        {
            Vector3 obstaclePosition = transform.position + lineRotation * Vector3.right * i * spacing;
            Quaternion obstacleRotation = Quaternion.Euler(0f, obstacleRotationAngle, 0f);
            SpawnObstacle(obstaclePosition, obstacleRotation);
        }
    }

    private void SpawnObstacle(Vector3 position, Quaternion rotation)
    {
        GameObject obstacle = Instantiate(obstaclePrefab, position, rotation);
        obstacle.transform.parent = transform;
    }
}
