using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookatCursor();
    }

    /// <summary>
    /// Use raycast to handle hit target
    /// </summary>
    void LookatCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //tia duong thang vuong goc voi man hinh
        RaycastHit hit;// vat the ma ray dung phai

        if(Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }

        transform.LookAt(target);
    }



}
