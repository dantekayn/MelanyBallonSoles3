using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{

    //zona de variables globales 
    [Header("Health")]
    //salúd máxima
    [SerializeField]
    private float _maxHealth;
    //salúd actual
    [SerializeField]
    private float _currentHealth;
    //El daño que me hacen las shells del tanque enemigo
    [SerializeField]
    private float _damageShellEnemy;

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Game Over")]
    [SerializeField]
    private GameManagerTanks _gameManager;

    private void Awake()
    {

        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        
        if(infoAccess.CompareTag("ShellEnemy"))
        {

            //_currentHealth = _currentHealth - _damageShellEnemy
            _currentHealth -= _damageShellEnemy;
            _lifeBar.fillAmount =_currentHealth / _maxHealth;
            Destroy(infoAccess.gameObject);

            if(_currentHealth <= 0.0f)
            {

                Death();

            }

        }

    }

    private void Death()
    {
        _gameManager.GameOver();
        Camera.main.transform.SetParent(null);
        Destroy(gameObject);

    }

}
