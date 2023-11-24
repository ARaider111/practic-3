using System;
using System.IO;
using System.Collections.Generic;

class Program 
{
  public static void Main (string[] args) 
  {
    string nums = "nums.txt";
    int n = 0;
    Random rand = new Random();
    try
    {
      Console.WriteLine ("Введите количества чисел в строке:");
      n = int.Parse(Console.ReadLine());
      int[] numbers = new int[n];

      for(int i = 0; i < numbers.Length; ++i)
      {
        numbers[i] = rand.Next(-100, 100);
      }

      string stringNumbers = string.Join(" ", numbers);
      using (StreamWriter writer = new StreamWriter(nums))
      {
        writer.WriteLine(stringNumbers); 
      }

      List<int> oddNumbers = new List<int>();
      using (StreamReader reader = new StreamReader(nums))
      {
        stringNumbers = reader.ReadLine();
        Console.WriteLine(stringNumbers);
        
        string[] numberStrings = stringNumbers.Split(" ");
        for (int i = 0; i < numberStrings.Length; i++)
        {
           numbers[i] = int.Parse(numberStrings[i]); 
           if(numbers[i] % 2 == 1 || numbers[i] % 2 == -1)
           {
             oddNumbers.Add(numbers[i]);
           }
        } 
      }
      
      stringNumbers = string.Join(" ", oddNumbers);
      using (StreamWriter writer = new StreamWriter(nums))
      {
        writer.WriteLine(stringNumbers); 
       }
      
      using (StreamReader reader = new StreamReader(nums))
      {
        stringNumbers = reader.ReadLine();
        Console.WriteLine(stringNumbers);
      }
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
      File.Delete(nums);
    }
  }
}