using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _waypointThreshold;

    private int _currentIndex = 0;

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (Vector3Extensions.IsEnoughClose(transform.position, _points[_currentIndex].transform.position, _waypointThreshold))
        {
          _currentIndex = (_currentIndex + 1) % _points.Count;
        }

        transform.position = Vector2.MoveTowards(transform.position, _points[_currentIndex].transform.position, _speed * Time.deltaTime);
    }
}