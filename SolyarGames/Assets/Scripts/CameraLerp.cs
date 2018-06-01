using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraLerp : MonoBehaviour {
    Camera MyCamera;
    public Transform Target;
    public float LerpSpeed;
    private Vector3 Offset;
    private Transform _transform;
    private void Awake()
    {
        _transform = transform;
        MyCamera = GetComponent<Camera>();
        Offset = _transform.position - Target.position;
    }
    private void Update()
    {
        _transform.position = Vector3.Lerp(_transform.position, Target.position + Offset, LerpSpeed * Time.deltaTime);
    }
}
