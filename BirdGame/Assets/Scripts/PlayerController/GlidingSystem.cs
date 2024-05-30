using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlidingSystem : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _currentSpeed;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Glide()
    {
        Debug.Log("GLIDE");
    }

    public void Idle()
    {
        Debug.Log("IDLE");
    }

    public void Fall()
    {
        Debug.Log("FALL");
    }
}
