using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    [SerializeField] public Transform m_spawnerFruit;
    private Transform m_fruitPosition;
    // Start is called before the first frame update
    void Start()
    {
        m_fruitPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_fruitPosition.position.y < m_spawnerFruit.position.y) 
        {
           Destroy(gameObject);   
        }
    }
}
