using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen; // ��������� ��� ������ ������ ������������

    // ��������� �� ���������� ������
    public GameObject dot_1;
    public GameObject dot_2;
    public GameObject dot_3;
    private void Start()
    {
        StartCoroutine(AnimateDots());
    }
    IEnumerator AnimateDots()
    // ����� ��� ���������
    {
        // ������� ��� � ��
        Time.timeScale = 0f; 

        for(int i = 0; i < 3; i++)
        {
            // ��������� ������
            dot_1.transform.localScale =
                new Vector3(2f,2f,2f);
            // �������� � 1 �������
            yield return new WaitForSecondsRealtime(1f);
            // ��������� ������
            dot_1.transform.localScale =
                new Vector3(1f, 1f, 1f);

            dot_2.transform.localScale =
                new Vector3(2f, 2f, 2f);
            yield return new WaitForSecondsRealtime(1f);
            dot_2.transform.localScale =
                new Vector3(1f, 1f, 1f);

            dot_3.transform.localScale =
                new Vector3(2f, 2f, 2f);
            yield return new WaitForSecondsRealtime(1f);
            dot_3.transform.localScale =
                new Vector3(1f, 1f, 1f);
        }
        loadingScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
