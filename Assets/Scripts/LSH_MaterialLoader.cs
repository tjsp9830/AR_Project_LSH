using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class LSH_MaterialLoader : MonoBehaviour
{

    [System.Serializable] //이걸 써줘야 에디터상에서 보인다
    // 메이크업 1~16번의 이름과 메터리얼을 포함한 구조체 
    public struct makeUpReference
    {
        [field: SerializeField] public string makeUpName;
        [field: SerializeField] public Material makeUpMat;
    }

    // 그 구조체를 담을 리스트
    [field: SerializeField] public List<makeUpReference> makeUpList;// = new();


    // 메이크업 번호를 출력할 TextProMesh
    [SerializeField] TextMeshProUGUI CurStateTMP;

    // 현재 몇번 얼굴인지 index
    int curIndex;


    // 페이스 매니저, 지금 들어가있는 프리팹과 메터리얼 보여줄 변수
    [SerializeField] ARFaceManager faceManager;

    KGA_ArFaceCtrl arCtrl;


    //private void Start()
    //{
    //    Debug.Log(3);
    //    curArFace = faceManager.facePrefab;
    //    curArFaceMT = curArFace.GetComponent<MeshRenderer>().materials[0];
    //    curIndex = 0;

    //}




    public void MaterialButtonLeft()
    {
        Debug.Log("4 - 좌 버튼눌림");

        if (curIndex == 0)
            curIndex = 16;
        else
            curIndex--;

        ChangeMatText(curIndex);
        ChangeMaterial(curIndex);

    }

    public void MaterialButtonRight()
    {
        Debug.Log("4 - 우 버튼눌림");

        if (curIndex == 16)
            curIndex = 0;
        else
            curIndex++;

        ChangeMatText(curIndex);
        ChangeMaterial(curIndex);

    }



    public void ChangeMatText(int curIndex)
    {
        Debug.Log("5 - 텍스트");
        CurStateTMP.text = $"{makeUpList[curIndex].ToString()}";
        

    }



    public void ChangeMaterial(int curIndex)
    {
        Debug.Log("5 - 메터리얼 바뀜");
        arCtrl.arFace.GetComponent<Renderer>().material = makeUpList[curIndex].makeUpMat;

    }

    //public void ChangeMaterial(Material material)
    //{        
    //    curArFace.GetComponent<Renderer>().material = material;

    //}



}
