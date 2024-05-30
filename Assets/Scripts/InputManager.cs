using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 m_cursorWorldPosition;
    [SerializeField] Transform m_slicer;
    private Camera m_mainCamera;
    void Start()
    {
        m_mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        m_cursorWorldPosition = m_mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -m_mainCamera.transform.position.z));
        m_slicer.position = m_cursorWorldPosition;
    }
    
}
