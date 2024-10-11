using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class LSH_StateChanger : MonoBehaviour
{

    enum curState { face00, face01, face02, face03, face04, face05, face06, face07, face08,
                    face09, face10, face11, face12, face13, face14, face15, face16, Size    };
    curState currentState;

    [SerializeField] TextMeshProUGUI CurStateTMP;


    [SerializeField] ARFaceManager faceManager;
    [SerializeField] GameObject curArFace;

    GameObject[] makeUpFaces = new GameObject[17];
    GameObject makeUp_04;
    GameObject makeUp_05;
    int curIndex;


    private void Awake()
    {

        makeUpFaces[0] = Resources.Load<GameObject>("ARface 0");
        makeUpFaces[1] = Resources.Load<GameObject>("ARface 1");
        makeUpFaces[2] = Resources.Load<GameObject>("ARface 2");
        makeUpFaces[3] = Resources.Load<GameObject>("ARface 3");
        makeUpFaces[4] = Resources.Load<GameObject>("ARface 4");
        makeUpFaces[5] = Resources.Load<GameObject>("ARface 5");
        makeUpFaces[6] = Resources.Load<GameObject>("ARface 6");
        makeUpFaces[7] = Resources.Load<GameObject>("ARface 7");
        makeUpFaces[8] = Resources.Load<GameObject>("ARface 8");
        makeUpFaces[9] = Resources.Load<GameObject>("ARface 9");
        makeUpFaces[10] = Resources.Load<GameObject>("ARface 10");
        makeUpFaces[11] = Resources.Load<GameObject>("ARface 11");
        makeUpFaces[12] = Resources.Load<GameObject>("ARface 12");
        makeUpFaces[13] = Resources.Load<GameObject>("ARface 13");
        makeUpFaces[14] = Resources.Load<GameObject>("ARface 14");
        makeUpFaces[15] = Resources.Load<GameObject>("ARface 15");
        makeUpFaces[16] = Resources.Load<GameObject>("ARface 16");


    }

    private void Start()
    {
        curArFace = faceManager.facePrefab;
        curIndex = 4;
        //currentState = curState.face04;

    }

    private void Update()
    {

        faceManager.facePrefab = makeUpFaces[curIndex];

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


    
    // 밑 함수와 데이터를  리스트로 관리하는  리팩토링 필요

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

        curArFace = makeUpFaces[curIndex];


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

        curArFace = makeUpFaces[curIndex];


    }


}
