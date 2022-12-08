/*
Задача 36: 
Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, состоящих на нечётных позициях.
[3, 7, 23, 12] -> 19
[-4, -6, 89, 6] -> 0
*/

Console.Clear();

Console.Write("Enter an array size: ");
string get_string =Console.ReadLine() ?? String.Empty;
int arr_size = CheckInput(get_string);
int[] nums = new int[arr_size]; 
nums = FillUpArrayWithNums(arr_size, nums);

int count_sum = 0;

for (int i = 0; i < arr_size; i++) if (CheckOddIndex (i)) count_sum += nums[i];

Console.Write("\nYou've entered array: ");
foreach (int item in nums) Console.Write(item + " ");
Console.WriteLine("\nThe sum of elements of odd indexes of array is " + count_sum);

bool CheckOddIndex (int idx) => idx % 2 != 0 ? true : false;

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
    for (int i = 0; i < size; i ++) nums_arr[i] = random_nums.Next(-100, 100);
    return nums_arr;
}