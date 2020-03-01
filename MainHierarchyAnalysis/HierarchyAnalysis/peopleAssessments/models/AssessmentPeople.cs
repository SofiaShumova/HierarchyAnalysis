using HierarchyAnalysis.buildingHierarchy;

namespace HierarchyAnalysis.peopleAssessments.models
{
    public class AssessmentPeople
    {
        public Person firstPerson { set; get; }
        public Person secondPerson { set; get; }
        public double Assessment { set; get; }

        public AssessmentPeople(Person one, Person two)
        {
            firstPerson = one;
            secondPerson = two;
            Assessment = 0;
        }
    }
}
