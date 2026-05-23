using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private float _waypointThreshold;

    public Vector2  PointPosition {  get; private set; }

    private int _currentIndex = 0;

    public void CheckPosition()
    {
        PointPosition = _points[_currentIndex].transform.position;

        if (Vector3Extensions.IsEnoughClose(transform.position, PointPosition, _waypointThreshold))
        {
          _currentIndex = ++_currentIndex % _points.Count;
        }
    }
}