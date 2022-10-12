// Задача со звёздочкой 2: Вывести первые n строк треугольника Паскаля. Реализовать вывод в виде равнобедренного треугольника.

Console.Clear();
Console.WriteLine("Программа, выводящая на экран первые n строк треугольника Паскаля.");

int row = 0;

AskForInput("row");

int[,] array = FillArray(row, row);

Console.Write("\nCгенерированный треугольник: \n");
PrintArray(array);

///////////////// функции: //////////////////////////////
int[,] FillArray(int row, int column)
{
    int[,] filledArray = new int[row, row];
    int constOne = 1;
    filledArray[0, 0] = constOne;
    filledArray[1, 0] = constOne;
    filledArray[1, 1] = constOne;
    int count = 2;

    for (int i = 2; i < row; i++)
    {
        for (int j = 0; j < row; j++)
        {
            if(j == 0 || j == count)
            {
                filledArray[i, j] = 1;
            }
            else
            {
                filledArray[i, j] = filledArray[i - 1, j - 1] + filledArray[i - 1, j];
            }
        }
        count++;
    }
    return filledArray;
}

void PrintArray(int[,] array)
{
    int count = row;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int c = 0; c <= count; c++)
        {
        Console.Write(" ");
        }
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if(array[i,j] != 0) 
            {
                Console.Write(array[i,j] + " ");
            }
        }
        Console.WriteLine();
        count--;   
    }
}

void AskForInput(string str)
{
    while (true)
    {
        if(str == "row")
        {
            Console.Write("\nНапишите - сколько строк треугольника необходимо показать? :");
        }
        // else if(str == "column") 
        // {
        //     Console.Write("\nНапишите - из скольки столбцов должен состоять массив? :");
        // }
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number > 0)
            {
                if(str == "row")
                {
                    row = number;
                }
                // else if(str == "column")
                // {
                //     column = number;
                // }
                break;
            }
            else Console.WriteLine("Некорректно указано количество строк треугольника!\n");
        }
        else Console.WriteLine("Некорректно указано количество строк треугольника!\n");
    }
}