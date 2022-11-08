using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    CharacterController _charC;
    public Animator _anim;

    public bool isWalking = false;
    public bool isSlow = false;
    private void Start()
    {
        _charC = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _anim.SetBool("isWalking", true);
            _anim.SetBool("isSlow", false);
            Debug.Log("Im walking heeeeere");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isSlow", true);
            Debug.Log("OW MY BACK");
        }
    }
}
