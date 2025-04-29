using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTeleporter : MonoBehaviour
{
    public string targetSceneName; // اسم المشهد التالي
    public float delayTime = 2f; // وقت التأخير قبل النقل
    public GameObject loadingText; // نص تحميل (اختياري)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadSceneAfterDelay());
            Destroy(other.gameObject);
        }
    }

    IEnumerator LoadSceneAfterDelay()
    {
        // إظهار نص التحميل (إذا موجود)
        if (loadingText != null)
            loadingText.SetActive(true);

        // انتظر لمدة محددة
        yield return new WaitForSeconds(delayTime);

        // تحميل المشهد الجديد
        SceneManager.LoadScene(targetSceneName);
    }
}