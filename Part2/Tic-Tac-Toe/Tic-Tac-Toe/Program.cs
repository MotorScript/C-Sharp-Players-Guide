// See https://aka.ms/new-console-template for more information

// TODO 
// [] Create win cases for diagonal wins
// [] Create case for draws
// [] Disallow users to go in a spot that has already been played in

Board gameBoard = new Board();

Player xPlayer = new Player(true);
Player oPlayer = new Player(false);

do
{
    Console.Clear();
    Console.WriteLine("\nIt is X's turn\n");
    gameBoard.DrawBoard();
    xPlayer.TakeTurn(gameBoard);
    gameBoard.DrawBoard();
    if (!gameBoard.GameWon())
    {
        Console.Clear();
        Console.WriteLine("\nIt is O's turn\n");
        gameBoard.DrawBoard();
        oPlayer.TakeTurn(gameBoard);
        gameBoard.DrawBoard();
    }
} while (!gameBoard.GameWon());

if (gameBoard.GameWon())
{
    Console.WriteLine("Someone won!");
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
    public void UpdateMatrix(int[] coordinates)
    {
        int row = coordinates[0];
        int col = coordinates[1];

        boardMatrix[row, col] = coordinates[2];
    }

    public bool GameWon()
    {
        int[,] matrix = boardMatrix;

        for (int i = 0; i < 3; i++)
        {
            bool rowWin = (matrix[i, 0] == matrix[i, 1] && matrix[i, 0] == matrix[i, 2] && matrix[i, 0] != 0);
            bool colWin = (matrix[0, i] == matrix[1, i] && matrix[0, i] == matrix[2, i] && matrix[0, i] != 0);

            if (colWin || rowWin) return true;
        }

        return false;

    }
}

class Player
{
    private bool _isX;
    public Player(bool isX)
    {
        _isX = isX;
    }
    public void TakeTurn(Board gameBoard)
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

        int[] newCoordinates;
        
        if (_isX)
        {
            newCoordinates = new int[] { coordinates[0], coordinates[1], 1 };
            gameBoard.UpdateMatrix(newCoordinates);
        }
        else
        {
            newCoordinates = new int[] { coordinates[0], coordinates[1], 2 };
            gameBoard.UpdateMatrix(newCoordinates);
        }
        
    }
    
}