using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private float _waypointThreshold;

    public Vector2  TargetPosition {  get; private set; }

    private int _currentIndex = 0;

    public void CheckPosition()
    {
        TargetPosition = _points[_currentIndex].transform.position;

        if (Vector3Extensions.IsEnoughClose(transform.position, TargetPosition, _waypointThreshold))
        {
          _currentIndex = ++_currentIndex % _points.Count;
        }
    }
}