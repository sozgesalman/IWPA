using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ObjectPool objectPool;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        objectPool = GetComponent<ObjectPool>();

        InvokeRepeating("SpawnCloud", 1f, 1f);
    }

    void SpawnCloud()
    {
        GameObject cloud = objectPool.GetAvailableObject();
        cloud.transform.position = new Vector2(transform.position.x,Random.Range(-screenBounds.y,screenBounds.y));
        cloud.SetActive(true);
    }
}
