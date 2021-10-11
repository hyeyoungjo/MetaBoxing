using UnityEngine;

namespace MetaBoxing
{
    public class BodyLookAt : MonoBehaviour
    {
        public Transform head;

        public void Start()
        {
            head = GameObject.Find("HeadTarget").transform;
        }
        
        private void Update()
        {
            var dir = head.position - transform.position;

            var projZ = Vector3.ProjectOnPlane(dir, Vector3.forward);
            var projX = Vector3.ProjectOnPlane(dir, Vector3.right);
            var rotZ = Vector3.SignedAngle(Vector3.up, projZ, Vector3.forward);
            var rotX = Vector3.SignedAngle(Vector3.up, projX, Vector3.right);

            transform.rotation = Quaternion.Euler(rotX, 0, rotZ);
        }
    }
}