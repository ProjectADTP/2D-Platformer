using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    
    private Transform[] _points;
    
    private int _currentPoint = 0;

    public void GoToPoints(Transform[] points)
    {
        _points = points;

        StartCoroutine(MoveToPoints());
    }

    private IEnumerator MoveToPoints()
    {
        float distanceToTarget = 0.01f;

        while (_currentPoint < _points.Length)
        {
            if (transform.position.IsEnoughClose(_points[_currentPoint].transform.position, distanceToTarget))
                _currentPoint = ++_currentPoint % _points.Length;

            transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].transform.position, _speed * Time.deltaTime);

            yield return null;
        }

        _currentPoint = 0;
    }
}
