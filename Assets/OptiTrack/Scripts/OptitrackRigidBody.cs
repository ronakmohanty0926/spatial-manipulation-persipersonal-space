//======================================================================================================
// Copyright 2016, NaturalPoint Inc.
//======================================================================================================

using System;
using UnityEngine;


public class OptitrackRigidBody : MonoBehaviour
{
    public OptitrackStreamingClient StreamingClient;
    public EventManager eventManager;
    public Int32 RigidBodyId;
    private float[] unityX = {-1.0f, 1.0f };
    private float[] unityY = { -0.5f, 0.5f };
    private float[] unityZ = { 4.0f, 6.0f };
    private float[] rngX = { -80.0f, 700.0f};//Physical Coordinates
    private float[] rngY = { 216.0f, 330.0f };
    private float[] rngZ = { 11.0f, 136.0f };


    void Start()
    {
        
        // If the user didn't explicitly associate a client, find a suitable default.
        if ( this.StreamingClient == null )
        {
            this.StreamingClient = OptitrackStreamingClient.FindDefaultClient();

            // If we still couldn't find one, disable this component.
            if ( this.StreamingClient == null )
            {
                Debug.LogError( GetType().FullName + ": Streaming client not set, and no " + typeof( OptitrackStreamingClient ).FullName + " components found in scene; disabling this component.", this );
                this.enabled = false;
                return;
            }
        }
    }


#if UNITY_2017_1_OR_NEWER
    void OnEnable()
    {
        Application.onBeforeRender += OnBeforeRender;
    }


    void OnDisable()
    {
        Application.onBeforeRender -= OnBeforeRender;
    }


    void OnBeforeRender()
    {
        UpdatePose();
    }
#endif


    void Update()
    {
        UpdatePose();
        
    }

    Vector3 _pos = new Vector3();
    void UpdatePose()
    {
        
        OptitrackRigidBodyState rbState = StreamingClient.GetLatestRigidBodyState( RigidBodyId );
        if ( rbState != null )
        {
            //this.transform.localPosition = rbState.Pose.Position;
            //this.transform.localRotation = rbState.Pose.Orientation;
            {
                Vector3 _prevOrientation = rbState.Pose.Orientation.eulerAngles;
                Vector3 _orient;
                _orient.x = -1 * _prevOrientation.x;
                _orient.y = _prevOrientation.y;
                _orient.z = -1 * _prevOrientation.z;
                _pos[0] = -1 * rbState.Pose.Position.x;
                _pos[1] = rbState.Pose.Position.y;
                _pos[2] = -1 * rbState.Pose.Position.z;
                //this.transform.localPosition = rbState.Pose.Position;
                //this.transform.localRotation = rbState.Pose.Orientation;
                this.transform.localPosition = _pos;
                this.transform.localRotation = Quaternion.Euler(_orient);
            }
        }
    }
}
