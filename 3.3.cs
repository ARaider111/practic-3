using System;
using System.IO;

class Program
{
  public static void Main (string[] args) 
  {
    string nums2 = "nums2.txt";
    int i = 0;
    Random rand = new Random();
    try
    {
      Console.WriteLine("Введите количество чисел: ");
      i = int.Parse(Console.ReadLine());
      
      int[] numbers = new int [i];
      for(int j = 0; j < numbers.Length; ++j)
      {
        numbers[j] = rand.Next(1, 20);
      }

      string stringNumbers = string.Join(" ", numbers);

      using(StreamWriter writer = new StreamWriter(nums2))
      {
        writer.WriteLine(stringNumbers);
      }

      using(StreamReader reader = new StreamReader(nums2))
      {
        stringNumbers = reader.ReadLine();
        Console.WriteLine(stringNumbers + Environment.NewLine);
      }

      string[] numberStrings = stringNumbers.Split(" ");
      int[] height = new int[i];
      for (int j = 0; j < numberStrings.Length; ++j)
      {
        height[j] = int.Parse(numberStrings[j]); 
      }
      
      int maxSquare = 0;
      int left = 0;
      int right = height.Length - 1;

      while (left < right)
      {
          int square = Math.Min(height[left], height[right]) * (right - left);
          maxSquare = Math.Max(maxSquare, square);

          if (height[left] < height[right])
          {
              ++left;
          }
          else
          {
              --right;
          }
      }
      Console.WriteLine($"Наибольшее количество воды: {maxSquare}");
    }

    catch (FileNotFoundException)
    {
        Console.WriteLine("Файл не найден");
    }
    catch (IOException)
    {
        Console.WriteLine("Ошибка чтения файла или записи в файл");
    }
    
    finally 
    {
      Console.WriteLine("Нажмите любую клавишу для завершения программы");
      Console.ReadKey();
      File.Delete(nums2);
    }
 }
}