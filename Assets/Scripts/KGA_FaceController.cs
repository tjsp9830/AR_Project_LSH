using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class KGA_FaceController : MonoBehaviour
{
    //페이스 내부 기능 참조
    [SerializeField] ARFaceManager faceManager;     // plane매니저 등등 매니저들은 다 이벤트 형태로 ㄱㄱ

    //받아올 AR Face 변수
    ARFace face;

    //정점에 표시될 큐브 오브젝트 프리팹과, 큐브들의 리스트
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
        //버튼 누르기 등으로 메터리얼 계속 교체 가능하게끔 만들어보기

    }


    // 일단 하나만 두고 테스트
    private void OnFaceChange(ARFacesChangedEventArgs args)
    {

        //처음으로 추가된 애가 하나라도 있다면, arface를 등록
        if (args.added.Count > 0)
        {
            face = args.added[0];
        }

        //하나라도 변경사항이 있었을때
        if (args.updated.Count > 0) 
        {

            // 설명: 추적중인 얼굴에 변경사항(위치, 회전)이 있을때

            // 설명: AR Face를 가져와서
            face = args.updated[0];
            
            // 설명: 얼굴에 있는 모든 정점들의 리스트 가져오고,
            for (int i = 0; i < face.vertices.Length; i++)
            {

                // 페이스 정점은 센터 포인트를 기준으로 포지션이 잡혀있음 
                // (윗입술 위와 인중이 만나는 그 부분을 기준으로 0번, 1번, ... 이렇게 시작됨)

                // 따라서 월드상의 위치로 변환해주기 위해서는
                // TransformPoint( )를 이용해서 얼굴-마스크-정점의 월드좌표를 추출하여,
                // 부모를 기준으로 자식의 위치를 월드좌표로 변환 해주는 과정이 필요함.
                
                // 설명: 얼굴 기준의 위치를 월드 위치로 변환해줌                
                Vector3 vertPos = face.transform.TransformPoint(face.vertices[i]);

                // 설명: 생성한 큐브들을 기준의 위치로 이동
                cubes[i].transform.position = vertPos;

                // 월드 위치로 이동했으면 거기다가 큐브 놓으면 되지 큐브는 또 왜 얼굴위치로 이동시키는거야 ㅠ??



            }


        }

    }

}
