using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Classes
{
    class User
    {
            private int userid;
            private String username;

            private List<int> scores = new List<int>();
            private List<int> states = new List<int>();


            public User(int userid, String username)
            {
                this.userid = userid;
                this.username = username;
            }

            public void LoadUser()
            {

            }

            public void GetStatistics()
            {

            }

            public void AddNewScore()
            {

            }

            public void addStats(int score, int state)
            {
                scores.Add(score);
                states.Add(state);
            }

            public String getUsername()
            {
                return username;
            }

            public List<int> getScores()
            {
                return scores;
            }

            public List<int> getStates()
            {
                return states;
            }
        
    }
}
