using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float objDistance = -40f;
    [SerializeField] private float despawnDistance = -110f;

    private bool canSpawnGround = true;


    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;

        if(transform.position.z <= objDistance && transform.tag == "ground" && canSpawnGround)
        {
            PlatformSpawner.Instance.SpawnGround();
            canSpawnGround = false;
        }

        if(transform.position.z <= despawnDistance)
        {
            canSpawnGround = true;
            gameObject.SetActive(false);
        }
    }
}
