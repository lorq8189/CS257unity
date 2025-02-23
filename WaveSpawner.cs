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
        WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", sTime, spawnRate);
        Invoke("EndSpawner", eTime);
    }

    void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    

    void EndSpawner()
    {
        WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
