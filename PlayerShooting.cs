using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public GameObject shootPoint;


    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject clone = Instantiate(prefab);

            clone.transform.position = shootPoint.transform.position;
        
            clone.transform.rotation = shootPoint.transform.rotation;
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
