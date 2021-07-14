using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool Active = true;
    public bool TimeToDie = false;
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
        if (TimeToDie == true)
            Destroy(gameObject);
    }
    Quaternion GetTargetRotation()
    {
        var rotation = Active ? Vector3.zero : (Vector3.up * 180f);
        return Quaternion.Euler(rotation);
    }
    private void OnMouseDown()
    {
        var board = FindObjectOfType<Board>();
        if (board.CanMove == false)
            return;
        Active = !Active;
        board.CheckPair();
         
    }
}
