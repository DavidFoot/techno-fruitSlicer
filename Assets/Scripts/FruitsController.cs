using EzySlice;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    [SerializeField] public Transform m_spawnerFruit;
    [SerializeField] public Material m_placeHolderMaterial;
    [SerializeField] public GameObject m_fruits;
    private Transform m_fruitPosition;
    // Start is called before the first frame update
    void Start()
    {
        m_fruitPosition = GetComponent<Transform>();
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
        
        upCollider.enabled = true;
        upCollider.convex = true;

        var rbl = lowerHull.AddComponent<Rigidbody>();
        var rbu = upperHull.AddComponent<Rigidbody>();

        rbl.AddExplosionForce(300, rbl.position, 5, 0f);
        rbu.AddExplosionForce(300, rbl.position, 5, 0f);

        rbl.AddTorque(new Vector3(0,10,1));
        rbu.AddTorque(new Vector3(0, 10, 1));

        var fruitLower = lowerHull.AddComponent<FruitsController>();
        var fruitUpper = upperHull.AddComponent<FruitsController>();

        fruitLower.m_spawnerFruit = m_spawnerFruit;
        fruitUpper.m_spawnerFruit = m_spawnerFruit;

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
