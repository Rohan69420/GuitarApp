using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return;

        UnityEngine.Debug.Log(rayHit.collider.gameObject.name);
        //UnityEngine.Debug.Log(transform.parent.rayHit.collider.gameObject);

        GameObject obj;

        obj = rayHit.collider.gameObject;

        var ParentGameObj = obj.transform.parent.gameObject;

        UnityEngine.Debug.Log(ParentGameObj.name);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
