using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool("IsHeroNear", true);
    }
}
