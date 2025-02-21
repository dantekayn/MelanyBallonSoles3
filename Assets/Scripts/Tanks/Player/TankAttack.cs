using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    //Zona de variables globales
    //Referencia al prefabicado de la bala
    [SerializeField]
    private GameObject _shellPrefab;
    //Referencia al "gameObject" vacío que representa la posición de salida
    [SerializeField]
    private Transform _posShell;
    //Fuerza a la que sale la bala
    [SerializeField]
    private float _launchForce;
    //Referencia al componente AudioSource que lleva el objeto "_posShell"
    [SerializeField]
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        InputPlayer();

        
    }

    private void InputPlayer()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Launch();

        }

    }

    private void Launch()
    {

        GameObject cloneShellPrefab = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);
        _audioSource.Play();
        cloneShellPrefab.GetComponent<Rigidbody>().velocity = _posShell.forward * _launchForce;

    }

}
