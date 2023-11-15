using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincessBehaviourScript : MonoBehaviour
{
    [SerializeField]
    GameObject characterToReact;

    [SerializeField]
    TMP_FontAsset fontForHits;

    [SerializeField]
    string victoryScene;

    [SerializeField]
    float delay = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == characterToReact)
        {
            var go = new GameObject();
            go.name = $"PrincezninaHlaska";
            //go2.transform.parent = oponent.transform;
            go.transform.position = new Vector2(transform.position.x, transform.position.y + 1);

            var text = go.AddComponent<TextMeshPro>();

            //text.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf"); //pro UI.Text
            //text.font = Resources.Load<TMP_FontAsset>("Gilam-BlackDEMO SDF");
            /*Font font = Resources.Load<Font>("Gilam-BlackDEMO.otf");
            TMP_FontAsset asset = TMP_FontAsset.CreateFontAsset(font);*/
            if (fontForHits != null)
                text.font = fontForHits;
            text.fontSize = 4.5f;
            /*text.enableAutoSizing = true;
            text.fontSizeMin = 5;
            text.fontSizeMax = 5;*/

            text.enableWordWrapping = false;

            text.alignment = TextAlignmentOptions.Center;

            text.text = "No, to byla doba!";
            text.color = Color.cyan;

            text.renderer.sortingLayerName = "UI";
            text.rectTransform.sizeDelta = new Vector2(2, 2);

            Rigidbody2D rb2D = go.AddComponent<Rigidbody2D>();
            rb2D.isKinematic = true;
            rb2D.velocity = new Vector2(0, 1);

            GameObject.Destroy(go, 2);


            StartCoroutine(nameof(LoadSceneAfterSecond));
        }

    }

    private IEnumerator LoadSceneAfterSecond()
    {
        if (string.IsNullOrEmpty(victoryScene) == false)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(victoryScene);
        }
    }


}
