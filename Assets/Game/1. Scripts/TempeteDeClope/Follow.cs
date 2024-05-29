using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform player;
    public float xPos = 0f;
    public float yPos = 4f;
    public float zPos = -15f;

    void LateUpdate () {
        transform.position = player.transform.position + new Vector3(xPos, yPos, zPos);
    }
}