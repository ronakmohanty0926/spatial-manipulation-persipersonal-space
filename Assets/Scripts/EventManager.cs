using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using NaturalPoint;

public class EventManager : MonoBehaviour
{
    //Private Variables
    //private float[] prevPegPos = new float[3];
    //private float[] currentPegPos = new float[3];
    //private float[] prevHolePos = new float[3];
    //private float[] currentHolePos = new float[3];
    //private float[] displPeg = new float[3];
    //private float[] displHole = new float[3];

    //private float[] prevRightWristPos = new float[3];
    //private float[] currRightWristPos = new float[3];
    //private float[] prevRightElbowPos = new float[3];
    //private float[] currRightElbowPos = new float[3];
    //private float[] prevRightShouldertPos = new float[3];
    //private float[] currRightShoulderPos = new float[3];

    //private float[] prevLeftWristPos = new float[3];
    //private float[] currLeftWristPos = new float[3];
    //private float[] prevLeftElbowPos = new float[3];
    //private float[] currLeftElbowPos = new float[3];
    //private float[] prevLeftShouldertPos = new float[3];
    //private float[] currLeftShoulderPos = new float[3];

    //private float[] prevHeadPos = new float[3];
    //private float[] currHeadPos = new float[3];

    //private float[] pegNormalX = new float[3];
    //private float[] pegNormalY = new float[3];
    //private float[] pegNormalZ = new float[3];

    //private float[] holeNormalX = new float[3];
    //private float[] holeNormalY = new float[3];
    //private float[] holeNormalZ = new float[3];

    //private float[] _pegPos = new float[3];
    //private float[] _pegAngle = new float[3];
    //private float[] _holePos = new float[3];
    //private float[] _holeAngle = new float[3];
    //private float[] _headPos = new float[3];
    //private float[] _headAngle = new float[3];
    //private float[] _rightWristPos = new float[3];
    //private float[] _rightElbowPos = new float[3];
    //private float[] _rightShoulderPos = new float[3];
    //private float[] _leftWristPos = new float[3];
    //private float[] _leftElbowPos = new float[3];
    //private float[] _leftShoulderPos = new float[3];
    //private float[] _rightWristAngle = new float[3];
    //private float[] _rightElbowAngle = new float[3];
    //private float[] _rightShoulderAngle = new float[3];
    //private float[] _leftWristAngle = new float[3];
    //private float[] _leftElbowAngle = new float[3];
    //private float[] _leftShoulderAngle = new float[3];

    //private Vector3 _cameraPos = new Vector3();
    //private Vector3 _cameraAngle = new Vector3();

    private int userID, studyVariant, shapeVariant, shapeCount, randNum, shapeCollision;
    //private int scountCylinder, scountParallelopiped, scountTriangle, scountTrap;
    //private int mcountCylinder, mcountParallelopiped, mcountTriangle, mcountTrap;
    //private int lcountCylinder, lcountParallelopiped, lcountTriangle, lcountTrap;
    private int scountCylinder, scountShaftKey, scountTwoPin, scountThreePin;
    private int mcountCylinder, mcountShaftKey, mcountTwoPin, mcountThreePin;
    private int lcountCylinder, lcountShaftKey, lcountTwoPin, lcountThreePin;
    //private int scollisionCylinder, scollisionParallelopiped, scollisionTriangle, scollisionTrap;
    //private int mcollisionCylinder, mcollisionParallelopiped, mcollisionTriangle, mcollisionTrap;
    //private int lcollisionCylinder, lcollisionParallelopiped, lcollisionTriangle, lcollisionTrap;
    private int scollisionCylinder, scollisionShaftKey, scollisionTwoPin, scollisionThreePin;
    private int mcollisionCylinder, mcollisionShaftKey, mcollisionTwoPin, mcollisionThreePin;
    private int lcollisionCylinder, lcollisionShaftKey, lcollisionTwoPin, lcollisionThreePin;
    private string shapeName, shapeSize;
    private float RMS, errX, errY, errZ, smoothValue, timeStart, timeStop, totalTime, timeNow;

   //private float[] Origin = { 0.0f, 0.0f, 0.0f }; //To be re-mapped
    //private float[] Xaxis = { 1.0f, 0.0f, 0.0f };
    //private float[] Yaxis = { 0.0f, 1.0f, 0.0f };
    //private float[] Zaxis = { 0.0f, 0.0f, 1.0f };
    //private float[] unityX = { -186.0f, -33.0f };
    //private float[] unityY = { -52.0f, 28.0f };
    //private float[] unityZ = { 18.0f, 124.0f };
    //private float[] rngX = { -610.0f, 440.0f };//Physical Coordinates
    //private float[] rngY = { 14.0f, 158.0f };
    //private float[] rngZ = { -144.0f, 748.0f };

    //private List<Vector3> pegTraj = new List<Vector3>();
    private List<Vector3> phypegTraj = new List<Vector3>();
    //private List<Vector3> holeTraj = new List<Vector3>();
    private List<Vector3> phyholeTraj = new List<Vector3>();
    //private List<Vector3> pegNormTraj = new List<Vector3>();
    //private List<Vector3> holeNormTraj = new List<Vector3>();
    private List<Vector3> pegAngle = new List<Vector3>();
    private List<Vector3> holeAngle = new List<Vector3>();

    private List<Vector3> headTraj = new List<Vector3>();
    private List<Vector3> headAngle = new List<Vector3>();

    private List<Vector3> rightWristTraj = new List<Vector3>();
    private List<Vector3> rightElbowTraj = new List<Vector3>();
    private List<Vector3> rightShoulderTraj = new List<Vector3>();

    private List<Vector3> rightWristAngle = new List<Vector3>();
    private List<Vector3> rightElbowAngle = new List<Vector3>();
    private List<Vector3> rightShoulderAngle = new List<Vector3>();

    private List<Vector3> leftWristTraj = new List<Vector3>();
    private List<Vector3> leftElbowTraj = new List<Vector3>();
    private List<Vector3> leftShoulderTraj = new List<Vector3>();

    private List<Vector3> leftWristAngle = new List<Vector3>();
    private List<Vector3> leftElbowAngle = new List<Vector3>();
    private List<Vector3> leftShoulderAngle = new List<Vector3>();

    private List<float> timeElapsed = new List<float>();

    private GameObject headTracking;

    //Public Variables

    //public GameObject psmallCylinder, pmedCylinder, plargeCylinder;
    //public GameObject hsmallCylinder, hmedCylinder, hlargeCylinder;
    //public GameObject psmallParallelopiped, pmedParallelopiped, plargeParallelopiped;
    //public GameObject hsmallParallelopiped, hmedParallelopiped, hlargeParallelopiped;
    //public GameObject psmallTriangle, pmedTriangle, plargeTriangle;
    //public GameObject hsmallTriangle, hmedTriangle, hlargeTriangle;
    //public GameObject psmallTrap, pmedTrap, plargeTrap;
    //public GameObject hsmallTrap, hmedTrap, hlargeTrap;

    public GameObject psmallCylinder, pmedCylinder, plargeCylinder;
    public GameObject hsmallCylinder, hmedCylinder, hlargeCylinder;
    public GameObject psmallShaftKey, pmedShaftKey, plargeShaftKey;
    public GameObject hsmallShaftKey, hmedShaftKey, hlargeShaftKey;
    public GameObject psmallTwoPin, pmedTwoPin, plargeTwoPin;
    public GameObject hsmallTwoPin, hmedTwoPin, hlargeTwoPin;
    public GameObject psmallThreePin, pmedThreePin, plargeThreePin;
    public GameObject hsmallThreePin, hmedThreePin, hlargeThreePin;

    public GameObject rightWrist, rightElbow, rightShoulder;
    public GameObject leftWrist, leftElbow, leftShoulder;
    
    //public float[] streamPos = new float[3];
    //public float[] streamAngle = new float[3];
    public float errA, errB, errC;
    //public Collision collision;

    //GUI
    private Canvas canvas = new Canvas();
    private InputField uID;
    private bool IsRecording { get; set; }
    private bool IsRendering { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        IsRecording = false;
        IsRendering = false;
        canvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        uID = GameObject.Find("UserID").GetComponent<InputField>();
        headTracking = GameObject.FindGameObjectWithTag("MainCamera");
        SetShapeParam();       
        randNum = -1;
        totalTime = 0;

        phyholeTraj.Clear();
        phypegTraj.Clear();
        pegAngle.Clear();
        holeAngle.Clear();

        headTraj.Clear();
        headAngle.Clear();

        rightWristTraj.Clear();
        rightWristAngle.Clear();
        rightElbowTraj.Clear();
        rightElbowAngle.Clear();
        rightShoulderTraj.Clear();
        rightShoulderAngle.Clear();

        leftWristTraj.Clear();
        leftWristAngle.Clear();
        leftElbowTraj.Clear();
        leftElbowAngle.Clear();
        leftShoulderTraj.Clear();
        leftShoulderAngle.Clear();

        timeElapsed.Clear();

        scountCylinder = scountShaftKey = scountTwoPin = scountThreePin = 0;
        mcountCylinder = mcountShaftKey = mcountTwoPin = mcountThreePin = 0;
        lcountCylinder = lcountShaftKey = lcountTwoPin = lcountThreePin = 0;

        //scollisionCylinder = scollisionParallelopiped = scollisionTriangle = scollisionTrap = 0;
        //mcollisionCylinder = mcollisionParallelopiped = mcollisionTriangle = mcollisionTrap = 0;
        //lcollisionCylinder = lcollisionParallelopiped = lcollisionTriangle = lcollisionTrap = 0;

        scollisionCylinder = scollisionShaftKey = scollisionTwoPin = scollisionThreePin = 0;
        mcollisionCylinder = mcollisionShaftKey = mcollisionTwoPin = mcollisionThreePin = 0;
        lcollisionCylinder = lcollisionShaftKey = lcollisionTwoPin = lcollisionThreePin = 0;

        uID.onEndEdit.AddListener(delegate { GetUserID(uID); canvas.enabled = false; });      
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log("UID-> " + userID);
        UpdateAll();
    }

    private void GetUserID(InputField uid)
    {
        string _userID = uid.text;
        userID = System.Convert.ToInt32(_userID);
    }

    private void GetRand(int randNum)
    {
        if (randNum != -1 && IsRecording) { SaveLog(); }

        phyholeTraj.Clear();
        phypegTraj.Clear();
        pegAngle.Clear();
        holeAngle.Clear();

        headTraj.Clear();
        headAngle.Clear();

        rightWristTraj.Clear();
        rightElbowTraj.Clear();
        rightShoulderTraj.Clear();

        rightWristAngle.Clear();
        rightElbowAngle.Clear();
        rightShoulderAngle.Clear();

        leftWristTraj.Clear();
        leftElbowTraj.Clear();
        leftShoulderTraj.Clear();

        leftWristAngle.Clear();
        leftElbowAngle.Clear();
        leftShoulderAngle.Clear();

        //shapeCollision = 0;
        //shapeCount = 0;

        switch (randNum)
        {
            case 0:
                Debug.Log("Count-> " + scountCylinder);
                scountCylinder++;
                shapeCount = scountCylinder;
                shapeName = "Cylinder";
                shapeSize = "small";                
                break;
            case 1:
                scountTwoPin++;
                shapeCount = scountTwoPin;
                shapeName = "TwoPin";
                shapeSize = "small";                
                break;
            case 2:
                scountShaftKey++;
                shapeCount = scountShaftKey;
                shapeName = "ShaftKey";
                shapeSize = "small";                
                break;
            case 3:
                scountThreePin++;
                shapeCount = scountThreePin;
                shapeName = "ThreePin";
                shapeSize = "small";                
                break;
            case 4:
                mcountCylinder++;
                shapeCount = mcountCylinder;
                shapeName = "Cylinder";
                shapeSize = "medium";
                break;
            case 5:
                mcountTwoPin++;
                shapeCount = mcountTwoPin;
                shapeName = "TwoPin";
                shapeSize = "medium";
                break;
            case 6:
                mcountShaftKey++;
                shapeCount = mcountShaftKey;
                shapeName = "ShaftKey";
                shapeSize = "medium";
                break;
            case 7:
                mcountThreePin++;
                shapeCount = mcountThreePin;
                shapeName = "ThreePin";
                shapeSize = "medium";
                break;
            case 8:
                lcountCylinder++;
                shapeCount = lcountCylinder;
                shapeName = "Cylinder";
                shapeSize = "large";
                break;
            case 9:
                lcountTwoPin++;
                shapeCount = lcountTwoPin;
                shapeName = "TwoPin";
                shapeSize = "large";
                break;
            case 10:
                lcountShaftKey++;
                shapeCount = lcountShaftKey;
                shapeName = "ShaftKey";
                shapeSize = "large";
                break;
            case 11:
                lcountThreePin++;
                shapeCount = lcountThreePin;
                shapeName = "ThreePin";
                shapeSize = "large";
                break;
        }
    }

    private void SetShapeParam()
    {
        //SetPegs
        psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);       
        psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
        psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
        psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);


        //SetHoles        
        hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false); 
        hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
        hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false); 
        hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
    }

    //private void UpdatePegPosition(ref float[] position)
    //{
    //    float[] _position = new float[3];
    //    Vector3 _phypos = new Vector3();
    //    //Vector3 _pos = new Vector3();

    //    _phypos.x = position[0];
    //    _phypos.y = position[1];
    //    _phypos.z = position[2];

    //    //NormalizeCoord(ref position, ref _position);
    //    //_pos.x = _position[0];
    //    //_pos.y = _position[1];
    //    //_pos.z = _position[2];

    //    prevPegPos[0] = currentPegPos[0];
    //    prevPegPos[1] = currentPegPos[1];
    //    prevPegPos[2] = currentPegPos[2];

    //    currentPegPos[0] = position[0];
    //    currentPegPos[1] = position[1]; 
    //    currentPegPos[2] = position[2];

    //    //displPeg[0] = currentPegPos[0] - prevPegPos[0];
    //    //displPeg[1] = currentPegPos[1] - prevPegPos[1];
    //    //displPeg[2] = currentPegPos[2] - prevPegPos[2];        

    //    //if (IsRecording)
    //    //{
    //    //    phypegTraj.Add(_phypos);
            
            
    //    //    pegTraj.Add(_pos);
    //    //}
    //}

    //private void UpdateHolePosition(ref float[] position)
    //{
    //    float[] _position = new float[3];
    //    Vector3 _phypos = new Vector3();
    //    Vector3 _pos = new Vector3();

    //    _phypos.x = position[0];
    //    _phypos.y = position[1];
    //    _phypos.z = position[2];

    //    NormalizeCoord(ref position, ref _position);
    //    _pos.x = _position[0];
    //    _pos.y = _position[1];
    //    _pos.z = _position[2];

    //    prevHolePos[0] = currentHolePos[0];
    //    prevHolePos[1] = currentHolePos[1];
    //    prevHolePos[2] = currentHolePos[2];

    //    currentHolePos[0] = position[0];
    //    currentHolePos[0] = position[1]; 
    //    currentHolePos[0] = position[2]; 

    //    //displHole[0] = currentHolePos[0] - prevHolePos[0];
    //    //displHole[1] = currentHolePos[1] - prevHolePos[1];
    //    //displHole[2] = currentHolePos[2] - prevHolePos[2];

    //    //if (IsRecording == true)
    //    //{
    //    //    phyholeTraj.Add(_phypos);
    //    //    holeTraj.Add(_pos);
    //    //}
    //}

    //private void UpdatePegNormal(ref float[] angle)
    //{
    //    float[] matX = new float[9];
    //    float[] matY = new float[9];
    //    float[] matZ = new float[9];

    //    //_AxisAngle(ref Xaxis, ref angle[0], ref matX);
    //    //_AxisAngle(ref Yaxis, ref angle[1], ref matY);
    //    //_AxisAngle(ref Zaxis, ref angle[2], ref matZ);

    //    _RotateVec3(ref pegNormalX, ref matX);
    //    _RotateVec3(ref pegNormalY, ref matY);
    //    _RotateVec3(ref pegNormalZ, ref matZ);    
    //}

    //private void UpdateHoleNormal(ref float[] angle)
    //{
    //    float[] matX = new float[9];
    //    float[] matY = new float[9];
    //    float[] matZ = new float[9];

    //    //_AxisAngle(ref Xaxis, ref angle[0], ref matX);
    //    //_AxisAngle(ref Yaxis, ref angle[1], ref matY);
    //    //_AxisAngle(ref Zaxis, ref angle[2], ref matZ);

    //    _RotateVec3(ref holeNormalX, ref matX);
    //    _RotateVec3(ref holeNormalY, ref matY);
    //    _RotateVec3(ref holeNormalZ, ref matZ);
    //}

    //private void UpdateCamera(ref float[] position)
    //{
    //    //Here change camera position based on head orientation
    //}

    //private void UpdateTransition(bool transitionState) 
    //{ 
    //    if(transitionState == true)
    //    {

    //    }
    //}

    private void UpdateAll()
    {
        KeyBoardInputs();
        PegListener();
        HoleListener();
        HeadListener();
        WristListener();
        ElbowListener();
        ShoulderListener();
        Render();
        UpdateTime();
    }

    private void UpdateTime()
    {
        if (IsRecording)
        {
            totalTime += Time.deltaTime;
            timeElapsed.Add(totalTime);
        }
    }
    private void HeadListener()
    {   
        if (IsRecording)
        {
            headTraj.Add(headTracking.transform.position);
            headAngle.Add(headTracking.transform.eulerAngles);
        }          
    }

    private void WristListener()
    {
        if (IsRecording)
        {
            rightWristTraj.Add(rightWrist.transform.position);
            rightWristAngle.Add(rightWrist.transform.eulerAngles);

            leftWristTraj.Add(leftWrist.transform.position);
            leftWristAngle.Add(leftWrist.transform.eulerAngles);
        }        
    }

    private void ElbowListener()
    {
        if (IsRecording)
        {
            rightElbowTraj.Add(rightElbow.transform.position);
            rightElbowAngle.Add(rightElbow.transform.eulerAngles);

            leftElbowTraj.Add(leftElbow.transform.position);
            leftElbowAngle.Add(leftElbow.transform.eulerAngles);
        }
    }

    private void ShoulderListener()
    {
        if (IsRecording)
        {
            rightShoulderTraj.Add(rightShoulder.transform.position);
            rightShoulderAngle.Add(rightShoulder.transform.eulerAngles);

            leftShoulderTraj.Add(leftShoulder.transform.position);
            leftShoulderAngle.Add(leftShoulder.transform.eulerAngles);
        }
    }

    private void PegListener()
    {
        //Vector3 _phypos = new Vector3();

        switch (randNum)
        {
            case 0:
                //_pegPos[0] = psmallCylinder.transform.position.x;
                //_pegPos[1] = psmallCylinder.transform.position.y;
                //_pegPos[2] = psmallCylinder.transform.position.z;

                //_pegAngle[0] = psmallCylinder.transform.eulerAngles.x;
                //_pegAngle[1] = psmallCylinder.transform.eulerAngles.y;
                //_pegAngle[2] = psmallCylinder.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(psmallCylinder.transform.position);
                    pegAngle.Add(psmallCylinder.transform.eulerAngles);
                }                
                break;
            case 1:
                //_pegPos[0] = psmallTwoPin.transform.position.x;
                //_pegPos[1] = psmallTwoPin.transform.position.y;
                //_pegPos[2] = psmallTwoPin.transform.position.z;

                //_pegAngle[0] = psmallTwoPin.transform.eulerAngles.x;
                //_pegAngle[1] = psmallTwoPin.transform.eulerAngles.y;
                //_pegAngle[2] = psmallTwoPin.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(psmallTwoPin.transform.position);
                    pegAngle.Add(psmallTwoPin.transform.eulerAngles);
                }                
                break;
            case 2:
                //_pegPos[0] = psmallShaftKey.transform.position.x;
                //_pegPos[1] = psmallShaftKey.transform.position.y;
                //_pegPos[2] = psmallShaftKey.transform.position.z;

                //_pegAngle[0] = psmallShaftKey.transform.eulerAngles.x;
                //_pegAngle[1] = psmallShaftKey.transform.eulerAngles.y;
                //_pegAngle[2] = psmallShaftKey.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(psmallShaftKey.transform.position);
                    pegAngle.Add(psmallShaftKey.transform.eulerAngles);
                }                
                break;
            case 3:
                //_pegPos[0] = psmallThreePin.transform.position.x;
                //_pegPos[1] = psmallThreePin.transform.position.y;
                //_pegPos[2] = psmallThreePin.transform.position.z;

                //_pegAngle[0] = psmallThreePin.transform.eulerAngles.x;
                //_pegAngle[1] = psmallThreePin.transform.eulerAngles.y;
                //_pegAngle[2] = psmallThreePin.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(psmallThreePin.transform.position);
                    pegAngle.Add(psmallThreePin.transform.eulerAngles);
                }                
                break;
            case 4:
                //_pegPos[0] = pmedCylinder.transform.position.x;
                //_pegPos[1] = pmedCylinder.transform.position.y;
                //_pegPos[2] = pmedCylinder.transform.position.z;

                //_pegAngle[0] = pmedCylinder.transform.eulerAngles.x;
                //_pegAngle[1] = pmedCylinder.transform.eulerAngles.y;
                //_pegAngle[2] = pmedCylinder.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(pmedCylinder.transform.position);
                    pegAngle.Add(pmedCylinder.transform.eulerAngles);
                }               
                break;
            case 5:
                //_pegPos[0] = pmedTwoPin.transform.position.x;
                //_pegPos[1] = pmedTwoPin.transform.position.y;
                //_pegPos[2] = pmedTwoPin.transform.position.z;

                //_pegAngle[0] = pmedTwoPin.transform.eulerAngles.x;
                //_pegAngle[1] = pmedTwoPin.transform.eulerAngles.y;
                //_pegAngle[2] = pmedTwoPin.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(pmedTwoPin.transform.position);
                    pegAngle.Add(pmedTwoPin.transform.eulerAngles);
                }                
                break;
            case 6:
                //_pegPos[0] = pmedShaftKey.transform.position.x;
                //_pegPos[1] = pmedShaftKey.transform.position.y;
                //_pegPos[2] = pmedShaftKey.transform.position.z;

                //_pegAngle[0] = pmedShaftKey.transform.eulerAngles.x;
                //_pegAngle[1] = pmedShaftKey.transform.eulerAngles.y;
                //_pegAngle[2] = pmedShaftKey.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(pmedShaftKey.transform.position);
                    pegAngle.Add(pmedShaftKey.transform.eulerAngles);
                }                
                break;
            case 7:
                //_pegPos[0] = pmedThreePin.transform.position.x;
                //_pegPos[1] = pmedThreePin.transform.position.y;
                //_pegPos[2] = pmedThreePin.transform.position.z;

                //_pegAngle[0] = pmedThreePin.transform.eulerAngles.x;
                //_pegAngle[1] = pmedThreePin.transform.eulerAngles.y;
                //_pegAngle[2] = pmedThreePin.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(pmedThreePin.transform.position);
                    pegAngle.Add(pmedThreePin.transform.eulerAngles);
                }               
                break;
            case 8:
                //_pegPos[0] = plargeCylinder.transform.position.x;
                //_pegPos[1] = plargeCylinder.transform.position.y;
                //_pegPos[2] = plargeCylinder.transform.position.z;

                //_pegAngle[0] = plargeCylinder.transform.eulerAngles.x;
                //_pegAngle[1] = plargeCylinder.transform.eulerAngles.y;
                //_pegAngle[2] = plargeCylinder.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(plargeCylinder.transform.position);
                    pegAngle.Add(plargeCylinder.transform.eulerAngles);
                }                
                break;
            case 9:
                //_pegPos[0] = plargeTwoPin.transform.position.x;
                //_pegPos[1] = plargeTwoPin.transform.position.y;
                //_pegPos[2] = plargeTwoPin.transform.position.z;

                //_pegAngle[0] = plargeTwoPin.transform.eulerAngles.x;
                //_pegAngle[1] = plargeTwoPin.transform.eulerAngles.y;
                //_pegAngle[2] = plargeTwoPin.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(plargeTwoPin.transform.position);
                    pegAngle.Add(plargeTwoPin.transform.eulerAngles);
                }                
                break;
            case 10:
                //_pegPos[0] = plargeShaftKey.transform.position.x;
                //_pegPos[1] = plargeShaftKey.transform.position.y;
                //_pegPos[2] = plargeShaftKey.transform.position.z;

                //_pegAngle[0] = plargeShaftKey.transform.eulerAngles.x;
                //_pegAngle[1] = plargeShaftKey.transform.eulerAngles.y;
                //_pegAngle[2] = plargeShaftKey.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(plargeShaftKey.transform.position);
                    pegAngle.Add(plargeShaftKey.transform.eulerAngles);
                }                
                break;
            case 11:
                //_pegPos[0] = plargeThreePin.transform.position.x;
                //_pegPos[1] = plargeThreePin.transform.position.y;
                //_pegPos[2] = plargeThreePin.transform.position.z;

                //_pegAngle[0] = plargeThreePin.transform.eulerAngles.x;
                //_pegAngle[1] = plargeThreePin.transform.eulerAngles.y;
                //_pegAngle[2] = plargeThreePin.transform.eulerAngles.z;

                //UpdatePegPosition(ref _pegPos);

                if (IsRecording)
                {
                    phypegTraj.Add(plargeThreePin.transform.position);
                    pegAngle.Add(plargeThreePin.transform.eulerAngles);
                }                
                break;
        }       
    }

    private void HoleListener()
    {        
        switch (randNum)
        {
            case 0:
                //_holePos[0] = hsmallCylinder.transform.position.x;
                //_holePos[1] = hsmallCylinder.transform.position.y;
                //_holePos[2] = hsmallCylinder.transform.position.z;

                //_holeAngle[0] = hsmallCylinder.transform.eulerAngles.x;
                //_holeAngle[1] = hsmallCylinder.transform.eulerAngles.y;
                //_holeAngle[2] = hsmallCylinder.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    Debug.Log("PosX-> " + 50 * hsmallCylinder.transform.position.x + " " + "PosY-> " + 50 * hsmallCylinder.transform.position.y + " " + "PosZ-> " + 50 * hsmallCylinder.transform.position.z);
                    phyholeTraj.Add(hsmallCylinder.transform.position);
                    holeAngle.Add(hsmallCylinder.transform.eulerAngles);
                }
                break;
            case 1:
                //_holePos[0] = hsmallTwoPin.transform.position.x;
                //_holePos[1] = hsmallTwoPin.transform.position.y;
                //_holePos[2] = hsmallTwoPin.transform.position.z;

                //_holeAngle[0] = hsmallTwoPin.transform.eulerAngles.x;
                //_holeAngle[1] = hsmallTwoPin.transform.eulerAngles.y;
                //_holeAngle[2] = hsmallTwoPin.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hsmallTwoPin.transform.position);
                    holeAngle.Add(hsmallTwoPin.transform.eulerAngles);
                }
                break;
            case 2:
                //_holePos[0] = hsmallShaftKey.transform.position.x;
                //_holePos[1] = hsmallShaftKey.transform.position.y;
                //_holePos[2] = hsmallShaftKey.transform.position.z;

                //_holeAngle[0] = hsmallShaftKey.transform.eulerAngles.x;
                //_holeAngle[1] = hsmallShaftKey.transform.eulerAngles.y;
                //_holeAngle[2] = hsmallShaftKey.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hsmallShaftKey.transform.position);
                    holeAngle.Add(hsmallShaftKey.transform.eulerAngles);
                }
                break;
            case 3:
                //_holePos[0] = hsmallThreePin.transform.position.x;
                //_holePos[1] = hsmallThreePin.transform.position.y;
                //_holePos[2] = hsmallThreePin.transform.position.z;

                //_holeAngle[0] = hsmallThreePin.transform.eulerAngles.x;
                //_holeAngle[1] = hsmallThreePin.transform.eulerAngles.y;
                //_holeAngle[2] = hsmallThreePin.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hsmallThreePin.transform.position);
                    holeAngle.Add(hsmallThreePin.transform.eulerAngles);
                }
                break;
            case 4:
                //_holePos[0] = hmedCylinder.transform.position.x;
                //_holePos[1] = hmedCylinder.transform.position.y;
                //_holePos[2] = hmedCylinder.transform.position.z;

                //_holeAngle[0] = hmedCylinder.transform.eulerAngles.x;
                //_holeAngle[1] = hmedCylinder.transform.eulerAngles.y;
                //_holeAngle[2] = hmedCylinder.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hmedCylinder.transform.position);
                    holeAngle.Add(hmedCylinder.transform.eulerAngles);
                }
                break;
            case 5:
                //_holePos[0] = hmedTwoPin.transform.position.x;
                //_holePos[1] = hmedTwoPin.transform.position.y;
                //_holePos[2] = hmedTwoPin.transform.position.z;

                //_holeAngle[0] = hmedTwoPin.transform.eulerAngles.x;
                //_holeAngle[1] = hmedTwoPin.transform.eulerAngles.y;
                //_holeAngle[2] = hmedTwoPin.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hmedTwoPin.transform.position);
                    holeAngle.Add(hmedTwoPin.transform.eulerAngles);
                }
                break;
            case 6:
                //_holePos[0] = hmedShaftKey.transform.position.x;
                //_holePos[1] = hmedShaftKey.transform.position.y;
                //_holePos[2] = hmedShaftKey.transform.position.z;

                //_holeAngle[0] = hmedShaftKey.transform.eulerAngles.x;
                //_holeAngle[1] = hmedShaftKey.transform.eulerAngles.y;
                //_holeAngle[2] = hmedShaftKey.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hmedShaftKey.transform.position);
                    holeAngle.Add(hmedShaftKey.transform.eulerAngles);
                }
                break;
            case 7:
                //_holePos[0] = hmedThreePin.transform.position.x;
                //_holePos[1] = hmedThreePin.transform.position.y;
                //_holePos[2] = hmedThreePin.transform.position.z;

                //_holeAngle[0] = hmedThreePin.transform.eulerAngles.x;
                //_holeAngle[1] = hmedThreePin.transform.eulerAngles.y;
                //_holeAngle[2] = hmedThreePin.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hmedThreePin.transform.position);
                    holeAngle.Add(hmedThreePin.transform.eulerAngles);
                }
                break;
            case 8:
                //_holePos[0] = hlargeCylinder.transform.position.x;
                //_holePos[1] = hlargeCylinder.transform.position.y;
                //_holePos[2] = hlargeCylinder.transform.position.z;

                //_holeAngle[0] = hlargeCylinder.transform.eulerAngles.x;
                //_holeAngle[1] = hlargeCylinder.transform.eulerAngles.y;
                //_holeAngle[2] = hlargeCylinder.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hlargeCylinder.transform.position);
                    holeAngle.Add(hlargeCylinder.transform.eulerAngles);
                }
                break;
            case 9:
                //_holePos[0] = hlargeTwoPin.transform.position.x;
                //_holePos[1] = hlargeTwoPin.transform.position.y;
                //_holePos[2] = hlargeTwoPin.transform.position.z;

                //_holeAngle[0] = hlargeTwoPin.transform.eulerAngles.x;
                //_holeAngle[1] = hlargeTwoPin.transform.eulerAngles.y;
                //_holeAngle[2] = hlargeTwoPin.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hlargeTwoPin.transform.position);
                    holeAngle.Add(hlargeTwoPin.transform.eulerAngles);
                }
                break;
            case 10:
                //_holePos[0] = hlargeShaftKey.transform.position.x;
                //_holePos[1] = hlargeShaftKey.transform.position.y;
                //_holePos[2] = hlargeShaftKey.transform.position.z;

                //_holeAngle[0] = hlargeShaftKey.transform.eulerAngles.x;
                //_holeAngle[1] = hlargeShaftKey.transform.eulerAngles.y;
                //_holeAngle[2] = hlargeShaftKey.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hlargeShaftKey.transform.position);
                    holeAngle.Add(hlargeShaftKey.transform.eulerAngles);
                }
                break;
            case 11:
                //_holePos[0] = hlargeThreePin.transform.position.x;
                //_holePos[1] = hlargeThreePin.transform.position.y;
                //_holePos[2] = hlargeThreePin.transform.position.z;

                //_holeAngle[0] = hlargeThreePin.transform.eulerAngles.x;
                //_holeAngle[1] = hlargeThreePin.transform.eulerAngles.y;
                //_holeAngle[2] = hlargeThreePin.transform.eulerAngles.z;

                //UpdateHolePosition(ref _holePos);

                if (IsRecording)
                {
                    phyholeTraj.Add(hlargeThreePin.transform.position);
                    holeAngle.Add(hlargeThreePin.transform.eulerAngles);
                }
                break;
        }        
    }
    

    //private bool NormalizeCoord(ref float[] oldPos, ref float[] newPos)
    //{
    //    float _posX, _posY, _posZ;
    //    _posX = (((oldPos[0] - rngX[0]) / (rngX[1] - rngX[0])) * (unityX[1] - unityX[0])) + unityX[0];   
    //    _posY = (((oldPos[1] - rngY[0]) / (rngY[1] - rngY[0])) * (unityY[1] - unityY[0])) + unityY[0];
    //    _posZ = (((oldPos[2] - rngZ[0]) / (rngZ[1] - rngZ[0])) * (unityZ[1] - unityZ[0])) + unityZ[0];

    //    newPos[0] = _posX; newPos[1] = _posY; newPos[2] = _posZ;    

    //    return true;
    //}


    public void DrawMesh() //Draw Peg and Hole Shapes based on Random Number Generated
    {
        switch (randNum)
        {
            case 0:
                //Debug.Log("Case 0");
                    psmallCylinder.SetActive(true); hsmallCylinder.SetActive(true);

                    pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                            
                break;
            case 1:                
                    psmallTwoPin.SetActive(true); hsmallTwoPin.SetActive(true);

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                               
                break;
            case 2:

               
                    psmallShaftKey.SetActive(true); hsmallShaftKey.SetActive(true);

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                              
                break;
            case 3:

                
                    psmallThreePin.SetActive(true); hsmallThreePin.SetActive(true);

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                              
                break;
            case 4:

                   pmedCylinder.SetActive(true); hmedCylinder.SetActive(true);

                    psmallCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                              
                break;
            case 5:

                   pmedTwoPin.SetActive(true); hmedTwoPin.SetActive(true);

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                            
                break;
            case 6:

                
                    pmedShaftKey.SetActive(true); hmedShaftKey.SetActive(true);

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                
                break;
            case 7:

                   pmedThreePin.SetActive(true); hmedThreePin.SetActive(true);

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                               
                break;
            case 8:

              
                    plargeCylinder.SetActive(true); hlargeCylinder.SetActive(true);
                    plargeCylinder.transform.Rotate(new Vector3(1, 0, 0), plargeCylinder.transform.rotation.x,Space.Self); 

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                              
                break;
            case 9:

                
                    plargeTwoPin.SetActive(true); hlargeTwoPin.SetActive(true);

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false);
                               
                break;
            case 10:

                
                    plargeShaftKey.SetActive(true); hlargeShaftKey.SetActive(true);

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); 
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false); plargeThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false); hlargeThreePin.SetActive(false);
                               
                break;
            case 11:

                
                    plargeThreePin.SetActive(true); hlargeThreePin.SetActive(true);

                    psmallCylinder.SetActive(false); pmedCylinder.SetActive(false); plargeCylinder.SetActive(false);
                    psmallShaftKey.SetActive(false); pmedShaftKey.SetActive(false); plargeShaftKey.SetActive(false);
                    psmallTwoPin.SetActive(false); pmedTwoPin.SetActive(false); plargeTwoPin.SetActive(false);
                    psmallThreePin.SetActive(false); pmedThreePin.SetActive(false);
                    hsmallCylinder.SetActive(false); hmedCylinder.SetActive(false); hlargeCylinder.SetActive(false);
                    hsmallShaftKey.SetActive(false); hmedShaftKey.SetActive(false); hlargeShaftKey.SetActive(false);
                    hsmallTwoPin.SetActive(false); hmedTwoPin.SetActive(false); hlargeTwoPin.SetActive(false);
                    hsmallThreePin.SetActive(false); hmedThreePin.SetActive(false);
                                
                break;
        }
    }

    //private void RenderMarkers() //Render Markers for Testing Purpose
    //{
        
    //}

    //private void RenderNormals()  //Render Normals for Testing Purpose
    //{
       
    //}

    private void Render()
    {
        DrawMesh();
        //RenderMarkers();
        //RenderNormals();
    }

    //private void ComputeRMS() //Compute Root Mean Square Error
    //{

    //}

    //Detect collisions between the GameObjects with Colliders attached
    //private void OnCollisionEnter(Collision collision)
    //{
    //    //Check for a match with the specified name on any GameObject that collides with your GameObject
    //    if (IsRecording)
    //    {
    //        if (collision.gameObject.tag == "psCylinder")
    //        {
    //            scollisionCylinder++;
    //            shapeCollision = scollisionCylinder;
    //        }

    //        else if (collision.gameObject.tag == "pmCylinder")
    //        {
    //            mcollisionCylinder++;
    //            shapeCollision = mcollisionCylinder;
    //        }

    //        else if (collision.gameObject.tag == "plCylinder")
    //        {
    //            lcollisionCylinder++;
    //            shapeCollision = lcollisionCylinder;                
    //        }

    //        else if (collision.gameObject.tag == "psTriangle")
    //        {
    //            scollisionTriangle++;
    //            shapeCollision = scollisionTriangle;
    //        }

    //        else if (collision.gameObject.tag == "pmTriangle")
    //        {
    //            mcollisionTriangle++;
    //            shapeCollision = mcollisionTriangle;
    //        }

    //        else if (collision.gameObject.tag == "plTriangle")
    //        {
    //            lcollisionTriangle++;
    //            shapeCollision = lcollisionTriangle;
    //        }

    //        else if (collision.gameObject.tag == "psPara")
    //        {
    //            scollisionParallelopiped++;
    //            shapeCollision = lcollisionParallelopiped;
    //        }

    //        else if (collision.gameObject.tag == "pmPara")
    //        {
    //            mcollisionParallelopiped++;
    //            shapeCollision = mcollisionParallelopiped;
    //        }

    //        else if (collision.gameObject.tag == "plPara")
    //        {
    //            lcollisionParallelopiped++;
    //            shapeCollision = lcollisionParallelopiped;
    //        }

    //        else if (collision.gameObject.tag == "psTrap")
    //        {
    //            scollisionTrap++;
    //            shapeCollision = scollisionTrap;
    //        }

    //        else if (collision.gameObject.tag == "pmTrap")
    //        {
    //            mcollisionTrap++;
    //            shapeCollision = mcollisionTrap;
    //        }

    //        else if (collision.gameObject.tag == "plTrap")
    //        {
    //            lcollisionTrap++;
    //            shapeCollision = lcollisionTrap;
    //        }
    //    }
    //}

    //private void ComputeAlignment()  //Compute Docking Alignment Error
    //{
    //    switch (randNum)
    //    {
    //        case 0:
    //            errA = 1 - Math.Abs(Vector3.Dot(psmallCylinder.transform.up, hsmallCylinder.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(psmallCylinder.transform.forward, hsmallCylinder.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(psmallCylinder.transform.right, hsmallCylinder.transform.right)); //Xaxis

    //            break;
    //        case 1:
    //            errA = 1 - Math.Abs(Vector3.Dot(psmallTwoPin.transform.up, hsmallTwoPin.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(psmallTwoPin.transform.forward, hsmallTwoPin.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(psmallTwoPin.transform.right, hsmallTwoPin.transform.right)); //Xaxis
    //            break;
    //        case 2:
    //            errA = 1 - Math.Abs(Vector3.Dot(psmallShaftKey.transform.up, hsmallShaftKey.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(psmallShaftKey.transform.forward, hsmallShaftKey.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(psmallShaftKey.transform.right, hsmallShaftKey.transform.right)); //Xaxis
    //            break;
    //        case 3:
    //            errA = 1 - Math.Abs(Vector3.Dot(psmallThreePin.transform.up, hsmallThreePin.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(psmallThreePin.transform.forward, hsmallThreePin.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(psmallThreePin.transform.right, hsmallThreePin.transform.right)); //Xaxis
    //            break;
    //        case 4:
    //            errA = 1 - Math.Abs(Vector3.Dot(pmedCylinder.transform.up, hmedCylinder.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(pmedCylinder.transform.forward, hmedCylinder.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(pmedCylinder.transform.right, hmedCylinder.transform.right)); //Xaxis
    //            break;
    //        case 5:
    //            errA = 1 - Math.Abs(Vector3.Dot(pmedTwoPin.transform.up, hmedTwoPin.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(pmedTwoPin.transform.forward, hmedTwoPin.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(pmedTwoPin.transform.right, hmedTwoPin.transform.right)); //Xaxis
    //            break;
    //        case 6:
    //            errA = 1 - Math.Abs(Vector3.Dot(pmedShaftKey.transform.up, hmedShaftKey.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(pmedShaftKey.transform.forward, hmedShaftKey.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(pmedShaftKey.transform.right, hmedShaftKey.transform.right)); //Xaxis
    //            break;
    //        case 7:
    //            errA = 1 - Math.Abs(Vector3.Dot(pmedThreePin.transform.up, hmedThreePin.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(pmedThreePin.transform.forward, hmedThreePin.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(pmedThreePin.transform.right, hmedThreePin.transform.right)); //Xaxis
    //            break;
    //        case 8:
    //            errA = 1 - Math.Abs(Vector3.Dot(plargeCylinder.transform.up, hlargeCylinder.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(plargeCylinder.transform.forward, hlargeCylinder.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(plargeCylinder.transform.right, hlargeCylinder.transform.right)); //Xaxis
    //            break;
    //        case 9:
    //            errA = 1 - Math.Abs(Vector3.Dot(plargeTwoPin.transform.up, hlargeTwoPin.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(plargeTwoPin.transform.forward, hlargeTwoPin.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(plargeTwoPin.transform.right, hlargeTwoPin.transform.right)); //Xaxis
    //            break;
    //        case 10:
    //            errA = 1 - Math.Abs(Vector3.Dot(plargeShaftKey.transform.up, hlargeShaftKey.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(plargeShaftKey.transform.forward, hlargeShaftKey.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(plargeShaftKey.transform.right, hlargeShaftKey.transform.right)); //Xaxis
    //            break;
    //        case 11:
    //            errA = 1 - Math.Abs(Vector3.Dot(plargeThreePin.transform.up, hlargeThreePin.transform.up)); //Yaxis
    //            errB = 1 - Math.Abs(Vector3.Dot(plargeThreePin.transform.forward, hlargeThreePin.transform.forward)); //Zaxis
    //            errC = 1 - Math.Abs(Vector3.Dot(plargeThreePin.transform.right, hlargeThreePin.transform.right)); //Xaxis
    //            break;
    //    }
    //}

    //private void ComputeError()
    //{
    //    //ComputeRMS();
    //    ComputeAlignment();
    //}
    
    private void KeyBoardInputs() //List Down All Keyboard Inputs for Peforming Various Actions
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (IsRecording && IsRendering)
            {
                SaveLog();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space)) { IsRendering = true; }
        else if (Input.GetKeyUp(KeyCode.R)) { Reset(); }
        else if (Input.GetKeyUp(KeyCode.Alpha0)) { if (IsRendering) { randNum = 0; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Alpha1)) { if (IsRendering) { randNum = 1; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) { if (IsRendering) { randNum = 2; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Alpha3)) { if (IsRendering) { randNum = 3; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Alpha4)) { if (IsRendering) { randNum = 4; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Alpha5)) { if (IsRendering) { randNum = 5; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Alpha6)) { if (IsRendering) { randNum = 6; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Alpha7)) { if (IsRendering) { randNum = 7; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Alpha8)) { if (IsRendering) { randNum = 8; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Alpha9)) { if (IsRendering) { randNum = 9; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.Q)) { if (IsRendering) { randNum = 10; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.W)) { if (IsRendering) { randNum = 11; GetRand(randNum); } }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (IsRendering)
            {
                phyholeTraj.Clear();
                phypegTraj.Clear();
                pegAngle.Clear();
                holeAngle.Clear();

                headTraj.Clear();
                headAngle.Clear();

                rightWristTraj.Clear();
                rightWristAngle.Clear();
                rightElbowTraj.Clear();
                rightElbowAngle.Clear();
                rightShoulderTraj.Clear();
                rightShoulderAngle.Clear();

                leftWristTraj.Clear();
                leftWristAngle.Clear();
                leftElbowTraj.Clear();
                leftElbowAngle.Clear();
                leftShoulderTraj.Clear();
                leftShoulderAngle.Clear();

                timeElapsed.Clear();
                IsRecording = true;
                timeStart = Time.time;
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (IsRecording && IsRendering)
            {
                //IsRecording = false;
                SaveLog();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            //if (IsRecording && randNum != -1)
            //{
            //    SaveLog();
            //    phyholeTraj.Clear();
            //    holeTraj.Clear();
            //    phypegTraj.Clear();
            //    pegTraj.Clear();
            //    holeNormTraj.Clear();
            //    pegNormTraj.Clear();
            //}
            Application.Quit();
        }
        }

    private void SaveLog() //Here Write All Data to a file for data analysis
    {
        IsRecording = false;
        //timeStop = Time.time;
        //totalTime = timeStop - timeStart;
        //Create File
        //string pathETC = Application.dataPath + "/FUser_" + userID + "_" + "ETC_" + shapeSize + shapeName + "_" + shapeCount + ".txt"; 
        string pathLog = Application.dataPath + "/FUser_" + userID + "_" + "Log_" + shapeSize + shapeName + "_" + shapeCount + ".txt"; 

        //Check if file exits, if not create one
        //if (!File.Exists(pathETC)) 
        //{
        //    File.WriteAllText(pathETC,"");
        //}
        //Add File Content
        //string Error = errA.ToString() + " " + errB.ToString() + " " + errC.ToString() + "\n";
        //string time = totalTime.ToString();
        //string colCount = shapeCollision.ToString();
        //string ETC = Error + time; //colCount;
        //File.AppendAllText(pathETC, ETC);

        if (!File.Exists(pathLog))
        {
            File.WriteAllText(pathLog, "");
        }
        //List<string> data = new List<string>();
        for (int i = 0; i < timeElapsed.Count; i++)
        {
            string data = timeElapsed[i]
                + " " + 50*phypegTraj[i].x + " " + 50 * phypegTraj[i].y + " " + 50 * phypegTraj[i].z
                + " " + pegAngle[i].x + " " + pegAngle[i].y + " " + pegAngle[i].z
                + " " + 50 * phyholeTraj[i].x + " " + 50 * phyholeTraj[i].y + " " + 50 * phyholeTraj[i].z                
                + " " + holeAngle[i].x + " " + holeAngle[i].y + " " + holeAngle[i].z
                + " " + 50 * headTraj[i].x + " " + 50 * headTraj[i].y + " " + 50 * headTraj[i].z
                + " " + headAngle[i].x + " " + headAngle[i].y + " " + headAngle[i].z
                + " " + 50 * rightWristTraj[i].x + " " + 50 * rightWristTraj[i].y + " " + 50 * rightWristTraj[i].z
                + " " + rightWristAngle[i].x + " " + rightWristAngle[i].y + " " + rightWristAngle[i].z
                + " " + 50 * leftWristTraj[i].x + " " + 50 * leftWristTraj[i].y + " " + 50 * leftWristTraj[i].z
                + " " + leftWristAngle[i].x + " " + leftWristAngle[i].y + " " + leftWristAngle[i].z
                + " " + 50 * rightElbowTraj[i].x + " " + 50 * rightElbowTraj[i].y + " " + 50 * rightElbowTraj[i].z
                + " " + rightElbowAngle[i].x + " " + rightElbowAngle[i].y + " " + rightElbowAngle[i].z
                + " " + 50 * leftElbowTraj[i].x + " " + 50 * leftElbowTraj[i].y + " " + 50 * leftElbowTraj[i].z
                + " " + leftElbowAngle[i].x + " " + leftElbowAngle[i].y + " " + leftElbowAngle[i].z
                + " " + 50 * rightShoulderTraj[i].x + " " + 50 * rightShoulderTraj[i].y + " " + 50 * rightShoulderTraj[i].z
                + " " + rightShoulderAngle[i].x + " " + rightShoulderAngle[i].y + " " + rightShoulderAngle[i].z
                + " " + 50 * leftShoulderTraj[i].x + " " + 50 * leftShoulderTraj[i].y + " " + 50 * leftShoulderTraj[i].z
                + " " + leftShoulderAngle[i].x + " " + leftShoulderAngle[i].y + " " + leftShoulderAngle[i].z
                + "\n";
            File.AppendAllText(pathLog, data);
        }

        phyholeTraj.Clear();
        phypegTraj.Clear();
        pegAngle.Clear();
        holeAngle.Clear();

        headTraj.Clear();
        headAngle.Clear();

        rightWristTraj.Clear();
        rightWristAngle.Clear();
        rightElbowTraj.Clear();
        rightElbowAngle.Clear();
        rightShoulderTraj.Clear();
        rightShoulderAngle.Clear();

        leftWristTraj.Clear();
        leftWristAngle.Clear();
        leftElbowTraj.Clear();
        leftElbowAngle.Clear();
        leftShoulderTraj.Clear();
        leftShoulderAngle.Clear();

        timeElapsed.Clear();
        totalTime = 0;
        //shapeCount = 0;
    }

    private void Reset()
    {
        IsRecording = false;
        IsRendering = false;
        randNum = -1;
        totalTime = 0;

        //holeTraj.Clear();
        //pegTraj.Clear();
        //holeNormTraj.Clear();
        //pegNormTraj.Clear();
        phyholeTraj.Clear();
        phypegTraj.Clear();
        pegAngle.Clear();
        holeAngle.Clear();

        headTraj.Clear();
        headAngle.Clear();

        rightWristTraj.Clear();
        rightWristAngle.Clear();
        rightElbowTraj.Clear();
        rightElbowAngle.Clear();
        rightShoulderTraj.Clear();
        rightShoulderAngle.Clear();

        leftWristTraj.Clear();
        leftWristAngle.Clear();
        leftElbowTraj.Clear();
        leftElbowAngle.Clear();
        leftShoulderTraj.Clear();
        leftShoulderAngle.Clear();

        timeElapsed.Clear();

        gameObject.SetActive(false);

        scountCylinder = scountShaftKey = scountTwoPin = scountThreePin = 0;
        mcountCylinder = mcountShaftKey = mcountTwoPin = mcountThreePin = 0;
        lcountCylinder = lcountShaftKey = lcountTwoPin = lcountThreePin = 0;
    }

    float _AxisAngle(ref float[] axis, ref float angle, ref float[] matrix)
    {

        float c = Mathf.Cos(angle);
        float s = Mathf.Sin(angle);
        float t = 1 - c;
        float x = axis[0];
        float y = axis[1];
        float z = axis[2];

        matrix[0] = t * x * x + c;
        matrix[1] = t * x * y - z * s;
        matrix[2] = t * x * z + y * s;
        matrix[3] = t * x * y + z * s;
        matrix[4] = t * y * y + c;
        matrix[5] = t * y * z - x * s;
        matrix[6] = t * x * z - y * s;
        matrix[7] = t * y * z + x * s;
        matrix[8] = t * z * z + c;

        return 1;
    }

    bool _RotateVec3(ref float[] v, ref float[] matrix)
    {
        float[] t_v = new float[3];
        t_v[0] = matrix[0] * v[0] + matrix[1] * v[1] + matrix[2] * v[2];
        t_v[1] = matrix[3] * v[0] + matrix[4] * v[1] + matrix[5] * v[2];
        t_v[2] = matrix[6] * v[0] + matrix[7] * v[1] + matrix[8] * v[2];

        v[0] = t_v[0];
        v[1] = t_v[1];
        v[2] = t_v[2];

        return true;
    }


    }
