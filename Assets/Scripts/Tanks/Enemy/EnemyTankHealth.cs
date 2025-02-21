using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTankHealth : MonoBehaviour
{
    //zona de variables globales 
    [Header("Health")]
    //sal�d m�xima
    [SerializeField]
    private float _maxHealth;
    //sal�d actual
    [SerializeField]
    private float _currentHealth;
    //El da�o que me hacen las shells del tanque enemigo
    [SerializeField]
    private float _damageShell;

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    private void Awake()
    {

        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

    }

    private void OnTriggerEnter(Collider infoAccess)
    {

        if (infoAccess.CompareTag("Shell"))
        {

            //_currentHealth = _currentHealth - _damageShellEnemy
            _currentHealth -= _damageShell;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoAccess.gameObject);

            if (_currentHealth <= 0.0f)
            {

                Death();

            }

        }

    }

    private void Death()
    {

        Camera.main.transform.SetParent(null);
        Destroy(gameObject);

    }

}
