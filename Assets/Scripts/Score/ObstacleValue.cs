using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Obstacle value" , menuName ="MachineLevelConfiguration")]
public class ObstacleValue : ScriptableObject
{
    [field: SerializeField] public int Coins { get; private set; }
    [field: SerializeField] public int Bouncer { get; private set; }
    [field: SerializeField] public int SmallBouncer { get; private set; }
    [field: SerializeField] public int TurningDoor { get; private set; }
    [field: SerializeField] public int Portal { get; private set; }
    [field: SerializeField] public int Boosters { get; private set; }
}
