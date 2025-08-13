using System.Collections.Generic;

namespace SlideIGWebRetry.Models
{
    public class ScenarioListModel
    {
        public List<ScenariosForList> ScenariosList { get; set; }

        public ScenarioListModel()
        {
            ScenariosList = new List<ScenariosForList>(); // Initialize ScenariosList with an empty list in the constructor
        }
    }

    public class ScenariosForList
    {
        public int Id { get; set; }
        public string Scenario_number { get; set; }
        public string Level_name { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }

        public int index { get; set; }
    }
}
