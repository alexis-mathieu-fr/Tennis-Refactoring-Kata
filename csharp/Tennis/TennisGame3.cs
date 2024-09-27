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
            bool isBeforeDeuceOrWin = (player1Score < 4 && player2Score < 4) && (player1Score + player2Score < 6);
            if (isBeforeDeuceOrWin)
            {
                score = points[player1Score];
                return (player1Score == player2Score) ? score + "-All" : score + "-" + points[player2Score];
            }

            if (player1Score == player2Score)
                return "Deuce";
            score = player1Score > player2Score ? player1Name : player2Name;
            return ((player1Score - player2Score) * (player1Score - player2Score) == 1) ? "Advantage " + score : "Win for " + score;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.player1Score += 1;
            else
                this.player2Score += 1;
        }

    }
}