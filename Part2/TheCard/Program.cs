
CardColor[] colors = new CardColor[] { CardColor.Red, CardColor.Green, CardColor.Blue, CardColor.Yellow };
CardRank[] ranks = new CardRank[]
{
    CardRank.One, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, CardRank.Seven,
    CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.Dollar, CardRank.Percent, CardRank.Caret, CardRank.Ampersand
};

foreach (CardColor color in colors)
{
    foreach (CardRank rank in ranks)
    {
        Card card = new Card(color, rank);
        Console.WriteLine($"The {color} {rank}");
    }
}


class Card
{
    public CardColor Color { get; init; }
    public CardRank Rank { get; init; }
    public bool IsSymbolCard;
    
    public Card(CardColor color, CardRank rank)
    {
        Color = color;
        Rank = rank;

        if (rank == CardRank.Dollar || rank == CardRank.Percent || rank == CardRank.Caret ||
            rank == CardRank.Ampersand)
        {
            IsSymbolCard = true;
        }
        else
        {
            IsSymbolCard = false;
        }
    }
    
}
public enum CardColor {Red, Green, Blue, Yellow}
public enum CardRank {One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand}