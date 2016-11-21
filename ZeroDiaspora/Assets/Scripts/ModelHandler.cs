using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModelHandler : MonoBehaviour {
    public GameObject[] models;
    private int modelsSize;
    private int animationsSize;
    private int count;
    private int animationCount;
    public GameObject current;
    public Text modelName;
    private Animator currentAnimator;
	// Use this for initialization
	void Start () {
        count = 0;
        modelsSize = models.Length;
        current = models[0];
        current.SetActive(true);
        currentAnimator = current.GetComponent<Animator>();
        animationCount = 1;
        animationsSize = 6;
        modelName.text = current.name+"";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void changeModelLast()
    {
        count--;
        if (count >= 0)
        {
            makeChangeModel(count);
        }
        else
        {
            count = modelsSize-1;
            makeChangeModel(count);
        }
    }
    public void changeModelNext() {
        count++;
        if (count < modelsSize)
        {
            makeChangeModel(count);
        }
        else {
            count = 0;
            makeChangeModel(count);
        }
    }
    private void makeChangeModel(int count) {
        current.SetActive(false);
        current = models[count];
        currentAnimator = current.GetComponent<Animator>();
        current.SetActive(true);
        animationCount = 1;
        modelName.text = current.name+"";
    }
    public void changeAnimationNext() {
        animationCount++;
        if (animationCount < animationsSize)
        {
            playAnimation(animationCount);
        }
        else
        {
            animationCount = 1;
            playAnimation(animationCount);
        }
    }
    public void changeAnimationLast()
    {
        animationCount--;
        if (animationCount >= 1)
        {
            playAnimation(animationCount);
        }
        else
        {
            animationCount = animationsSize-1;
            playAnimation(animationCount);
        }
    }
    private void playAnimation(int count) {
        currentAnimator.Play("Animation" + count);
    }
}
