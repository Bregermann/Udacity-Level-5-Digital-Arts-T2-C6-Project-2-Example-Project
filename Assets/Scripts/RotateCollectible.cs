using UnityEngine;

public class RotateCollectible : MonoBehaviour
{
    public float rotationSpeed = 50f;     // Spin speed
    public float floatAmplitude = 0.25f;  // Height of the bob
    public float floatFrequency = 1f;     // Speed of the bob

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        // Rotate
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        // Bob up and down
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}