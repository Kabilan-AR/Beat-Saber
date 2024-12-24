using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using EzySlice;
using Unity.VisualScripting;

public class CubeSlicer : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public LayerMask layer;
    public VelocityEstimator VelocityEstimator;
    public Material crossSectionMaterial;
    public float explosionForce = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

void FixedUpdate()
    {
       

 
  
        bool hasHit = Physics.Linecast(startSlicePoint.transform.position, endSlicePoint.transform.position, out RaycastHit hit, layer);

        if (hasHit)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Vector3 hitPosition = hit.point;
            GameObject target = hit.transform.gameObject;
            slice(target,hitPosition);
        }
    }

    public void slice(GameObject target,Vector3 Pos)
    {
        Vector3 velocity = VelocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position,velocity);
        planeNormal.Normalize();
       // SlicedHull hull = target.Slice(Pos, planeNormal);
        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);
        if (hull!= null )
        {
            GameObject upperhull = hull.CreateUpperHull(target,crossSectionMaterial);
            sliceSetup(upperhull);
            GameObject lowerhull= hull.CreateLowerHull(target,crossSectionMaterial);
            sliceSetup(lowerhull);
           

        }
        Destroy(target);

    }
    public void sliceSetup(GameObject slicedObject)
    {
        Rigidbody rb=slicedObject.AddComponent<Rigidbody>();
        MeshCollider mesh = slicedObject.AddComponent<MeshCollider>();
    mesh.convex = true;
        rb.AddExplosionForce(explosionForce, slicedObject.transform.position, 1);
    }
}
