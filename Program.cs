DrawTitle();
DrawBoard();
DrawPanel();
WriteOnPanel();

// SetScoreboard('o', 4);

char currentPlayer = 'x';

char[,] board = new char[3, 3];

Console.ForegroundColor = ConsoleColor.Blue;
SetNextMove(ref currentPlayer);

static void DrawTitle()
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("####################################################################################\n");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("      ## ###### ###### ######   ####   ######   ##  ## ###### ##     ##  ## ######    ");
    Console.WriteLine("      ## ##  ## ##     ##  ##   ##  ## ##  ##   ##  ## ##     ##     ##  ## ##  ##    ");
    Console.WriteLine("      ## ##  ## ## ### ##  ##   ##   # ######   ##  ## ###### ##     ###### ######    ");
    Console.WriteLine("  ##  ## ##  ## ##  ## ##  ##   ##  ## ##  ##    ####  ##     ##     ##  ## ##  ##    ");
    Console.WriteLine("   ####  ###### ###### ######   ####   ##  ##     ##   ###### ###### ##  ## ##  ##  \n");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("####################################################################################\n");
}

static void DrawBoard()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 5; j++)
            Console.WriteLine("              |              |");

        if (i != 2)
            Console.WriteLine("--------------+--------------+--------------");
    }
}

static void DrawPanel()
{
    Console.SetCursorPosition(52, 10);
    Console.WriteLine("+----------------------------+");

    for (int i = 11; i < 26; i++)
    {
        Console.SetCursorPosition(52, i);
        Console.WriteLine("|                            |");
    }

    Console.SetCursorPosition(52, 26);
    Console.WriteLine("+----------------------------+");
}

static void WriteOnPanel()
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.SetCursorPosition(55, 12);
    Console.Write("-+-+-+-+ PAINEL +-+-+-+-");

    SetScoreboard(0, 0);

    editInputLine('x');

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.SetCursorPosition(55, 20);
    Console.Write("ENTRADA ~> (LINHA,COLUNA)");

    Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(55, 22);
    Console.Write("BY: MATEUS FONSECA");
    Console.SetCursorPosition(55, 24);
    Console.Write("github.com/mateus.xfl");
}

static void SetScoreboard(int valuePlayerX, int valuePlayerO)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.SetCursorPosition(55, 14);
    Console.Write($"JOGADOR X: {valuePlayerX} PONTOS");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.SetCursorPosition(55, 16);
    Console.Write($"JOGADOR O: {valuePlayerO} PONTOS");
}

static void editInputLine(char currentPlayer)
{
    if (currentPlayer == 'x')
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(55, 18);
        Console.Write("SUA VEZ X:    ");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(55, 18);
        Console.Write("SUA VEZ O:    ");
    }
}

static void SetNextMove(ref char currentPlayer)
{
    Console.SetCursorPosition(66, 18);
    string location = Console.ReadLine();
    var data = location.Split(",");
    MarkField(int.Parse(data[0]), int.Parse(data[1]), ref currentPlayer);
}

static void MarkField(int line, int column, ref char currentPlayer)
{
    /*
        Linha 1 = 10 = ((line * 6) + 4)
        Linha 2 = 16 = ((line * 6) + 4)
        Linha 3 = 22 = ((line * 6) + 4)

        Coluna 1 = 00 = (column - 1) * 15
        Coluna 2 = 15 = (column - 1) * 15
        Coluna 3 = 30 = (column - 1) * 15
    */

    line = (line * 6) + 4;
    column = (column - 1) * 15;

    string iconLine1, iconLine2, iconLine3;
    ConsoleColor color;

    if (currentPlayer == 'x')
    {
        iconLine1 = "   ##    ##";
        iconLine2 = "    ##  ## ";
        iconLine3 = "     ####  ";
        color = ConsoleColor.Blue;
    }
    else
    {
        iconLine1 = "    ######  ";
        iconLine2 = "   ##    ## ";
        iconLine3 = "  ##      ##";
        color = ConsoleColor.Red;
    }

    Console.ForegroundColor = color;

    Console.SetCursorPosition(column, line);
    Console.WriteLine(iconLine1);
    Console.SetCursorPosition(column, line + 1);
    Console.WriteLine(iconLine2);
    Console.SetCursorPosition(column, line + 2);
    Console.WriteLine(iconLine3);
    Console.SetCursorPosition(column, line + 3);
    Console.WriteLine(iconLine2);
    Console.SetCursorPosition(column, line + 4);
    Console.WriteLine(iconLine1);

    currentPlayer = currentPlayer == 'x' ? 'o' : 'x';

    editInputLine(currentPlayer);
    SetNextMove(ref currentPlayer);
}

