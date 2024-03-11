using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haruka : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    
    int a=0;
    int b=0;
    int c=0;
    int d=0;
    void Start()
    {
        animator=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(a%2==0){
                ChangeExpressionState(0);
                animator.SetInteger("Face_statement",0);
            }else{
                ChangeExpressionState(10);
                animator.SetInteger("Face_statement",10);
            }
            a++;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
             if(b%2==0){
                ChangeExpressionState(1);
                animator.SetInteger("Face_statement",1);
            }else{
                ChangeExpressionState(11);
                animator.SetInteger("Face_statement",11);
            }
            b++;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
             if(c%2==0){
                ChangeExpressionState(2);
                animator.SetInteger("Face_statement",2);
            }else{
                ChangeExpressionState(12);
                animator.SetInteger("Face_statement",12);
            }
            c++;
        }
        // 繼續加入其他數字條件
        else if (Input.GetKeyDown(KeyCode.D))
        {
             if(d%2==0){
                ChangeExpressionState(3);
                animator.SetInteger("Face_statement",3);
            }else{
                ChangeExpressionState(13);
                animator.SetInteger("Face_statement",13);

            }
            d++;
        }

        if (Input.GetKeyDown("1"))
        {
             
            ChangeExpressionState(21);
            animator.SetInteger("Face_statement",21);
            
        }
        else if (Input.GetKeyDown("2"))
        {
            ChangeExpressionState(22);
            animator.SetInteger("Face_statement",22);
        }
        else if (Input.GetKeyDown("3"))
        {
            ChangeExpressionState(23);
            animator.SetInteger("Face_statement",23);
        }
        else if (Input.GetKeyDown("4"))
        {
            ChangeExpressionState(24);
            animator.SetInteger("Face_statement",24);
        }
        else if (Input.GetKeyDown("5"))
        {
            ChangeExpressionState(25);
            animator.SetInteger("Face_statement",25);
        }
        else if (Input.GetKeyDown("6"))
        {
            ChangeExpressionState(26);
            animator.SetInteger("Face_statement",26);
        }
        else if (Input.GetKeyDown("7"))
        {
            ChangeExpressionState(27);
            animator.SetInteger("Face_statement",27);
        }
        else if (Input.GetKeyDown("8"))
        {
            ChangeExpressionState(28);
            animator.SetInteger("Face_statement",28);
        }
        else if (Input.GetKeyDown("9"))
        {
            ChangeExpressionState(29);
            animator.SetInteger("Face_statement",29);
        }
        else if (Input.GetKeyDown("0"))
        {
            ChangeExpressionState(30);
            animator.SetInteger("Face_statement",30);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeExpressionState(31);
            animator.SetInteger("Face_statement",31);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            ChangeExpressionState(32);
            animator.SetInteger("Face_statement",32);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeExpressionState(33);
            animator.SetInteger("Face_statement",33);
        }
        

        
    }
    void ChangeExpressionState(int state)
    {
        // 根據參數 'state' 改變物件的狀態
        Debug.Log("Changing state to: " + state);
        // 在這裡實現具體改變狀態的邏輯
        // 例如：改變顏色、移動位置、顯示不同的圖形等
    }
        
}

