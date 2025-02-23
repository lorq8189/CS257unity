using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;
    public float angle;
    public LayerMask obstaclesLayers;
    public LayerMask objectsLayers;
    public Collider detectedObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectsLayers);
        detectedObject = null;
        for (int i=0; i<colliders.Length; i++)
        {
            Collider collider = colliders[i];
            Vector3 dtCollider = Vector3.Normalize(collider.bounds.center - transform.position);
            Vector3 dtController = Vector3.Normalize(collider.bounds.center - transform.position);

            float angleToCollider = Vector3.Angle(transform.forward, dtController);

            if (angleToCollider < angle)
            {
                if (!Physics.Linecast(transform.position, collider.bounds.center, obstaclesLayers))
                {
                    detectedObject = collider;
                    break;
                }
            }
        }

        
    }
}
