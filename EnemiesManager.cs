using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Enemy> enemies;
    public UnityEvent onChanged;
    public static EnemiesManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("duplicated score, ignoring", gameObject);
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        onChanged.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
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
