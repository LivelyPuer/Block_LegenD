using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraM : MonoBehaviour
{
    public Transform target;
    public float smooth = 2f;
    public Vector3 offset = new Vector3(0, 2, -5);
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);  
    }
    public void OnCursore()
    {
        Cursor.visible = true;
    }
    public void OffCursore()
    {
        Cursor.visible = false;
    }
}
