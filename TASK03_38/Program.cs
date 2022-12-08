/*
Задача 38: 
Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
[3 7 22 2 78] -> 76
*/

Console.Clear();

Console.Write("Enter an array size: ");
string get_string =Console.ReadLine() ?? String.Empty;
int arr_size = CheckInput(get_string);
int[] nums = new int[arr_size]; 
nums = FillUpArrayWithNums(arr_size, nums);

Console.Write("\nYou've entered array: ");
foreach (int item in nums) Console.Write(item + " ");
Console.WriteLine($"\nDifference between max ({CheckMinMax(nums).Item1}) and min ({CheckMinMax(nums).Item2}) in array is "
    + (CheckMinMax(nums).Item1 - CheckMinMax(nums).Item2));

(int, int) CheckMinMax (int[] nums_array) {
    int max = nums_array[0], min = nums_array[0];
     foreach (int item in nums_array) {
         if (item > max) max = item;
         if (item < min) min = item;
    }
    return (max, min);
}

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
    for (int i = 0; i < size; i ++) nums_arr[i] = random_nums.Next(1, 100);
    return nums_arr;
}