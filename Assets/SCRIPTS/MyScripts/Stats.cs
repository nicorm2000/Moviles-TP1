/// <summary>
/// Represents the statistics for the game, including the winner's side and scores.
/// </summary>
public class Stats
{
    /// <summary>
    /// Enumerates the sides in the game.
    /// </summary>
    public enum side
    {
        RIGHT,
        LEFT
    }

    /// <summary>
    /// The side of the player who won the game.
    /// </summary>
    public static side playerWinner = side.RIGHT;

    /// <summary>
    /// The score of the winner.
    /// </summary>
    public static int winnerScore = 0;

    /// <summary>
    /// The score of the loser.
    /// </summary>
    public static int loserScore = 0;
}