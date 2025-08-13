using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SlideIGWebRetry.Models;

namespace SlideIGWebRetry.Models
{
    public class ScenarioModel
    {
        public int? Id { get; set; } = null;
        public string Scenario_number { get; set; } = null;
        public string Level_name { get; set; } = null;
        public string Language { get; set; } = null;
        public string Type { get; set; } = null;

        public int? ScenarioInfoId { get; set; } = null;

        public int? ScenarioSlideId { get; set; } = null;

        public int? IDSimulatorType { get; set; } = null;

        public int? IDLanguage { get; set; } = null;

        public int? ScenarioIGId { get; set; } = null;

        public List<Title> SlideList { get; set; } = null;

        public List<Title> IGList { get; set; } = null;

    }

    public class ScenarioModelList
    {
        public List<ScenarioModel> scenarioModels { get; set; } = null;
    }

    public class Title
    {
        public int IdTitle { get; set; }
        public string Name { get; set; }
        public List<Subtitle> Subtitles { get; set; }
    }

    public class Subtitle
    {
        public int IdSubtitle { get; set; }
        public string Name { get; set; }

        public string BulletType { get; set; }

        public string BulletUnicode { get; set; }
        public int BulletTypeID { get; set; }
        public List<Bullet> Bullets { get; set; }
    }

    public class Bullet
    {
        public int IdBullet { get; set; }

        public string BulletType { get; set; }

        public string BulletUnicode { get; set; }
        public int BulletTypeID { get; set; }
        public string Name { get; set; }
    }

}