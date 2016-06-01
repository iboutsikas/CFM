﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFM.Data.Models;

namespace CFM.Infrastructure.Services
{
    public class ScoringService
    {
        private static readonly double PROF_SCORE = 4f;
        private static readonly double UNIT_SCORE = 5f;
        private static readonly double ASS_SCORE = 6f;

        public ScoringService()
        {
                
        }

        public void GetScore(Feedback feedback, ref ICollection<Feedback> feedbackList)
        {
            feedbackList.Remove(feedback);
            foreach(var f in feedbackList)
            {
                f.RelevanceScore = 0;
                if (feedback.Assignment.Id == f.Assignment.Id)
                    f.RelevanceScore += ASS_SCORE;

                if (feedback.Assignment.Unit.Id == f.Assignment.Unit.Id)
                    f.RelevanceScore += UNIT_SCORE;

                var teachersCount = feedback.Assignment.Unit.Teachers.Intersect(f.Assignment.Unit.Teachers).Count();
                if(teachersCount < 0)
                    f.RelevanceScore += PROF_SCORE * teachersCount;
            }

            feedbackList.OrderByDescending(f => f.RelevanceScore);
        }
    }
}
