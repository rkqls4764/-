using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public float distanceY = 1.0f;

    Vector3 targetPos;

    void Update()
    {
        targetPos.Set(this.transform.position.x, target.transform.position.y + distanceY, this.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
