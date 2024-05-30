using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlashDetector : MonoBehaviour
{
    private Vector3 m_moveDirection;
    private float m_speed;
    private Vector3 m_normal;

    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(GetMoveDirectionCoroutine());
    }
    private IEnumerator GetMoveDirectionCoroutine()
    {
        while (true)
        {
            var lastposition = transform.position;
            yield return new WaitForSeconds(0.1f);
            var currentPosition = transform.position;
            Vector3 rawDirec = currentPosition - lastposition;
            m_moveDirection = Vector3.Normalize(rawDirec);
            m_speed = rawDirec.magnitude;
            m_normal = Vector3.Cross(Vector3.back, m_moveDirection);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + m_moveDirection*m_speed*100);
    }
    private void OnTriggerEnter(Collider _fruit)
    {
        var gameObjectToBeSlice = _fruit.gameObject;
        Debug.Log(gameObjectToBeSlice.name);
        gameObjectToBeSlice.GetComponent<FruitsController>().Slice(transform.position,m_normal);
    }
}
