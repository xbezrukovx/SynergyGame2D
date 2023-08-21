using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    private Transform _transform;
    private Transform _transformCharacter;
    [SerializeField] private GameObject _character;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _transformCharacter = _character.GetComponent<Transform>();
        _transformCharacter.SetPositionAndRotation(transform.position, transform.rotation);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
