using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{
    [SerializeField] private float m_fruitsSpawningDelay;
    [SerializeField] private List<GameObject> m_fruitsSpawningObjects;
    [SerializeField] private List<Transform> m_fruitsSpawningPositions;
    [SerializeField] private float m_force;
    [SerializeField] Transform m_fruitContainer;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_fruitsSpawningDelay);
            int m_fruitIndex = Random.Range(0, m_fruitsSpawningObjects.Count);
            int m_fruitPositionIndex = Random.Range(0, m_fruitsSpawningPositions.Count);
            GameObject m_newFruit = Instantiate(m_fruitsSpawningObjects[m_fruitIndex], m_fruitContainer);
            m_newFruit.transform.position  = m_fruitsSpawningPositions[m_fruitPositionIndex].transform.position;
            m_newFruit.GetComponent<Rigidbody>().AddForce(m_fruitsSpawningPositions[m_fruitPositionIndex].transform.up * m_force,ForceMode.Impulse);
            
            
            m_newFruit.GetComponent<Rigidbody>().AddTorque(new Vector3(1, 0, 1) * m_force, ForceMode.Impulse);
            m_newFruit.GetComponent<FruitsController>().m_spawnerFruit = m_fruitsSpawningPositions[m_fruitPositionIndex].transform;
        }
        
    }
}
