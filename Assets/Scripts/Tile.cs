using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool Active = true;
    public Sprite BackFace;
    void Start()
    {
        transform.rotation = GetTargetRotation();
        var BackObject = transform.Find("Back");
        var spriteRenderer = BackObject.transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = BackFace;
    }

    
    void Update()
    {
        var TargetRotation = GetTargetRotation();
        transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * 5f);
    }
    Quaternion GetTargetRotation()
    {
        var rotation = Active ? Vector3.zero : (Vector3.up * 180f);
        return Quaternion.Euler(rotation);
    }
}
