using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject playerObject;
    public Vector3 cameraOffset = new Vector3(0.29f, 10.35f, -15f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerObject.transform.position + cameraOffset;
    }
}
