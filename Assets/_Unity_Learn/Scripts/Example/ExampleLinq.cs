using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExampleLinq : MonoBehaviour
{
    public void ExampleLinQ()
    {
        //
        int[] numbers = { 1, 2, 3, 4, 5 };

        var resultWhere = numbers.Where(number => number == 3); // Where: Sử dụng để lọc các phần tử trong một tập hợp dựa trên một điều kiện.
        var resultSelect = numbers.Select(x => x * x).ToList(); // Select: Sử dụng để chuyển đổi hoặc ánh xạ các phần tử từ một tập hợp sang một tập hợp mới với cấu trúc dữ liệu khác.
        var resultOrther = numbers.OrderBy(number => number); // OrderBy / OrderByDescending: Sắp xếp các phần tử trong một tập hợp theo một thuộc tính hoặc một điều kiện cụ thể.
                                                              //
        var firstItem = numbers.First(); //First / FirstOrDefault / Last / LastOrDefault: Trả về phần tử đầu tiên hoặc cuối cùng trong một tập hợp, hoặc trả về một giá trị mặc định nếu không tìm thấy phần tử.
        var lastItemOrDefault = numbers.LastOrDefault();
        //
        var count = numbers.Count(); // Count: Đếm số lượng phần tử trong một tập hợp.
        var hasItem = numbers.Any(item => item == 2); // Any / All: Kiểm tra xem có phần tử nào hoặc tất cả các phần tử trong tập hợp thỏa mãn một điều kiện cụ thể hay không.
        var allItemsAreValid = numbers.All(item => item == 2);

        var resultSkip = numbers.Skip(5).Take(10); //Skip / Take: Bỏ qua một số phần tử đầu tiên hoặc lấy một số phần tử từ đầu của một tập hợp.

        int[] numbers2 = { 1, 2, 3, 4, 5 };
        var result = numbers.Concat(numbers2); //Concat: Nối hai tập hợp hoặc các mảng lại với nhau.

        var uniqueItems = numbers.Distinct(); // Distinct: Loại bỏ các phần tử trùng lặp từ một tập hợp.



        //

        // Sử dụng LINQ để lọc các số chẵn
        var evenNumbers = from number in numbers
                          where number % 2 == 0
                          select number;


        var evenNumbersWithLambda = numbers.Where(number => number % 2 == 0);
        //
    }
}
