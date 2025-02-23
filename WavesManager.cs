using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WavesManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<WaveSpawner> waves;
    public static WavesManager instance;
    public UnityEvent onChanged;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("duplicated wavemanage, ignoring", gameObject);
    }


    public void AddWave(WaveSpawner wave)
    {
        waves.Add(wave);
        onChanged.Invoke();
    }

    public void RemoveWave(WaveSpawner wave)
    {
        waves.Remove(wave);
        onChanged.Invoke();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
