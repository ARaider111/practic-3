using System;
using System.IO;

class Program
{
  static void GenerateUniqueNumbers(string input, int[] numbers, Random rand, int k)
  {
    for (int h = 0; h < k; ++h)
    {
      for (int i = 0; i < numbers.Length; ++i)
      {
        bool l = true;
        int randNumber = rand.Next(1, 32);

        for (int j = 0; j < i+1; ++j)
        {
          if (randNumber == numbers[j])
          {
            l = false;
            break;
          }
        }

        if (l == true)
        {
          numbers[i] = randNumber;
        }
        else
        {
          i -= 1;
        }
      }
      string stringNumbers = string.Join(" ", numbers);
      File.AppendAllText(input, stringNumbers + Environment.NewLine);
      
      for (int i = 0; i < numbers.Length; ++i)
      {
        Console.Write(numbers[i]  + " ");
      }
       Console.WriteLine(" ");
    }
  }

  public static void Main (string[] args) 
  {
    string input = "input.txt";
    string output = "output.txt";
    
    int[] numbers = new int[10];
    Random rnd = new Random();
    int k = 1;
    try
    {
      GenerateUniqueNumbers(input, numbers, rnd, k);

      string n = "";
      Console.WriteLine("Введите количество билетов: ");
      n = Console.ReadLine();
      n = int.Parse(n).ToString();
      k = int.Parse(n);

      File.AppendAllText(input, n + Environment.NewLine);
      numbers = new int[6];

      GenerateUniqueNumbers(input, numbers, rnd, k);

      using (StreamReader reader = new StreamReader(input))
      {
        string stringNumbers = reader.ReadLine();
        string[] numberStrings = stringNumbers.Split(" ");
        int[] luckyNumbers = new int[10];
        for (int i = 0; i < numberStrings.Length; ++i)
        {
          luckyNumbers[i] = int.Parse(numberStrings[i]); 
        }

        reader.ReadLine();
        int[] ticketNumbers = new int[6];
        for(int nul = 0; nul < k; ++nul)
        {
          stringNumbers = reader.ReadLine();
          numberStrings = stringNumbers.Split(" ");
          for (int i = 0; i < numberStrings.Length; ++i)
          {
             ticketNumbers[i] = int.Parse(numberStrings[i]); 
          }

          int coincidence = 0;
          bool l = false;
          for(int i = 0; i < luckyNumbers.Length; ++i)
          {
            for(int j = 0; j < ticketNumbers.Length; ++j)
            {
              if(luckyNumbers[i] == ticketNumbers[j])
              {
                ++coincidence;
                 break;
              }
            }
            if(coincidence >= 3)
            {
              l = true;
            }
          }
          if (l == true)
          {
            File.AppendAllText(output, "Lucky" + Environment.NewLine);
          }
          else
          {
            File.AppendAllText(output, "Unlucky" + Environment.NewLine);
          }
        }
      }

      using (StreamReader reader = new StreamReader(output))
      {
        for(int nul = 0; nul < k; ++nul)
        {
          Console.WriteLine(reader.ReadLine());
        }
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
      File.Delete(input);
      File.Delete(output);
    }
  }
}
