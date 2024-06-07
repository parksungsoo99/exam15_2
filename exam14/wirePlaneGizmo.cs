using UnityEngine;

public class wirePlaneGizmo : MonoBehaviour
{
    public float size = 5.0f;
   void OnDrawGizmos(){
    
    Vector3 right  = transform.right * size;
    Vector3 forward = transform.forward * size;

    Vector3 topLeft =transform.position - right +forward;
    Vector3 topRight = transform.position +right + forward;
    Vector3 bottomLeft = transform.position - right -forward;
    Vector3 bottomRight = transform.position +right -forward;

    Gizmos.color= Color.yellow;
    Gizmos.DrawLine(topLeft,topRight);
    Gizmos.DrawLine(topRight,bottomRight);
    Gizmos.DrawLine(bottomRight,bottomLeft);
    Gizmos.DrawLine(bottomLeft,topLeft);

   }
}
