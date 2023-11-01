using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform mPlayer;
    TPCBase mThirdPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        mThirdPersonCamera = new TPCTrack(transform, mPlayer);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mThirdPersonCamera.update();
    }
}

public abstract class TPCBase
{
    protected Transform mCameraTransform;
    protected Transform mPlayerTransform;

    public Transform CameraTransform
    {
        get
        {
            return mCameraTransform;
        }
    }
    public Transform PlayerTransform
    {
        get
        {
            return mPlayerTransform;
        }
    }
    public TPCBase(Transform cameraTransform, Transform playerTransform)
    {
        mCameraTransform = cameraTransform;
        mPlayerTransform = playerTransform;
    }
    public abstract void update();
}

public class TPCTrack : TPCBase
{
    public TPCTrack(Transform cameraTransform, Transform playerTransform) : base(cameraTransform, playerTransform)
    {
    }

    public override void update()
    {
        // make the camera track the player based on its position and its relative height. vector3.up sets the vector3 as 0,1,0
        Vector3 targetPos = mPlayerTransform.position + Vector3.up * (mPlayerTransform.localScale.y);
        mCameraTransform.LookAt(targetPos);
    }
}

