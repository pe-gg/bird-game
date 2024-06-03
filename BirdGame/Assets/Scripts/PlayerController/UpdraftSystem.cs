using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdraftSystem : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;
    private Rigidbody _rb;
    private IEnumerator moveCoroutine;
    private IEnumerator upDraftCoroutine;
    private IEnumerator gravityCoroutine;
    [SerializeField] private float maxSpeed;



    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        moveCoroutine = MoveCoroutine();
        upDraftCoroutine = UpDraftCoroutine();
        gravityCoroutine = GravityCoroutine();  


    }

    public void Move()
    {
        StartCoroutine(moveCoroutine);
    }

    public void UpDraft()
    {
        
        StartCoroutine(upDraftCoroutine);
    }

    public void StopCoroutines()
    {
        StopAllCoroutines();
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            _rb.AddForce(Vector3.up * _speed);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator UpDraftCoroutine()
    {
        while (true)
        {
            StartCoroutine(moveCoroutine);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator GravityCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            _rb.useGravity = true;
        }
    }

    private void FixedUpdate()
    {

        Vector3 velocity = _rb.velocity;

        if (Mathf.Abs(velocity.y) > maxSpeed)
        {
            velocity.y = Mathf.Sign(velocity.y) * maxSpeed;
        }
        _rb.velocity = velocity;
    }

}
