// See https://aka.ms/new-console-template for more information

// TODO 
// [*] Create win cases for diagonal wins
// [*] Create case for draws
// [*] Disallow users to go in a spot that has already been played in
// [*] State which player won the game

Board gameBoard = new Board();

Player xPlayer = new Player(true);
Player oPlayer = new Player(false);

do
{
    Console.Clear();
    Console.WriteLine("\nIt is X's turn\n");
    gameBoard.DrawBoard();
    xPlayer.TakeTurn(gameBoard);
    // gameBoard.DrawBoard();
    if (gameBoard.GameWon()) xPlayer.HasWon = true;
    if (!gameBoard.GameWon() && !gameBoard.GameDrawn())
    {
        Console.Clear();
        Console.WriteLine("\nIt is O's turn\n");
        gameBoard.DrawBoard();
        oPlayer.TakeTurn(gameBoard);
        if (gameBoard.GameWon()) oPlayer.HasWon = true;
    }
} while (!gameBoard.GameWon() && !gameBoard.GameDrawn());

if (gameBoard.GameWon())
{
    if (xPlayer.HasWon)
    {
        Console.Clear();
        Console.WriteLine("X has won the game!");
        gameBoard.DrawBoard();
    }
    else if (oPlayer.HasWon)
    {
        Console.Clear();
        Console.WriteLine("O has won the game!");
        gameBoard.DrawBoard();
    }
}

if (gameBoard.GameDrawn())
{
    Console.WriteLine("\nThe game is a draw!");
}
class Board
{
    private int[,] boardMatrix = new int[3, 3]
    {
        {0, 0, 0,},
        {0, 0, 0,},
        {0, 0, 0,}
    };

    public void DrawBoard()
    {
        // Translating the matrix from numbers to strings for the user to read easier
        string[,] characters = new string[3,3];
        for (int i = 0; i < boardMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < boardMatrix.GetLength(1); j++)
            {
                int currentIndex = boardMatrix[i, j];
                
                if (currentIndex == 0)
                {
                    characters[i, j] = " ";
                }
                else if (currentIndex == 1)
                {
                    characters[i, j] = "X";
                }
                else
                {
                    characters[i, j] = "O";
                }
            }
        }
        Console.WriteLine(
            $@"
            {characters[0,0]} | {characters[0,1]} | {characters[0,2]}
           ---+---+---
            {characters[1,0]} | {characters[1,1]} | {characters[1,2]}
           ---+---+---
            {characters[2,0]} | {characters[2,1]} | {characters[2,2]}");
    }
    public void UpdateMatrix(int[] coordinates, int currentPlayerNumber)
    {
        int row = coordinates[0];
        int col = coordinates[1];

        boardMatrix[row, col] = currentPlayerNumber;
    }

    public bool GameWon()
    {
        int[,] matrix = boardMatrix;
        bool rowWin = false;
        bool colWin = false;
        
        for (int i = 0; i < 3; i++)
        {
            rowWin = (matrix[i, 0] == matrix[i, 1] && matrix[i, 0] == matrix[i, 2] && matrix[i, 0] != 0);
            colWin = (matrix[0, i] == matrix[1, i] && matrix[0, i] == matrix[2, i] && matrix[0, i] != 0);
            
            if (colWin || rowWin) break;
        }
        
        bool daigWin = (
            (matrix[0, 0] == matrix[1, 1] && matrix[0, 0] == matrix[2, 2] && matrix[0, 0] != 0) ||
            (matrix[0, 2] == matrix[1, 1] && matrix[0, 2] == matrix[2, 0] && matrix[0, 2] != 0));
        
        if (colWin || rowWin || daigWin) return true;

        return false;

    }

    public bool GameDrawn()
    {
        if (!GameWon())
        {
            int[,] matrix = boardMatrix;

            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (matrix[i, x] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        return false;
    }

    public int GetCoordinate(int col, int row)
    {
        return boardMatrix[col, row];
    }
}


class Player
{
    private bool _isX;
    public bool HasWon { get; set; } = false;
    public Player(bool isX)
    {
        _isX = isX;
    }
    public void TakeTurn(Board gameBoard)
    {

        int[] GetInput()
        {
            int[] coordinates = null;

            do
            {
                Console.Write("What square do you want to play in? ");
                int position = Convert.ToInt32(Console.ReadLine());
                switch (position)
                {
                    case 9:
                        coordinates = new int[2] { 0, 2 };
                        break;
                    case 8:
                        coordinates = new int[2] { 0, 1 };
                        break;
                    case 7:
                        coordinates = new int[2] { 0, 0 };
                        break;
                    case 6:
                        coordinates = new int[2] { 1, 2 };
                        break;
                    case 5:
                        coordinates = new int[2] { 1, 1 };
                        break;
                    case 4:
                        coordinates = new int[2] { 1, 0 };
                        break;
                    case 3:
                        coordinates = new int[2] { 2, 2 };
                        break;
                    case 2:
                        coordinates = new int[2] { 2, 1 };
                        break;
                    case 1:
                        coordinates = new int[2] { 2, 0 };
                        break;
                    default:
                        Console.WriteLine("\nYou must choose an valid number (1-9)\n");
                        break;
                }
            } while (coordinates == null);

            return coordinates;
        }

        bool validChoice = false;
        while (!validChoice)
        {
            int[] coordinates = GetInput();
            if (gameBoard.GetCoordinate(coordinates[0], coordinates[1]) != 0)
            {
                Console.WriteLine("You chose a spot that is already taken. Choose another spot. \n");
            }
            else
            {
                validChoice = true;
                
                int currentPlayerNum;
        
                if (_isX)
                {
                    currentPlayerNum = 1;
                }
                else
                {
                    currentPlayerNum = 2;
                }
                gameBoard.UpdateMatrix(coordinates, currentPlayerNum);
            }
        }
    }
}