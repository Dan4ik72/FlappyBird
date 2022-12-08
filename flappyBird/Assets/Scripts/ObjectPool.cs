using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pool;

    [SerializeField] private GameObject _parent;

    [SerializeField] private Camera _camera;

    public void Create(GameObject prefab, int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject created = Instantiate(prefab, _parent.transform);

            created.SetActive(false);

            _pool.Add(created);
        }
    }

    public void ResetObjectPool()
    {
        if(_pool != null)
        {
            foreach(var item in _pool)
            {
                item.SetActive(false);
            }
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        DisableObjectsOutOfCamera();

        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    private void DisableObjectsOutOfCamera()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, -1));

        foreach(var item in _pool)
        {
            if (item.transform.position.x < disablePoint.x)
                item.SetActive(false);
        }
    }
}