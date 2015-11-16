using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AnimationController : MonoBehaviour {

    public int CountObjects = 0;
    public Text NumberObjects;
    public GameObject EmptyPrefab;
    public GameObject Garbage;
    public GameObject ButtonAddEmpty;
    public Text NumberStartAnimationText,
                NumberFinishAnimationText;
    public Slider AnimationSlider;
    public Text CurrentFrameText;

    List<GameObject> ArrayEmptyObjects;

    // Use this for initialization
    void Start()
    {
        ButtonAddEmpty.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Dot")
                {
                    ArrayEmptyObjects.RemoveAt(System.Convert.ToInt16(hit.collider.name));
                    hit.collider.GetComponent<PointController>().DestroyPoint();
                    RenameDot();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AnimationSlider.value = AnimationSlider.value - 1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AnimationSlider.value = AnimationSlider.value + 1;
        }
    }

    public void CurrentValueFrame()
    {
        CurrentFrameText.text = "Frame: " + AnimationSlider.value.ToString();
    }

    public void EnterNamberStartAnimation()
    {
        Debug.Log("dspjd");
        AnimationSlider.minValue = System.Convert.ToInt16(NumberStartAnimationText.text);
    }

    public void EnterNamberFinishAnimation()
    {
        AnimationSlider.maxValue = System.Convert.ToInt16(NumberFinishAnimationText.text);
    }

    void RenameDot()
    {
        for (int i = 0; i <= ArrayEmptyObjects.Count; i++)
        {
            Debug.Log("sdgsgsdfg");
            if (i != System.Convert.ToInt16(ArrayEmptyObjects[i].name))
            {
                ArrayEmptyObjects[i].name = i.ToString();
            }
        }
    }

    public void AddEmpty()
    {
        NewEmpty(ArrayEmptyObjects.Count);
    }


    public void CreateEmptyObjects()
    {
        ClearSceneMethod();
        int count = System.Convert.ToInt16(NumberObjects.text);
        ArrayEmptyObjects = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            NewEmpty(i);
        }

        ButtonAddEmpty.SetActive(true);
    }

    private void NewEmpty(int index)
    {
        Debug.Log(index);
        ArrayEmptyObjects.Add(Instantiate(EmptyPrefab, Vector3.zero, Quaternion.identity) as GameObject);
        ArrayEmptyObjects[index].name = index.ToString();

        ArrayEmptyObjects[index].tag = "Dot";
        ArrayEmptyObjects[index].transform.parent = Garbage.transform;
    }

    public void ClearSceneMethod()
    {
        ButtonAddEmpty.SetActive(false);

        if (ArrayEmptyObjects != null)
        {
            for (int i = 0; i < ArrayEmptyObjects.Count; i++)
            {
                Destroy(ArrayEmptyObjects[i]);
            }
            ArrayEmptyObjects.Clear();
        }
    }
}
