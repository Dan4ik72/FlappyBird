using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMovement))]
public class Bird : MonoBehaviour
{
    public event UnityAction<int> OnScoreChanged;
    public event UnityAction OnBirdDied;

    [SerializeField] private int _score;

    private BirdMovement _movement;

    public int Score => _score;

    private void Awake()
    {
        _movement = GetComponent<BirdMovement>();
    }

    public void ResetBird()
    {
        _score = 0;

        OnScoreChanged?.Invoke(_score);

        _movement.enabled = true;

        _movement.ResetBird();
    }

    public void Die()
    {
        OnBirdDied?.Invoke();

        _movement.enabled = false;        
    }
    
    public void CollectScorePoint()
    {
        _score++;

        OnScoreChanged?.Invoke(_score);
    }
}
