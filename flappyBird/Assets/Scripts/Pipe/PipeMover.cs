using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pipe))]
public class PipeMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    public void Init(float speed)
    {
        _speed = speed;
    }
}
