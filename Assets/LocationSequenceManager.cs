using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationSequenceManager : MonoBehaviour
{
    public static LocationSequenceManager Instance;

    public List<GameObject> locations = new List<GameObject>(); // قائمة الأماكن
    public Color activeColor = Color.green; // لون المكان النشط
    public Color inactiveColor = Color.white; // لون الأماكن غير النشطة

    private List<GameObject> remainingLocations = new List<GameObject>();
    private GameObject currentNextTarget; // الهدف الحالي الذي يجب الوصول إليه
    private int targetCount = 4; // عدد الأماكن المطلوبة (يمكن تعديله)

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        remainingLocations = new List<GameObject>(locations);
        ResetAllColors();
        SetNextRandomTarget(); // تحديد أول هدف عشوائي
    }

    void ResetAllColors()
    {
        foreach (var loc in locations)
        {
            SpriteRenderer renderer = loc.GetComponent<SpriteRenderer>();
            if (renderer != null)
                renderer.color = inactiveColor;
        }
    }

    // يتم استدعاؤها عند دخول المكان النشط
    public void OnLocationEntered(GameObject enteredLocation)
    {
        if (enteredLocation == currentNextTarget)
        {
            remainingLocations.Remove(enteredLocation); // إزالة المكان من القائمة

            // إذا تمت زيارة جميع الأماكن
            if (remainingLocations.Count == locations.Count - targetCount)
            {
                SceneManager.LoadScene("Scene2"); // الانتقال إلى السينما الجديدة
                return;
            }

            SetNextRandomTarget(); // تحديد الهدف التالي
        }
    }

    void SetNextRandomTarget()
    {
        // إعادة لون الهدف السابق
        if (currentNextTarget != null)
        {
            SpriteRenderer previousRenderer = currentNextTarget.GetComponent<SpriteRenderer>();
            if (previousRenderer != null)
                previousRenderer.color = inactiveColor;
        }

        // اختيار هدف جديد عشوائيًا من المتبقي
        GameObject nextTarget = remainingLocations[Random.Range(0, remainingLocations.Count)];
        currentNextTarget = nextTarget;

        // تفعيل لون الهدف الجديد
        SpriteRenderer nextRenderer = nextTarget.GetComponent<SpriteRenderer>();
        if (nextRenderer != null)
            nextRenderer.color = activeColor;

        Debug.Log("الهدف الحالي: " + nextTarget.name);
    }
}