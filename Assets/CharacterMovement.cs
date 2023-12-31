using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public ParticleSystem dust;
    [SerializeField] private float _speed;
    private Vector3 _input;
    private Rigidbody2D _rigidbody;
    private bool _isMoving;
    [SerializeField] private SpriteRenderer _characterSprite;
    private CharacterAnimations _animations;
    [SerializeField] private int _jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<CharacterAnimations>();
        dust.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0;
        var em = dust.emission;

        if (_isMoving)
        {
            _characterSprite.flipX = _input.x > 0 ? false : true;
            em.rateOverTime = 10.0f;
        }
        else
        {
            em.rateOverTime = 0.0f;
        }
        _animations.isMoving = _isMoving;
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
