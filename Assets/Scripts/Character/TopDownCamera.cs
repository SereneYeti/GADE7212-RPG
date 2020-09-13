using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;

    [System.Serializable]
    public class PositionSettings
    {
        //distancefrom our target
        //bools for zooming and smoothfollowing
        //MinAttribute & max zoom settings
        public float distanceFromTarget = -20;
        public bool allowZoom = true;
        public float zoomSmooth = 100;
        public float zoomStep = 2;
        public float maxZoom = -10;
        public float minZoom = -30;
        public bool smoothFollow = true;
        public float smooth = 0.05f;

        [HideInInspector]
        public float newDistance = -30;  //used for smooth zooming -- gives us a "destination zoom"
    }

    [System.Serializable]
    public class OrbitSettings
    {
        //Current x& Y rotation
        //Bool to allow orbit
        public float xRotation = -65;
        public float yRoation = -180;
        public float yOrbitSmooth = 0.05f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public string MOUSE_ORBIT = "MouseOrbit";
        public string ZOOM = "Mouse ScrollWheel";
    }

    public PositionSettings position = new PositionSettings();
    public OrbitSettings orbit = new OrbitSettings();
    public InputSettings input = new InputSettings();

    Vector3 destination = Vector3.zero;
    Vector3 camVelocity = Vector3.zero;
    //Vector3 currentMousePosition = Vector3.zero;
    //Vector3 previousMousePosition = Vector3.zero;
    float yOrbitInput, mouseOrbitInput, zoomInput;

    private void Start()
    {
        //Setting camera target
        SetCameraTargert(target);

        if(target)
        {
            MoveToTarget();
        }
    }
    public void SetCameraTargert(Transform t)
    {
        //If we want a new target at runtime
        target = t;

        if(target == null)
        {
            Debug.LogError("Your Camera needs a target.");
        }
    }
    void GetInput()
    {
        //Filling the values for ou input variables
        zoomInput = Input.GetAxisRaw(input.ZOOM);
        // mouseOrbitInput = Input.GetAxisRaw(input.MOUSE_ORBIT)     
                
    }
    private void Update()
    {
        //movetotarget
        //lookattarget
        //getting input and zooming
        GetInput();
        if (position.allowZoom)
        {
            ZoomInOnTarget();
        }
        if (target)
        {
            MoveToTarget();
            LookAtTarget();
        }
    }
    
    void MoveToTarget()
    {
        //handleing gettting our camera to its destination position
        destination = target.position;
        destination += Quaternion.Euler(orbit.xRotation, orbit.yRoation, 0)*-Vector3.forward*position.distanceFromTarget;

        if(position.smoothFollow)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref camVelocity, position.smooth);
        }
        else
        {
            transform.position = destination;
        }
    }

    void LookAtTarget()
    {
        //handles getting camera to look at target at all times
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = targetRotation;
    }

    void MouseOrbitTarget()
    {
        //getting camera to orbit around character
        //previousMousePosition = currentMousePosition;
        //currentMousePosition = Input.mousePosition;

        //if(mouseOrbitInput > 0)
        //{
        //    orbit.yRoation += (currentMousePosition.x - previousMousePosition.x) * orbit.yOrbitSmooth;
        //}
    }

    void ZoomInOnTarget()
    {
       // moddifying the distance from target to be closer or further away
        position.newDistance += position.zoomStep * zoomInput;

        position.distanceFromTarget = Mathf.Lerp(position.distanceFromTarget, position.newDistance, position.zoomSmooth * Time.deltaTime);

        if (position.distanceFromTarget > position.maxZoom)
        {
            position.distanceFromTarget = position.maxZoom;
            position.newDistance = position.maxZoom;
        }
        if (position.distanceFromTarget < position.minZoom)
        {
            position.distanceFromTarget = position.minZoom;
            position.newDistance = position.minZoom;
        }
    }

}
