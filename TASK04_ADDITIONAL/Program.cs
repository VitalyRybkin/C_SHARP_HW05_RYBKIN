/*
Дополнительная задача (задача со звёздочкой): Задайте одномерный массив, заполненный случайными числами. 
Из входного массива сформируйте массив с чётными и массив с нечётными значениями элементов входного массива. 
Найдите ср. арифметическое из полученных значений элементов массивов и выведите результат сравнения средних арифметических.

[1,2,3,4] -> средн. арифм. значений элементов массива с чётными числами > средн. арифм. значений элементов с нечётными числами
[2,3,5,7] -> средн. арифм. массива значений элементов с нечётными числами > средн. арифм. значений элементов с чётными числами
[1,2,5,4] -> средн. арифм. значений элементов массива с нечётными числами = средн. арифм. значений элементов с чётными числами
*/

Console.Clear();

Console.Write("Enter an array size: ");
string get_string = Console.ReadLine() ?? String.Empty;
int arr_size = CheckInput(get_string);
int[] nums = new int[arr_size];
nums = FillUpAnArray(arr_size, nums);

int[] odd_nums = new int[CountOddEvenNums(arr_size, nums).Item2];
int[] even_nums = new int[CountOddEvenNums(arr_size, nums).Item1];

Console.WriteLine("You've entered an array: " + string.Join(" ", nums));
Console.WriteLine();

int a =0, b = 0;
foreach (int item in nums) {
    if (item % 2 == 0) {
        even_nums[a] = item;
        a ++;
    }
    else {
        odd_nums[b] = item;
        b ++;
    }
}

double avg_even = Math.Round(CountAverage (even_nums), 2);
double avg_odd = Math.Round(CountAverage(odd_nums), 2);
string what_to_print = String.Empty;

PrintResultArrays (even_nums, avg_even, what_to_print = "even");
PrintResultArrays (odd_nums, avg_odd, what_to_print = "odd");

if (avg_even > avg_odd) Console.WriteLine($"Average of even numbers array {avg_even} greater than average odd numbers {avg_odd}");
else Console.WriteLine($"Average of odd numbers array {avg_odd} greater than even numbers {avg_even}\n");

void PrintResultArrays (int[] array, double avg, string what_to_print){   
    if (array.Length != 0){
        Console.WriteLine($"Array of {what_to_print} numbers: " + string.Join(" ", array));
        Console.WriteLine("Average is " + avg);
    }
    else {
        Console.WriteLine($"Array of {what_to_print} numbers is empty!");
        Console.WriteLine("Average is 0!");
    }
}

double CountAverage (int[] arr) {
    double avg = 0;
    foreach (int item in arr) avg += item;
    if (avg != 0) return avg/arr.Length;
     else return 0;
}

(int, int) CountOddEvenNums (int size, int[] arr) {
    int count_odd = 0;
    int count_even = 0;
    // ПОЧЕМУ НЕ РАБОТАЕТ СЛЕДУЮЩИЙ КОД? foreach (int item in arr) item % 2 == 0 ? count_even++ : count_odd ++;
    //ХОТЯ В ЗАДАЧЕ 1 РАБОТАЕТ
    for (int i = 0; i < size; i++) {
          if (arr[i] % 2 == 0) count_even ++;
          else count_odd ++;
      }
    return (count_even, count_odd);
}

int CheckInput(string check_string){
    while (true) {
        if (check_string == "Q") Environment.Exit(0);
        if (int.TryParse(check_string, out int num)) {
            return num;
        }
        else {
            Console.WriteLine("Input is not an int!");
            Console.Write("Try again or type 'Q':");
            check_string = Console.ReadLine() ?? String.Empty;
        }
    }
}

int[] FillUpAnArray (int size, int[] arr) {
    Random random_nums = new Random();
    for (int i = 0; i < size; i ++) {
        arr[i] = random_nums.Next(1, 100);
    }
    return arr;
}