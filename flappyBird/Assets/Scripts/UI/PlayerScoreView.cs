using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PlayerScoreView : MonoBehaviour
{
    [SerializeField] private Bird _player;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.OnScoreChanged += DisplayNewScore;
    }

    private void OnDisable()
    {
        _player.OnScoreChanged -= DisplayNewScore;
    }

    private void DisplayNewScore(int newScore)
    {
        _text.text = newScore.ToString();
    }
}
