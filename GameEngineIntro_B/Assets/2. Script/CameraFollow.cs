using UnityEngine;

/// <summary>
/// ===| 카메라 움직임 |===
/// </summary>
public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// public | ==============================
    /// </summary>
    public Transform player;

    /// <summary>
    /// private | ==============================
    /// </summary>
    private float cameraOffset = -10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, cameraOffset); //플레이어 x값, 플레이어 y값, 카메라 -10값
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime); //매 프레임마다 카메라와 플레이어의 중앙값을 계산하여 카메라를 이동시킴.
    }
}
