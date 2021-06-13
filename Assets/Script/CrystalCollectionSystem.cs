using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrystalCollectionSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer dim1, dim2;
    [SerializeField] private Image blackPanel;
    [SerializeField] private Text byeText;
    public void ShowCrystal(int count)
    {
        StartCoroutine(Show(count));
    }

    private IEnumerator Show(int count)
    {
        switch (count)
        {
            case 1:
                yield return new WaitForSeconds(1f);
                dim1.sortingLayerName="Location";
                break;
            case 2:
                yield return new WaitForSeconds(1f);
                dim1.sortingLayerName="Location";
                yield return new WaitForSeconds(1);
                dim2.sortingLayerName="Location";
                break;
        }
        yield return new WaitForSeconds(1f);
        for (float a = 0; a < 1; a += Time.deltaTime)
        {
            blackPanel.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        for (float a = 0; a < 1; a += Time.deltaTime)
        {
            byeText.color = new Color(1, 1, 1, a);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        for (float a = 1; a >= 0; a -= Time.deltaTime)
        {
            byeText.color = new Color(1, 1, 1, a);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("menu");
    }
}
