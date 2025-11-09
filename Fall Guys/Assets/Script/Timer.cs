using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField] 
    private bool autoStart = false;
    [SerializeField] 
    private bool useUnscaledTime = false;

    private float elapsedSeconds = 0f;
    private bool timerRunning = false;

    private void Awake()
    {
        // Fallback if not set in the Inspector
        if (timerText == null)
            timerText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (autoStart)
        {
            StartTimer(true);
        }
        else
        {
            UpdateText(0f);
        }
    }

    private void Update()
    {
        if (!timerRunning)
            return;

        elapsedSeconds += useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        UpdateText(elapsedSeconds);
    }

    public void StartTimer(bool reset = false)
    {
        if (reset)
            elapsedSeconds = 0f;

        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void ResetTimer()
    {
        elapsedSeconds = 0f;
        UpdateText(0f);
    }

    public float GetElapsedTime()
    {
        return elapsedSeconds;
    }

    private void UpdateText(float seconds)
    {
        if (timerText == null)
            return;

        int minutes = Mathf.FloorToInt(seconds / 60f);
        int secs = Mathf.FloorToInt(seconds % 60f);
        timerText.text = $"Time: {minutes:00}:{secs:00}";
    }
}
