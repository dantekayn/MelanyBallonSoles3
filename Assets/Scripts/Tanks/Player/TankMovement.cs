using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksMovement : MonoBehaviour
{
    //Zona de variables Globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;

    private float _vertical,
                  _horizontal;
    private Rigidbody _rb;

    [Header("Sound")]
    [SerializeField]
    private AudioClip _idleClip;
    [SerializeField]
    private AudioClip _drivingClip;

    private AudioSource _audioSource;


    private void Awake()
    {

        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        Move();
        Turn();

    }

    // Update is called once per frame
    void Update()
    {

        InputPlayer();
        AudioPlayer();

    }

    private void InputPlayer()
    {

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

    }

    private void Move()
    {

        Vector3 direction = transform.forward * _vertical * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + direction);

    }

    private void Turn()
    {

        float turn = _horizontal * _turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, _horizontal, 0.0f);
        _rb.MoveRotation(transform.rotation * turnRotation);

    }

    private void AudioPlayer()
    {

        //el tanque se está moviendo o está rotando
        if (_vertical != 0.0f || _horizontal != 0.0f)
        {

            if(_audioSource.clip != _drivingClip)
            {

                _audioSource.clip = _drivingClip;
                _audioSource.Play();

            }

        }
        else //el tanque está parado
        {

            _audioSource.clip = _idleClip;
            _audioSource.Play();

        }

    }

}
