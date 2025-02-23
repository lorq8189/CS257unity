using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent onDeath;

    void Start()
    {
        EnemiesManager.instance.AddEnemy(this);
    }

    

    // Update is called once per frame
    void Update()
    {
        //EnemiesManager.instance.RemoveEnemy(this);
    }
}
