using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount;
    public static ScoreManager instance;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("duplicated score, ignoring", gameObject);
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
