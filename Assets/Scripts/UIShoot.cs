
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;



public class UIShoot : MonoBehaviour
{
    public Image ball, gum;
    public Sprite ball1, ball2,ball3;
    public Ease ease;
    private Tween tween;

    public void TypeBall(int t)
    {
        if (t == 1)
        {
            gum.sprite = ball1;
        }
        else if (t == 2)
        {
            gum.sprite = ball2;
        }
        else if (t == 3)
        {
            gum.sprite = ball3;
        }
    }

    public void ValueUpdate(float f)
    {
        if(tween != null) tween.Kill();
        tween = ball.DOFillAmount(f,.5f).SetEase(ease);
        //ball.fillAmount = f;
    }

    public void ValueUpdate(float max, float f)
    {
        if (tween != null) tween.Kill();
        tween = ball.DOFillAmount(1 - (f / max), .5f).SetEase(ease);
        //ball.fillAmount = 1 - (f/max);
    }




}
