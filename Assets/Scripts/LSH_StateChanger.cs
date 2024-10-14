using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class LSH_StateChanger : MonoBehaviour
{

    // 메이크업 1~16번의 이름과 메터리얼을 포함한 구조체 
    [SerializeField] public struct makeUpReference
    {
        [SerializeField] string makeUpName;
        [SerializeField] Material makeUpImg;
    }

    // 그 구조체를 담을 리스트
    [SerializeField] public List<makeUpReference> makeUpList;


    // 메이크업 번호를 출력할 TextProMesh
    [SerializeField] TextMeshProUGUI CurStateTMP;

    // 메이크업 번호에 맞는 메터리얼 가져올 변수
    Material[] makeUpFaces = new Material[17];
    //현재 몇번인지
    int curIndex;


    // 페이스 매니저, 지금 들어가있는 프리팹과 메터리얼 보여줄 변수
    [SerializeField] ARFaceManager faceManager;
    [SerializeField] GameObject curArFace;
    [SerializeField] Material curArFaceMT;

    // AR Face를 받아올 변수
    ARFace face;  



    private void Awake()
    {

        #region 메터리얼 가져오기
        makeUpFaces[0] = Resources.Load<Material>("ARface 0");
        makeUpFaces[1] = Resources.Load<Material>("ARface 1");
        makeUpFaces[2] = Resources.Load<Material>("ARface 2");
        makeUpFaces[3] = Resources.Load<Material>("ARface 3");
        makeUpFaces[4] = Resources.Load<Material>("ARface 4");
        makeUpFaces[5] = Resources.Load<Material>("ARface 5");
        makeUpFaces[6] = Resources.Load<Material>("ARface 6");
        makeUpFaces[7] = Resources.Load<Material>("ARface 7");
        makeUpFaces[8] = Resources.Load<Material>("ARface 8");
        makeUpFaces[9] = Resources.Load<Material>("ARface 9");
        makeUpFaces[10] = Resources.Load<Material>("ARface 10");
        makeUpFaces[11] = Resources.Load<Material>("ARface 11");
        makeUpFaces[12] = Resources.Load<Material>("ARface 12");
        makeUpFaces[13] = Resources.Load<Material>("ARface 13");
        makeUpFaces[14] = Resources.Load<Material>("ARface 14");
        makeUpFaces[15] = Resources.Load<Material>("ARface 15");
        makeUpFaces[16] = Resources.Load<Material>("ARface 16");
        #endregion

    }

    private void OnEnable()
    {
        faceManager.facesChanged += OnFaceChange;
    }


    private void Start()
    {
        curArFace = faceManager.facePrefab;
        curArFaceMT = curArFace.GetComponent<MeshRenderer>().materials[0];
        curIndex = 4;
        //currentState = curState.face04;

    }

    

    private void OnDisable()
    {
        faceManager.facesChanged -= OnFaceChange;
    }

    private void Update()
    {

        curArFace = faceManager.facePrefab;
        curArFaceMT = curArFace.GetComponent<MeshRenderer>().materials[0];


        switch (curIndex)
        {

            case 0:
                CurStateTMP.text = "00. 당신의 맨얼굴".ToString();
                break;

            case 1:
                CurStateTMP.text = "01. 달달 군고구마".ToString();
                break;

            case 2:
                CurStateTMP.text = "02. 첫눈 봉숭아물".ToString();
                break;

            case 3:
                CurStateTMP.text = "03. 호호 아이추워".ToString();
                break;

            case 4:
                CurStateTMP.text = "04. 쿨한 버건디걸".ToString();
                break;

            case 5:
                CurStateTMP.text = "05. 핑크 어웨이즈".ToString();
                break;

            case 6:
                CurStateTMP.text = "06. 너의 보랏빛밤".ToString();
                break;

            case 7:
                CurStateTMP.text = "07. 나의 새벽하늘".ToString();
                break;

            case 8:
                CurStateTMP.text = "08. 내가 얼음여왕".ToString();
                break;

            case 9:
                CurStateTMP.text = "09. 나는 얼음공주".ToString();
                break;

            case 10:
                CurStateTMP.text = "10. 반짝 에메랄드".ToString();
                break;

            case 11:
                CurStateTMP.text = "11. 산속 피톤치드".ToString();
                break;

            case 12:
                CurStateTMP.text = "12. 봄날 숲의요정".ToString();
                break;

            case 13:
                CurStateTMP.text = "13. 노란 코스모스".ToString();
                break;

            case 14:
                CurStateTMP.text = "14. 가을 낙엽한닢".ToString();
                break;

            case 15:
                CurStateTMP.text = "15. 따끈 군밤한톨".ToString();
                break;

            case 16:
                CurStateTMP.text = "16. 겨울 생기발랄".ToString();
                break;




        }


    }




    private void OnFaceChange(ARFacesChangedEventArgs args)
    {

        //처음으로 추가된 애가 하나라도 있다면, arface를 등록
        if (args.added.Count > 0)
        {
            face = args.added[0];
        }

        //그래도 안되면 ChangeMaterial 밑에 렢라를 넣어보자
        //하나라도 변경사항이 있었을때
        if (args.updated.Count > 0)
        {
        }

    }

    public void ChangePrefabLeft()
    {

        if (curIndex == 0)
        {
            curIndex = 16;
        }
        else
        {
            curIndex--;
        }

        //curArFace = makeUpFaces[curIndex];
        ChangeMaterial(makeUpFaces[curIndex]);

    }

    public void ChangePrefabRight()
    {

        if (curIndex == 16)
        {
            curIndex = 0;
        }
        else
        {
            curIndex++;
        }

        //curArFace = makeUpFaces[curIndex];
        ChangeMaterial(makeUpFaces[curIndex]);

    }



    public void ChangeMaterial(Material material)
    {
        face.GetComponent<Renderer>().material = material;
        //버튼 누르기 등으로 메터리얼 계속 교체 가능하게끔 만들어보기

        //faceManager.facePrefab. = 매태리얼이 적용된 프리팹을 넣고싶은데 그걸 어케하지
        //faceManager.facePrefab.GetComponent<MeshRenderer>().materials[0] = makeUpFaces[curIndex];
        //curArFace = makeUpFaces[curIndex];

        Debug.LogError("메테리얼 교체");

    }



}
