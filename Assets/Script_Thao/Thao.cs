using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thao : MonoBehaviour
{

    public class Calculator
    {
        // Phương thức tính tổng hai số
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Phương thức in thông tin về số vào và tổng
        public void PrintSum(int a, int b)
        {
            int sum = Add(a, b); // Gọi phương thức Add từ bên trong phương thức PrintSum
            Debug.Log("Sum of " + a + " and " + b + " is: " + sum);
        }
    }

    private void Start()
    {
        Calculator calculator = new Calculator(); // Tạo một đối tượng của lớp Calculator
        calculator.PrintSum(5, 3); // Gọi phương thức PrintSum và truyền vào hai số 5 và 3
    }

}
