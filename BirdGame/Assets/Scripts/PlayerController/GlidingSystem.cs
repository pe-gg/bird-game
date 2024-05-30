using System.Collections;
using UnityEngine;

public class GlidingSystem : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;
    private Rigidbody _rb;
    private IEnumerator moveCoroutine;
    private IEnumerator glideCoroutine;

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
        _rb.useGravity = false;
        StartCoroutine(glideCoroutine);
    }

    public void StopCoroutines()
    {
        _rb.useGravity = true;
        StopAllCoroutines();
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            _rb.AddForce(Vector3.right * _speed);
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

}
