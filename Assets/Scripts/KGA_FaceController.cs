using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class KGA_FaceController : MonoBehaviour
{
    //���̽� ���� ��� ����
    [SerializeField] ARFaceManager faceManager;     // plane�Ŵ��� ��� �Ŵ������� �� �̺�Ʈ ���·� ����

    //�޾ƿ� AR Face ����
    ARFace face;

    //������ ǥ�õ� ť�� ������Ʈ �����հ�, ť����� ����Ʈ
    [SerializeField] GameObject cubePrefab;
    [SerializeField] List<GameObject> cubes = new List<GameObject>(468);


    private void Awake()
    {
        for (int i = 0; i < 468; i++)
        {
            GameObject cube = Instantiate(cubePrefab);
            cubes.Add(cube);

        }

    }


    private void OnEnable()
    {
        faceManager.facesChanged += OnFaceChange;
    }

    private void OnDisable()
    {
        faceManager.facesChanged -= OnFaceChange;
    }


    public void ChangeMaterial(Material material)
    {
        face.GetComponent<Renderer>().material = material;
        //��ư ������ ������ ���͸��� ��� ��ü �����ϰԲ� ������

    }


    // �ϴ� �ϳ��� �ΰ� �׽�Ʈ
    private void OnFaceChange(ARFacesChangedEventArgs args)
    {

        //ó������ �߰��� �ְ� �ϳ��� �ִٸ�, arface�� ���
        if (args.added.Count > 0)
        {
            face = args.added[0];
        }

        //�ϳ��� ��������� �־�����
        if (args.updated.Count > 0) 
        {

            // ����: �������� �󱼿� �������(��ġ, ȸ��)�� ������

            // ����: AR Face�� �����ͼ�
            face = args.updated[0];
            
            // ����: �󱼿� �ִ� ��� �������� ����Ʈ ��������,
            for (int i = 0; i < face.vertices.Length; i++)
            {

                // ���̽� ������ ���� ����Ʈ�� �������� �������� �������� 
                // (���Լ� ���� ������ ������ �� �κ��� �������� 0��, 1��, ... �̷��� ���۵�)

                // ���� ������� ��ġ�� ��ȯ���ֱ� ���ؼ���
                // TransformPoint( )�� �̿��ؼ� ��-����ũ-������ ������ǥ�� �����Ͽ�,
                // �θ� �������� �ڽ��� ��ġ�� ������ǥ�� ��ȯ ���ִ� ������ �ʿ���.
                
                // ����: �� ������ ��ġ�� ���� ��ġ�� ��ȯ����                
                Vector3 vertPos = face.transform.TransformPoint(face.vertices[i]);

                // ����: ������ ť����� ������ ��ġ�� �̵�
                cubes[i].transform.position = vertPos;

                // ���� ��ġ�� �̵������� �ű�ٰ� ť�� ������ ���� ť��� �� �� ����ġ�� �̵���Ű�°ž� ��??



            }


        }

    }

}
