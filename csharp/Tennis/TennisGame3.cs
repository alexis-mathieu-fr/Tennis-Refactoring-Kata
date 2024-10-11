namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player2Score;
        private int player1Score;
        private string player1Name;
        private string player2Name;
        private readonly string[] points = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            string score;
            var isBeforeDeuceOrWin = IsBeforeDeuce() && IsBeforeWin();

            if (isBeforeDeuceOrWin)
            {
                score = points[player1Score];
                // TODO gérer la map,score 
                return player1Score == player2Score ? DisplayEquality(score) : DisplayScore(score, points[player2Score]);
            }

            if (player1Score == player2Score)
                return "Deuce";
            score = player1Score > player2Score ? player1Name : player2Name;
            return ((player1Score - player2Score) * (player1Score - player2Score) == 1) ? "Advantage " + score : "Win for " + score;
        }

        private string DisplayScore(string score, string pointPlayer2) => score + "-" + pointPlayer2;

        private static string DisplayEquality(string score) => score + "-All";

        private bool IsBeforeWin() => player1Score + player2Score < 6;

        private bool IsBeforeDeuce() => player1Score < 4 && player2Score < 4;

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.player1Score += 1;
            else
                this.player2Score += 1;
        }

    }
}