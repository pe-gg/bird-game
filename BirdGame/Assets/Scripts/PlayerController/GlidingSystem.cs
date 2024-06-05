using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GlidingSystem : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;
    private Rigidbody _rb;
    private IEnumerator moveCoroutine;
    private IEnumerator glideCoroutine;
    [SerializeField] private float maxSpeed;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        moveCoroutine = MoveCoroutine();
        glideCoroutine = GlideCoroutine();
    }

    public void Move()
    {
        StartCoroutine(moveCoroutine);
    }

    public void Glide()
    {
        
        StartCoroutine(glideCoroutine);
    }

    public void StopCoroutines()
    {
                    
        StopAllCoroutines();
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator GlideCoroutine()
    {
        while (true)
        {
            StartCoroutine(moveCoroutine);
            yield return new WaitForFixedUpdate();
        }
    }

    private void FixedUpdate()
    {
        
        if (_rb.velocity.magnitude > maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * maxSpeed;
        }
    }

    private void Update()
    {
        _rb.AddForce(Vector3.right * _speed);
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
        }
        
    }    
}
