using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTanks : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField]
    private GameObject _panelGameOver;
    [SerializeField]
    private EnemyManager _enemyManager;


    public void GameOver()
    {

        //Activamos el panel de "game over"
        _panelGameOver.SetActive(true);
        //Desactivamos el componente "enemyMananger"
        _enemyManager.enabled = false;
        

    }

    //m�todo al que llamamos al pulsar el bot�mn "retry"
    public void LoadSceneLevel()
    {

        SceneManager.LoadScene("Tanks");

    }

}
