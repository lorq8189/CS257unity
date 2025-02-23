using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount;
    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(GivePoints);


    }

    void GivePoints()
    {
        
        ScoreManager.instance.amount += amount;
    }

    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
