using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _playerPrefab;
    public static PlayerSpawner Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SpawnPlayer()
    {
        GameObject Player = Instantiate(_playerPrefab, _spawnPoint);
    }
}
