using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        Destroy(gameObject);

        Life li = other.GetComponent<Life>();

        if (li != null)
            li.amount -= damage;


    }
   
}
