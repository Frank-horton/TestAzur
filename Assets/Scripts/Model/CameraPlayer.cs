using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    Transform _MyTransform;
    float MovementX, MovementY, MovementZ;

    public Transform Target;
    public float Offset_X, Offset_Y, Offset_Z;
    public float PlayerVelocity;

    void Start()
    {
        _MyTransform = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        MovementX = ((Target.transform.position.x + Offset_X - _MyTransform.position.x));
        MovementY = ((Target.transform.position.y + Offset_Y - _MyTransform.position.y));
        MovementZ = ((Target.transform.position.z + Offset_Z - _MyTransform.position.z));
        _MyTransform.position += new Vector3((MovementX * PlayerVelocity * Time.deltaTime), (MovementY * PlayerVelocity * Time.deltaTime), (MovementZ * PlayerVelocity * Time.deltaTime));
    }

}