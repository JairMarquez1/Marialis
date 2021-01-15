using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsEffect : MonoBehaviour
{
    public float speedRotation = 0.1f;
    public Light generalLight;
    public float dayTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        dayTime = Mathf.Clamp(Mathf.Abs(transform.rotation.z) * 10 - 1, 1,8);
        generalLight.intensity = dayTime;
        transform.Rotate(new Vector3(0, 0, 0.1f) * speedRotation);
    }

}