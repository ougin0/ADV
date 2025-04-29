using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // ارفع هنا Transform اللاعب من الإديتور
    public float speed = 3f;
    public float rotationSpeed = 5f;

    void Update()
    {
        if (player == null)
            return;

        // الحصول على اتجاه الحركة نحو اللاعب
        Vector2 direction = player.position - transform.position;
        direction.Normalize();

        // التحرك نحو اللاعب
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // (اختياري) تدوير العدو نحو اللاعب
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}