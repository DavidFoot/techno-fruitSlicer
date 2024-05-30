using EzySlice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    [SerializeField] private Material m_defaultMaterial;
    [SerializeField] private GameObject m_modelFruit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slice(Vector3 _position,Vector3 _normal)
    {
        SlicedHull sliceHullData = m_modelFruit.Slice(_position, _normal);

        GameObject lowerHull = sliceHullData.CreateLowerHull(m_modelFruit, m_defaultMaterial);
        GameObject upperHull = sliceHullData.CreateUpperHull(m_modelFruit, m_defaultMaterial);

        Destroy(gameObject);
        //slicable.SetupLowerHull(lowerHull);
        //slicable.SetupUpperHull(upperHull);

        //slicable.Finish();
    }
}
