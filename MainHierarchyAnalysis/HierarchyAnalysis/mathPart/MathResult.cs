using HierarchyAnalysis.alternativeAssessments.models;
using HierarchyAnalysis.buildingHierarchy;
using HierarchyAnalysis.criterionAssessments.models;
using HierarchyAnalysis.peopleAssessments.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HierarchyAnalysis.mathPart
{
    public class MathResult
    {
        public ObservableCollection<AssessmentPeople> AssessmentPeople { set; get; }
        public ObservableCollection<Person> People { set; get; }
        double[,] PeopleAssessment { set; get; }

        public ObservableCollection<AssessmentPeopleCriterion> PeopleCriteria { set; get; }
        public ObservableCollection<Criterion> Criteria { set; get; }
        List<double[,]> CriterionsAssessment { set; get; }

        public ObservableCollection<CriterionAlternativeAssessment> CriterionAlternatives { set; get; }
        public ObservableCollection<Alternative> Alternatives { set; get; }
        List<double[,]> AlternativesAssessment { set; get; }

        public MathResult()
        {

        }

        public List<double> priopityPeople()
        {
           return MathCaclulations.Priority(MathCaclulations.LocalPriority(GetArrayAssessmentsForPeople(People, AssessmentPeople)));
        }

        public List<List<double>> priorityCriterion()
        {
            List<List<double>> vs = new List<List<double>>();
            foreach(double[,] i in GetArrayAssessmentsForCriterions(PeopleCriteria, Criteria))
            {
                vs.Add(MathCaclulations.Priority(MathCaclulations.LocalPriority(i)));
            }
            return vs;
        }
        public List<List<double>> priorityAlternatives()
        {
            List<List<double>> vs = new List<List<double>>();
            foreach (double[,] i in GetArrayAssessmentsForAlternetives(CriterionAlternatives,Alternatives))
            {
                vs.Add(MathCaclulations.Priority(MathCaclulations.LocalPriority(i)));
            }
            return vs;
        }


        private double[,] GetArrayAssessmentsForPeople(ObservableCollection<Person> people, ObservableCollection<AssessmentPeople> assessments)
        {
            double[,] array = new double[people.Count, people.Count];
            int firstIndex, secondIndex;
            foreach (AssessmentPeople assessment in assessments)
            {
                firstIndex = people.IndexOf(assessment.firstPerson);
                secondIndex = people.IndexOf(assessment.secondPerson);
                if (assessment.Assessment < 0)
                {
                    array[firstIndex, secondIndex] = -1 * assessment.Assessment;
                    array[secondIndex, firstIndex] = -1 * (1 / assessment.Assessment);
                }
                else if (assessment.Assessment > 0)
                {
                    array[firstIndex, secondIndex] = 1 / assessment.Assessment;
                    array[secondIndex, firstIndex] = assessment.Assessment;
                }
                else if (assessment.Assessment == 0)
                {
                    array[firstIndex, secondIndex] = 1;
                    array[secondIndex, firstIndex] = 1;
                }
            }
            //string str = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == j) array[i, j] = 1;
                    //str+=string.Format("{0,5} ",array[i,j].ToString());
                }
                //str += "\n";
            }
            return array;
        }
        
        private List<double[,]> GetArrayAssessmentsForCriterions(ObservableCollection<AssessmentPeopleCriterion> peopleCriteria, ObservableCollection<Criterion> criteria)
        {
            List<double[,]> vs = new List<double[,]>();

            foreach (AssessmentPeopleCriterion i in peopleCriteria)
            {
                vs.Add(GetArrayCriterionsForPerson(i, criteria));
            }
            return vs;
        }
        public double[,] GetArrayCriterionsForPerson(AssessmentPeopleCriterion assessments, ObservableCollection<Criterion> criteria)
        {

            double[,] array = new double[criteria.Count, criteria.Count];
            for(int i = 0; i < criteria.Count; i++)
            {
                for (int j = 0; j < criteria.Count; j++)
                {
                    array[i, j] = 0;
                }
            }
            int firstIndex, secondIndex;
            foreach (AssessmentCriterion assessment in assessments.assessmentCriteria)
            {
                firstIndex = GetIndexCriterion(assessment.firstCriterion, criteria);
                secondIndex = GetIndexCriterion(assessment.secondCriterion, criteria);
                array[firstIndex, firstIndex] = 1;
                array[secondIndex, secondIndex] = 1;
                if (assessment.Assessment < 0)
                {
                    array[firstIndex, secondIndex] = -1 * assessment.Assessment;
                    array[secondIndex, firstIndex] = -1 * (1 / assessment.Assessment);
                }
                else if (assessment.Assessment > 0)
                {
                    array[firstIndex, secondIndex] = 1 / assessment.Assessment;
                    array[secondIndex, firstIndex] = assessment.Assessment;
                }
                else if (assessment.Assessment == 0)
                {
                    array[firstIndex, secondIndex] = 1;
                    array[secondIndex, firstIndex] = 1;
                }
            }

            string str = assessments.Person.Name+"\n";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                   
                    str += string.Format("{0,5} ", array[i, j].ToString());
                }
                str += "\n";
            }
            MessageBox.Show(str);
            return array;
        }
        private int GetIndexCriterion(Criterion criterion, ObservableCollection<Criterion> criteria)
        {
            for (int i = 0; i < criteria.Count; i++)
            {
                if (criterion.ID == criteria[i].ID)
                {
                    return i;
                }
            }
            return -1;
        }

        private List<double[,]> GetArrayAssessmentsForAlternetives(ObservableCollection<CriterionAlternativeAssessment> criterionAlternatives, ObservableCollection<Alternative> alternatives)
        {
            List<double[,]> vs = new List<double[,]>();
            foreach(CriterionAlternativeAssessment i in criterionAlternatives)
            {
                vs.Add(GetArrayAlternativesForCriterion(i, alternatives));
            }
            return vs;
        }
        private double[,] GetArrayAlternativesForCriterion(CriterionAlternativeAssessment assessments, ObservableCollection<Alternative> alternatives)
        {
            double[,] array = new double[alternatives.Count, alternatives.Count];
            int firstIndex, secondIndex;
            foreach (AlternativeAssessment assessment in assessments.AlternativeAssessments)
            {
                firstIndex = GetIndexAlternative(assessment.firstAlternative, alternatives);
                secondIndex = GetIndexAlternative(assessment.secondAlternative, alternatives);

                if (assessment.Assessment < 0)
                {
                    array[firstIndex, secondIndex] = -1 * assessment.Assessment;
                    array[secondIndex, firstIndex] = -1 * (1 / assessment.Assessment);
                }
                else if (assessment.Assessment > 0)
                {
                    array[firstIndex, secondIndex] = 1 / assessment.Assessment;
                    array[secondIndex, firstIndex] = assessment.Assessment;
                }
                else if (assessment.Assessment == 0)
                {
                    array[firstIndex, secondIndex] = 1;
                    array[secondIndex, firstIndex] = 1;
                }
            }
            //string str = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == j) array[i, j] = 1;
                    
                    // str+=string.Format("{0,5} ",array[i,j].ToString());
                }
                //str += "\n";
            }
            //MessageBox.Show(str);
            return array;
        }
        private int GetIndexAlternative(Alternative alternative, ObservableCollection<Alternative> alternatives)
        {
            for(int i = 0; i<alternatives.Count; i++)
            {
                if (alternative.ID == alternatives[i].ID)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
