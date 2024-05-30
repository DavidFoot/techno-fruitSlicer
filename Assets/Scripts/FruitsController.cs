using EzySlice;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    [SerializeField] public Transform m_spawnerFruit;
    [SerializeField] public Transform m_container;
    [SerializeField] public Material m_placeHolderMaterial;
    [SerializeField] public GameObject m_fruits;
    private Transform m_fruitPosition;
    // Start is called before the first frame update
    void Start()
    {
        m_fruitPosition = GetComponent<Transform>();
        m_container = transform.parent.GetComponent<Transform>();
    }

    public void Slice(Vector3 _position, Vector3 _normal)
    {
        Debug.Log("SlicedFruits");
        SlicedHull sliceHullData = gameObject.Slice(_position, _normal);
        GameObject lowerHull = sliceHullData.CreateLowerHull(gameObject, m_placeHolderMaterial);
        GameObject upperHull = sliceHullData.CreateUpperHull(gameObject, m_placeHolderMaterial);

        var lowerCollider = lowerHull.AddComponent<MeshCollider>();
        var upCollider = upperHull.AddComponent<MeshCollider>();


        lowerCollider.enabled = true;
        lowerCollider.convex = true; 
        lowerCollider.isTrigger = true;
        
        upCollider.enabled = true;
        upCollider.convex = true;
        upCollider.isTrigger = true;

        var rbl = lowerHull.AddComponent<Rigidbody>();
        var rbu = upperHull.AddComponent<Rigidbody>();

        rbl.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
        rbu.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

        rbl.AddExplosionForce(300, rbl.position, 5, 0f);
        rbu.AddExplosionForce(300, rbl.position, 5, 0f);

        rbl.AddTorque(new Vector3(0,10,1));
        rbu.AddTorque(new Vector3(0, 10, 1));

        var fruitLower = lowerHull.AddComponent<FruitsController>();
        var fruitUpper = upperHull.AddComponent<FruitsController>();

        //Utile pour le Destroy
        fruitLower.m_spawnerFruit = m_spawnerFruit;
        fruitUpper.m_spawnerFruit = m_spawnerFruit;

        upperHull.transform.parent = m_container;
        lowerHull.transform.parent = m_container;


        upperHull.transform.position = transform.position;
        lowerHull.transform.position = transform.position;

        fruitLower.m_placeHolderMaterial = m_placeHolderMaterial;
        fruitUpper.m_placeHolderMaterial = m_placeHolderMaterial;
        Destroy(gameObject);
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
