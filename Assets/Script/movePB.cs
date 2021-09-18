using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePB : MonoBehaviour
{
    private float _playerInput;
    private float _rotationInput;
    private Vector3 _userRot;

    private const float _inputScale = 0.5f;
    private const float _roatateScale = 2f;

    private Rigidbody _rigidbody;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerInput = Input.GetAxis("Vertical");
        _rotationInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        _userRot = _transform.rotation.eulerAngles;
        _userRot += new Vector3(0, _rotationInput * _roatateScale, 0);

        _transform.rotation = Quaternion.Euler(_userRot);
        _rigidbody.velocity += _transform.forward * _playerInput * _inputScale;
    }
}
