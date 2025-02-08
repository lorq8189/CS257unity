using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public float sTime;
    public float eTime;
    public float spawnRate;
    void Start()
    {
        InvokeRepeating("Spawn", sTime, spawnRate);
        Invoke("CancelInvoke", eTime);
    }

    void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
