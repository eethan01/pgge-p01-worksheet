using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //CharacterController controller;
    //Animator animationController;
    //float speed = 5;
    //float turnSpeed = 360;
    public CharacterController mCharacterController;
    public Animator mAnimator;
    public float mWalkSpeed = 1.0f;
    public float mRotationSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        //animationController = GetComponent<Animator>();
        mCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    //    void Update()
    //    {
    //        code every move input individually
    //        if(Input.GetKey(KeyCode.W))
    //        {
    //            controller.Move(gameObject.transform.forward * speed * Time.deltaTime);
    //        }
    //        if (Input.GetKey(KeyCode.S))
    //        {
    //            controller.Move(gameObject.transform.forward * -speed * Time.deltaTime);
    //        }
    //        if (Input.GetKey(KeyCode.A))
    //        {
    //            gameObject.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    //        }
    //        if (Input.GetKey(KeyCode.D))
    //        {
    //            gameObject.transform.Rotate(0, turnSpeed * -1 * Time.deltaTime, 0);
    //        }
    //        if (Input.GetKey(KeyCode.LeftShift))
    //        {
    //            speed = 10;
    //        }
    //        else
    //        {
    //            speed = 5;
    //        }
    //    }
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        float speed = mWalkSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = mWalkSpeed * 2.0f;
        }
        if (mAnimator == null) return;
        transform.Rotate(0.0f, hInput * mRotationSpeed * Time.deltaTime,
        0.0f);
        //Get the forward direction of the GameObject and normalize it
        //Vector3 forward =
        //transform.TransformDirection(Vector3.forward).normalized;

        //forward.y = 0.0f;
        mCharacterController.Move(gameObject.transform.forward * vInput * speed *
        Time.deltaTime);
        mAnimator.SetFloat("PosX", 0);
        mAnimator.SetFloat("PosZ", vInput * speed / 2.0f * mWalkSpeed);
    }
}
