using TMPro;
using UnityEngine;

public class TextFadeOut : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float displayDuration = 5f;

    private PlayerController player;
    private bool changed;

    private CanvasGroup canvasGroup;
    private float timer;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        canvasGroup.alpha = 1f;
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > displayDuration && canvasGroup.alpha > 0)
        {
            float alpha = Mathf.Lerp(1f, 0f, (timer - displayDuration) / fadeDuration);
            canvasGroup.alpha = alpha;

            //if (alpha <= 0f)
            //{
            //  Destroy(gameObject);
            //}
        }

        if (player.PowerBanks >= 4 && !changed)
        {

            GameObject.Find("Motivation").GetComponent<TMP_Text>().text = "\"Okay, found all of them. Now, I gotta return safely back to my ship.\"";
            canvasGroup.alpha = 1;
            timer = 0;
            changed = true;
        }
    }
}
