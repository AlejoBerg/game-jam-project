using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRedererSorter : MonoBehaviour
{
    [SerializeField] private int _sortingOrderBase = 5000;
    [SerializeField] private int _offset = 0;
    [SerializeField] private bool _runOnlyOnce = false;

    private Renderer _myRenderer;
    private float _timer;
    private float _timerMax = 0.1f;

    private void Awake()
    {
        _myRenderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        _timer -= Time.deltaTime;

        if(_timer < 0)
        {
            _timer = _timerMax;

            _myRenderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y - _offset);
            if (_runOnlyOnce)
            {
                Destroy(this);
            }
        } 
    }
}
