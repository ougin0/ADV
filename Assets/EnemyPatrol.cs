using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("إعدادات الحركة")]
    public float speed = 3f; // سرعة الحركة
    public Transform pointA; // نقطة البداية
    public Transform pointB; // نقطة النهاية
    public bool flipSprite = true; // قلب الصورة عند تغيير الاتجاه

    private Transform currentTarget;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentTarget = pointA;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // الحركة نحو الهدف الحالي
        transform.position = Vector2.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime
        );

        // التحقق من الوصول إلى الهدف
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            // تغيير الهدف
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
            
            // قلب الصورة إذا مفعل
            if (flipSprite)
                spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    // رسم نقاط المسار في المحرر (للتسهيل)
    void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawWireSphere(pointA.position, 0.2f);
            Gizmos.DrawWireSphere(pointB.position, 0.2f);
        }
    }

public class ExampleScript : MonoBehaviour
{
    public float newSpeed = 12f; // السرعة الجديدة

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float speed = newSpeed;
        }
    }
}
}