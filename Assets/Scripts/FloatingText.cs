using TMPro;
using UnityEngine;

public class FloatingText
{
    public bool active;
    public GameObject go;
    public TMP_Text message;
    public Vector3 motion;
    public float duration;
    public float lastShown;


    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFlotingText()
    {
        if (!active)
            return;

        if (Time.time - lastShown > duration)
            Hide();

        go.transform.position += motion * Time.deltaTime;
    }
}
