﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    [SerializeField] private Transform[] _points;

    private int _currentPoint = 0;

    private void Start()
    {
        StartCoroutine(MoveToPoints());
    }

    private IEnumerator MoveToPoints()
    {
        float distanceToTarget = 0.01f;

        while (_currentPoint < _points.Length)
        {
            if (transform.position.IsEnoughClose(_points[_currentPoint].transform.position, distanceToTarget))
            {
                _currentPoint = ++_currentPoint % _points.Length;
            }

            transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].transform.position, _speed * Time.deltaTime);

            yield return null;
        }

        _currentPoint = 0;
    }
}
