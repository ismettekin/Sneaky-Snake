using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    private bool isSpawning = false;

    [SerializeField] private float spawnDistance = 50f;
    public static PlatformSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnGround()
    {
        PlatformPooler.Instance.SpawnFromPool("ground", new Vector3(0f, 0f, spawnDistance), Quaternion.identity);
        isSpawning = true;
    }
}
