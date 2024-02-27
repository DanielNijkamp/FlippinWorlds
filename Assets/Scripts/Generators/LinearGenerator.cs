using System.Collections;
using System.Collections.Generic;
using Randomization;
using UnityEngine;
using UnityEngine.Serialization;

public sealed class LinearGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private VariableInt _numObstacles;
    [SerializeField] private VariableFloat _spacing;
    [SerializeField] private VariableFloat _lineRotationAngle;
    [SerializeField] private VariableFloat _obstacleRotationAngle;
    
    void Start()
    {
        Generate();
    }

    private void OnDrawGizmosSelected()
    {
        Quaternion lineRotation = Quaternion.Euler(0f, _lineRotationAngle.Value, 0f);
        Vector3 startPosition = transform.position;

        var obstacleCount = _numObstacles.VariableType == VariableType.Fixed
            ? _numObstacles.Value
            : _numObstacles.MaxValue;

        var lineSpacing = _spacing.VariableType == VariableType.Fixed 
            ? _spacing.Value 
            : _spacing.MaxValue;
        
        Vector3 endPosition = transform.position + lineRotation * Vector3.right * (obstacleCount) * (lineSpacing);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(startPosition, endPosition);
        
        if (_numObstacles.VariableType == VariableType.Fixed)
        {
            var length = _numObstacles.Value;
            for (int i = 0; i < length; i++)
            {
                Gizmos.color = Color.cyan;
                
                Vector3 position = transform.position + lineRotation * Vector3.right * i * lineSpacing;
                Quaternion obstacleRotation = Quaternion.Euler(0f, _obstacleRotationAngle.Value, 0f);

                Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

                Gizmos.matrix = Matrix4x4.TRS(position, obstacleRotation, Vector3.one);
                Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            
                Gizmos.matrix = oldGizmosMatrix;

                Gizmos.color = Color.green;
                Vector3 forwardPosition = position + (obstacleRotation * Vector3.right * 0.5f);
                Gizmos.DrawLine(position, forwardPosition);
            }
            
        }
    }
    
    public void Generate()
    {
        Quaternion lineRotation = Quaternion.Euler(0f, _lineRotationAngle.Value, 0f);

        var length = _numObstacles.Value;
        for (int i = 0; i < length; i++)
        {
            Vector3 obstaclePosition = transform.position + lineRotation * Vector3.right * i * _spacing.Value;
            Quaternion obstacleRotation = Quaternion.Euler(0f, _obstacleRotationAngle.Value, 0f);
            SpawnObstacle(obstaclePosition, obstacleRotation);
        }
    }

    private void SpawnObstacle(Vector3 position, Quaternion rotation)
    {
        GameObject obstacle = Instantiate(_obstaclePrefab, position, rotation);
        obstacle.transform.parent = transform;
    }
}
