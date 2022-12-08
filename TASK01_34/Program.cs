/*
Задача 34: 
Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
[345, 897, 568, 234] -> 2
*/

Console.Clear();

Console.Write("Enter an array size: ");
string get_string =Console.ReadLine() ?? String.Empty;
int arr_size = CheckInput(get_string);
int[] nums = new int[arr_size]; 
nums = FillUpArrayWithNums(arr_size, nums);

int count_nums = 0;

foreach (int item in nums) if (CheckEvenNum (item)) count_nums ++;

Console.Write("\nYou've entered array: ");
foreach (int item in nums) Console.Write(item + " ");
Console.WriteLine("\nThe number of even elements is " + count_nums);

bool CheckEvenNum (int number) => number % 2 == 0 ? true : false;

int CheckInput (string get_string) {
    while (true) {
        if (get_string == "Q") Environment.Exit(0);
        if (int.TryParse(get_string, out int num)) {
        Console.Clear();
        return Convert.ToInt32(get_string);
        }
        else {
                Console.Write("\nThis is not an int! ");
                Console.Write("Try again or type 'Q': ");
                get_string = Console.ReadLine() ?? "";
        }
    }
}  

int[] FillUpArrayWithNums(int size, int[] nums_arr) {
    Random random_nums = new Random();
    for (int i = 0; i < size; i ++) nums_arr[i] = random_nums.Next(100, 1000);
    return nums_arr;
}