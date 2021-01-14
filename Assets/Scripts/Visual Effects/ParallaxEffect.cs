using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    public GameObject follow;

    private Vector3 lastCameraPosition;
    private Transform cameraTransform;
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    

    void Start()
    {
        cameraTransform = follow.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
    }
}
