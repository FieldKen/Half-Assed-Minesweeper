int w = 10;
int h = 10;

char[,] board = new char[w, h];
char[,] visibleBoard = new char[w, h];


for (int i = 0; i < w; i++)
{
    for (int j = 0; j < h; j++)
    {
        board[i, j] = '?';
        visibleBoard[i, j] = '?';
    }
}

for (int m = 0; m < 10; m++)
{
    int randomWidth, randomHeight;
    do
    {
        randomWidth = new Random().Next(10);
        randomHeight = new Random().Next(10);
    }
    while (board[randomWidth, randomHeight] == '*');

    board[randomWidth, randomHeight] = '*';
}

//GA GAMEBOARD AF
for (int i = 0; i < w; i++)
{
    for (int j = 0; j < h; j++)
    {
        //3X3 GRID CHECKEN
        int teller = 0;
        for (int xx = -1; xx <= 1; xx++)
        {
            for (int yy = -1; yy <= 1; yy++)
            {
                if (i + xx >= 0 && i + xx < w && j + yy >= 0 && j + yy < h)
                {
                    if (board[i + xx, j + yy] == '*')
                    {
                        teller++;
                    }
                }
            }
        }

        if (board[i, j] != '*')
        {
            board[i, j] = (char)(teller + 48);
        }
    }
}

//Gameplay
do
{
    Console.Clear();
    for (int i = 0; i < w; i++)
    {
        for (int j = 0; j < h; j++)
        {
            switch (visibleBoard[i, j]) 
            {
                case '1': Console.ForegroundColor = ConsoleColor.Blue; break;
                case '2': Console.ForegroundColor = ConsoleColor.Green; break;
                case '3': Console.ForegroundColor = ConsoleColor.Red; break;
                case '4': Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case '5': Console.ForegroundColor = ConsoleColor.Gray; break;
                case '6': Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                case '7': Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                case '8': Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case '*': Console.ForegroundColor = ConsoleColor.Red; break;
            }

            if (visibleBoard[i, j] != '0')
            {
            Console.Write(visibleBoard[i, j] + " ");
            }
            else
            {
                Console.Write("  ");
            }

            Console.ResetColor();
        }
        Console.WriteLine();
    }

    Console.Write("X: ");
    int cy = Convert.ToInt32(Console.ReadLine());
    Console.Write("Y: ");
    int cx = Convert.ToInt32(Console.ReadLine());

    visibleBoard[cx, cy] = board[cx, cy];

    if (visibleBoard[cx, cy] == '0')
    {
        bool hitZero = true;

        for (int k = 0; k < w * h; k++)
        {
            //GA GAMEBOARD AF
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    //3X3 GRID CHECKEN
                    int teller = 0;
                    for (int xx = -1; xx <= 1; xx++)
                    {
                        for (int yy = -1; yy <= 1; yy++)
                        {
                            if (i + xx >= 0 && i + xx < w && j + yy >= 0 && j + yy < h)
                            {
                                if (visibleBoard[i, j] == '0')
                                {
                                    visibleBoard[i + xx, j + yy] = board[i + xx, j + yy];
                                }
                            }
                        }
                    }
                }
            }
        }
    }

} while (true);

//CheckForZeroes(ref board, ref visibleBoard, xx, yy);
/*void CheckForZeroes(ref char[,] board, ref char[,] visibleBoard, int xx, int yy)
{
    
}*/