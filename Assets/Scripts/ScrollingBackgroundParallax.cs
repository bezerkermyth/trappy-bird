﻿using System.Collections;
using UnityEngine;

public class ScrollingBackgroundParallax : MonoBehaviour
{
    public bool Scrolling, Parallax; 

    public float BackgroundSize;
    public float ParallaxSpeed;

    private Transform _cameraTransform;
    private Transform[] _layers;
    private float _viewZone = 10;
    private int _leftIndex;
    private int _rightIndex;
    private float _lastCameraX;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _lastCameraX = _cameraTransform.position.x;
        _layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            _layers[i] = transform.GetChild(i);

        _leftIndex = 0;
        _rightIndex = _layers.Length - 1;
    }

    private void Update()
    {
        if (Parallax)
        {
            float deltaX = _cameraTransform.position.x - _lastCameraX;
            transform.position += Vector3.right * (deltaX * ParallaxSpeed);
        }

        _lastCameraX = _cameraTransform.position.x;

        if (Scrolling)
        { 
            if (_cameraTransform.position.x < (_layers[_leftIndex].transform.position.x + _viewZone))
                ScrollLeft();
            if (_cameraTransform.position.x > (_layers[_rightIndex].transform.position.x - _viewZone))
                ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        _layers[_rightIndex].position = Vector3.right * (_layers[_leftIndex].position.x - BackgroundSize);
        _leftIndex = _rightIndex;
        _rightIndex--;
        if (_rightIndex < 0)
            _rightIndex = _layers.Length - 1;
    }

    private void ScrollRight()
    {
        _layers[_leftIndex].position = Vector3.right * (_layers[_rightIndex].position.x + BackgroundSize);
        _rightIndex = _leftIndex;
        _leftIndex++;
        if (_leftIndex == _layers.Length)
            _leftIndex = 0;
    }
}
