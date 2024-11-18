using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;
    // [SerializeField] private int _scoreToWin = 10;
    [SerializeField] private List<Dirt> _dirts;

    private int _scoreValue;

    private void Start()
    {
        _dirts = new List<Dirt>(FindObjectsOfType<Dirt>());
    }

    private void OnEnable()
    {
        _player.OnDirtPickUp += SetScore;
    }

    private void OnDisable()
    {
        _player.OnDirtPickUp -= SetScore;
    }

    private void SetScore()
    {
        _scoreValue++;

        var activeDirts = _dirts.FindAll(dirt => dirt.gameObject.activeSelf);

        if(activeDirts.Count == 0)
        {
            _scoreText.text = "Level Complete!";

            LevelManager.Instance.LoadNextLevel();
        } else
        {
            _scoreText.text = $"Score: {_scoreValue}";
        }

        //if(_scoreValue < _scoreToWin)
        //{
        //    _scoreText.text = $"Score: {_scoreValue}";
        //} else
        //{
        //    _scoreText.text = "You win!";
        //}
        
    }
}
