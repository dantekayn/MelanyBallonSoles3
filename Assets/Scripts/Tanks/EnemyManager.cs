using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    //zona de variables globales
    [Header("Instantiate")]
    [SerializeField]
    private GameObject _tankEnemyPrefab;
    [SerializeField]
    private Transform[] _posRotTankEnemy;
    [SerializeField]
    private float _timeBetweenEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("CreateEnemies", _timeBetweenEnemies, _timeBetweenEnemies);

    }

    private void CreateEnemies()
    {

        int n = Random.Range(0, _posRotTankEnemy.Length);

        Instantiate(_tankEnemyPrefab, _posRotTankEnemy[n].position, _posRotTankEnemy[n].rotation);

    }

}
