using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    // Start is called before the first frame update
    public Life playerLife;
    public Life baseLife;


    void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerBaseDied);
        baseLife.onDeath.AddListener(OnPlayerBaseDied);
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    void OnPlayerBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    

    // Update is called once per frame
    void CheckWinCondition()
    {
        if (WavesManager.instance.waves.Count <= 0 && EnemiesManager.instance.enemies.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }

       
    }
}
