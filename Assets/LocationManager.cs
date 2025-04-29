using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationManager : MonoBehaviour
{
    public static LocationManager Instance; 

    public List<GameObject> locations = new List<GameObject>();
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.gray;

    // جعل المتغير public أو استخدام خاصية (Property)
    public GameObject currentTarget { get; private set; } // <-- التصحيح هنا

    private List<GameObject> remainingLocations = new List<GameObject>();
    private int targetsVisited = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        remainingLocations = new List<GameObject>(locations);
        SetNewRandomTarget(); // <-- تأكد من وجود الدالة
    }

    // تعريف دالة SetNewRandomTarget بشكل صحيح
    public void SetNewRandomTarget()
    {
        if (currentTarget != null)
        {
            currentTarget.GetComponent<SpriteRenderer>().color = inactiveColor;
        }

        if (remainingLocations.Count == 0)
        {
            remainingLocations = new List<GameObject>(locations);
        }

        int randomIndex = Random.Range(0, remainingLocations.Count);
        currentTarget = remainingLocations[randomIndex];
        remainingLocations.RemoveAt(randomIndex);

        currentTarget.GetComponent<SpriteRenderer>().color = activeColor;
        targetsVisited++;

        if (targetsVisited >= 5)
        {
            SceneManager.LoadScene("WIN");
        }
    }

    // تعريف دالة LocationTriggered
    public void LocationTriggered(GameObject triggeredLocation)
    {
        if (triggeredLocation == currentTarget)
        {
            SetNewRandomTarget();
        }
    }
}