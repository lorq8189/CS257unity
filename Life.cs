using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    public float amount;
    public UnityEvent onDeath;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amount <= 0)
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
