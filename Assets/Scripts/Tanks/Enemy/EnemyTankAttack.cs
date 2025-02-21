using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyTankAttack : MonoBehaviour
{
    //zona de variables globales
    [Header("Timer")]
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _timeBetweenAttacks;

    private bool _isAttack;

    [Header("Prefab")]
    [SerializeField]
    private Rigidbody _shellEnemyPrefab;
    [SerializeField]
    private Transform _posShell;
    [SerializeField]
    private float _launchForce;
    [SerializeField]
    private float _factorLaunchForce;

    [Header("Raycast")]
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField]
    private float _distance;

    private void Awake()
    {
        
        _isAttack = false;

    }

    private void FixedUpdate()
    {
        
        if(_isAttack) //(_isAttack == true)
        {

            Launch();
            _isAttack = false;

        }

    }

    void Update()
    {

        CountTimer();

    }

    private void CountTimer()
    {
        _ray.origin = transform.position;
        _ray.direction = transform.forward;

        _timer += Time.deltaTime; //_timer = _timer + Time.deltaTime;
        
        if(Physics.Raycast(_ray, out _hit))
        {

            if (_hit.collider.CompareTag("PlayerTank") && _timer > _timeBetweenAttacks)
            {

                _timer = 0.0f;
                _isAttack = true;
                //se saca la distancia que hay desde el tanque "player" hasta el enemigo
                _distance = _hit.distance;

            }

        }

    }

    private void Launch()
    {
        float launchForceFinal = _launchForce * _distance * _factorLaunchForce;
        Rigidbody cloneShellPrefab = Instantiate(_shellEnemyPrefab, _posShell.position, _posShell.rotation);
        cloneShellPrefab.velocity = _posShell.forward * launchForceFinal;

    }

}
