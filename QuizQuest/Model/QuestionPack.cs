using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuest.Model
{

   internal class QuestionPack
    {

        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int TimeLimit { get; set; }
        public List<Question> Questions { get; set; }

        public QuestionPack(string name, int difficulty = 2, int timeLimit = 30)
        {
            Name = name;
            Difficulty = difficulty;
            TimeLimit = timeLimit;
            Questions = new List<Question>();
        }

        public QuestionPack()
        {
            
        }
    }
}
