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
    private IEnumerator moveDownCoroutine;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float gravityDelay;



    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        moveCoroutine = MoveCoroutine();
        upDraftCoroutine = UpDraftCoroutine();
        moveDownCoroutine = MoveDownCoroutine();


    }

    public void Move()
    {
        StartCoroutine(moveCoroutine);
    }

    public void UpDraft()
    {
        
        StartCoroutine(upDraftCoroutine);
    }

    public void DownDraft()
    {
        StartCoroutine(DownDraftCoroutine());
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
    

    private void FixedUpdate()
    {

        Vector3 velocity = _rb.velocity;

        if (Mathf.Abs(velocity.y) > maxSpeed)
        {
            velocity.y = Mathf.Sign(velocity.y) * maxSpeed;
        }
        _rb.velocity = velocity;
    }
    
    private IEnumerator MoveDownCoroutine()
    {
        while (true)
        {
            _rb.AddForce(Vector3.down * _speed);
            yield return new WaitForFixedUpdate();
        }
    }
    
    private IEnumerator DownDraftCoroutine()
    {
        while (true)
        {
            StartCoroutine(moveDownCoroutine);
            yield return new WaitForFixedUpdate();
        }
    }

}


