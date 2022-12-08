using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Pipe _template;

    [SerializeField] private float _yMaxOffset;
    [SerializeField] private float _yMinOffset;

    [SerializeField] private float _timeBetweenSpawn = 3f;

    private ObjectPool _pipes;

    private float _timeAfterLastSpawn = 3f;

    private void Awake()
    {
        _pipes = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        _pipes.Create(_template.gameObject, 10);
    }

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn >= _timeBetweenSpawn)
        {
            _timeAfterLastSpawn = 0;

            SpawnPipe();
        }
    }

    public void ResetSpawner()
    {
        _pipes.ResetObjectPool();
    }

    private void SpawnPipe()
    {
        if(_pipes.TryGetObject(out GameObject pipe))
        {
            pipe.transform.position = new Vector3(transform.position.x, GetRandomYOffset());

            pipe.SetActive(true);
        }
    }   

    private float GetRandomYOffset()
    {
         return Random.Range(_yMinOffset, _yMaxOffset);        
    }
}
