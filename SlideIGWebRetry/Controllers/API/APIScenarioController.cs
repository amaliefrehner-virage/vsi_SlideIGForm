using Microsoft.Ajax.Utilities;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SlideIGWebRetry.Extensions;
using SlideIGWebRetry.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.IO;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Web.Http.Controllers;

namespace SlideIGWebRetry.Controllers
{
    public class APIScenarioController : ApiController
    {
        Models.SlideIGWebEntities db = new Models.SlideIGWebEntities();
        //Models.Model761 db = new Models.Model761();

        // GET api/APIScenario/{id}/{typeName}/{languageName}
        [Route("api/APIScenario/{id}/{typeName}/{languageName}")]
        [HttpGet]
        public Models.ScenarioModel Get(int id, string typeName, string languageName)
        {
            var error = true;
            var langues = GetLanguages();
            var typs = GetTypes();
            foreach (var i in langues)
            {
                if (languageName == i.Value)
                {
                    error = false;
                }
            }
            foreach (var i in typs)
            {
                if (typeName == i.Value)
                {
                    error = false;
                }
            }

            if (error == true)
            {
                return null;
            }

            var resultIG = from sc in db.Scenarios
                           join sci in db.ScenarioInfoes on sc.IDScenario equals sci.IDScenario
                           join scig in db.ScenarioIGs on sci.IDScenarioInfo equals scig.IDScenarioInfo
                           join st in db.SimulatorTypes on sci.IDSimulatorType equals st.IDSimulatorType
                           join lang in db.Languages on sci.IDLanguage equals lang.IDLanguage
                           join sit in db.ScenarioIGTitles on scig.IDScenarioIG equals sit.IDScenarioIG
                           join sist in db.ScenarioIGSubTitles on sit.IDScenarioIGTitle equals sist.IDScenarioIGTitle into leftSist
                           from sist in leftSist.DefaultIfEmpty()
                           join sistb in db.ScenarioIGSubTitleBullets on sist.IDScenarioIGSubTitle equals sistb.IDScenarioIGSubTitle into leftSistb
                           from sistb in leftSistb.DefaultIfEmpty()
                           join bull in db.BulletPoints on sist.IDBulletPoints equals bull.IDBulletPoints
                           into leftBull
                           from bull in leftBull.DefaultIfEmpty()
                           join bullbull in db.BulletPoints on sistb.IDBulletPoints equals bullbull.IDBulletPoints
                           into leftBullbull
                           from bullbull in leftBullbull.DefaultIfEmpty()
                           where sc.IDScenario == id
                           where lang.LanguageCode == languageName
                           where st.SimulatorTypeCode == typeName
                           select new
                           {
                               sc.IDScenario,
                               LanguageCode = lang.LanguageCode,
                               SimulatorTypeCode = st.SimulatorTypeCode,
                               sc.ScenarioNumber,
                               sci.Title,
                               scig.IDScenarioIG,
                               TypeScenario = "IG",
                               ContentTitle = sit.Content != null ? sit.Content : null,
                               ContentSubtitle = sist.Content != null ? sist.Content : null,
                               ContentSubtitleBullets = sistb.Content != null ? sistb.Content : null,
                               ClassContentSubtitlePoints = sist.BulletPoint.ClassContent != null ? sist.BulletPoint.ClassContent : null,
                               ClassContentBulletPoints = sistb.BulletPoint.ClassContent != null ? sistb.BulletPoint.ClassContent : null,
                               IDSubtitlePoints = (int?)sist.BulletPoint.IDBulletPoints,
                               IDBulletPoints = (int?)sistb.BulletPoint.IDBulletPoints,
                               UnicodeSubtitlePoints = sist.BulletPoint.Unicode != null ? sist.BulletPoint.Unicode : null,
                               UnicodeBulletPoints = sistb.BulletPoint.Unicode != null ? sistb.BulletPoint.Unicode : null,
                               IDContentTitle = (int?)sit.IDScenarioIGTitle,
                               IDContentSubTitle = (int?)sist.IDScenarioIGSubTitle,
                               IDContentSubtitleBullets = (int?)sistb.IDScenarioIGSubTitleBullets
                           };

            var resultSlide = from sc in db.Scenarios
                              join sci in db.ScenarioInfoes on sc.IDScenario equals sci.IDScenario
                              join scig in db.ScenarioSlides on sci.IDScenarioInfo equals scig.IDScenarioInfo
                              join st in db.SimulatorTypes on sci.IDSimulatorType equals st.IDSimulatorType
                              join lang in db.Languages on sci.IDLanguage equals lang.IDLanguage
                              join sit in db.ScenarioSlideTitles on scig.IDScenarioSlide equals sit.IDScenarioSlide
                              join sist in db.ScenarioSlideSubTitles on sit.IDScenarioSlideTitle equals sist.IDScenarioSlideTitle into leftSist
                              from sist in leftSist.DefaultIfEmpty()
                              join sistb in db.ScenarioSlideSubTitleBullets on sist.IDScenarioSlideSubTitle equals sistb.IDScenarioSlideSubTitle into leftSistb
                              from sistb in leftSistb.DefaultIfEmpty()
                              join bull in db.BulletPoints on sist.IDBulletPoints equals bull.IDBulletPoints into leftBull
                              from bull in leftBull.DefaultIfEmpty()
                              join bullbull in db.BulletPoints on sistb.IDBulletPoints equals bullbull.IDBulletPoints into leftBullbull
                              from bullbull in leftBullbull.DefaultIfEmpty()
                              where sc.IDScenario == id
                              where lang.LanguageCode == languageName
                              where st.SimulatorTypeCode == typeName
                              select new
                              {
                                  sc.IDScenario,
                                  LanguageCode = lang.LanguageCode,
                                  SimulatorTypeCode = st.SimulatorTypeCode,
                                  st.IDSimulatorType,
                                  lang.IDLanguage,
                                  sc.ScenarioNumber,
                                  sci.Title,
                                  scig.IDScenarioSlide,
                                  sci.IDScenarioInfo,
                                  TypeScenario = "SLIDE",
                                  ContentTitle = sit.Content != null ? sit.Content : null,
                                  ContentSubtitle = sist.Content != null ? sist.Content : null,
                                  ContentSubtitleBullets = sistb.Content != null ? sistb.Content : null,
                                  ClassContentSubtitlePoints = sist.BulletPoint.ClassContent != null ? sist.BulletPoint.ClassContent : null,
                                  ClassContentBulletPoints = sistb.BulletPoint.ClassContent != null ? sistb.BulletPoint.ClassContent : null,
                                  IDSubtitlePoints = (int?)sist.BulletPoint.IDBulletPoints,
                                  IDBulletPoints = (int?)sistb.BulletPoint.IDBulletPoints,
                                  UnicodeSubtitlePoints = sist.BulletPoint.Unicode != null ? sist.BulletPoint.Unicode : null,
                                  UnicodeBulletPoints = sistb.BulletPoint.Unicode != null ? sistb.BulletPoint.Unicode : null,
                                  IDContentTitle = (int?)sit.IDScenarioSlideTitle,
                                  IDContentSubTitle = (int?)sist.IDScenarioSlideSubTitle,
                                  IDContentSubtitleBullets = (int?)sistb.IDScenarioSlideSubTitleBullets
                              };

            var resultsGlobal = from sc in db.Scenarios
                                join sci in db.ScenarioInfoes on sc.IDScenario equals sci.IDScenario
                                join st in db.SimulatorTypes on sci.IDSimulatorType equals st.IDSimulatorType
                                join lang in db.Languages on sci.IDLanguage equals lang.IDLanguage
                                where sc.IDScenario == id
                                where lang.LanguageCode == languageName
                                where st.SimulatorTypeCode == typeName
                                select new
                                {
                                    sc.IDScenario,
                                    LanguageCode = lang.LanguageCode,
                                    SimulatorTypeCode = st.SimulatorTypeCode,
                                    sc.ScenarioNumber,
                                    sci.Title,
                                    lang.IDLanguage,
                                    st.IDSimulatorType,
                                    sci.IDScenarioInfo
                                };
            var resultIDSLIDE = from sc in db.Scenarios
                                join sci in db.ScenarioInfoes on sc.IDScenario equals sci.IDScenario
                                join st in db.SimulatorTypes on sci.IDSimulatorType equals st.IDSimulatorType
                                join lang in db.Languages on sci.IDLanguage equals lang.IDLanguage
                                join scs in db.ScenarioSlides on sci.IDScenarioInfo equals scs.IDScenarioInfo
                                where sc.IDScenario == id
                                where lang.LanguageCode == languageName
                                where st.SimulatorTypeCode == typeName
                                select new
                                {
                                    scs.IDScenarioSlide
                                };

            var resultIDIG = from sc in db.Scenarios
                             join sci in db.ScenarioInfoes on sc.IDScenario equals sci.IDScenario
                             join st in db.SimulatorTypes on sci.IDSimulatorType equals st.IDSimulatorType
                             join lang in db.Languages on sci.IDLanguage equals lang.IDLanguage
                             join scs in db.ScenarioIGs on sci.IDScenarioInfo equals scs.IDScenarioInfo
                             where sc.IDScenario == id
                             where lang.LanguageCode == languageName
                             where st.SimulatorTypeCode == typeName
                             select new
                             {
                                 scs.IDScenarioIG
                             };

            var dataSlide = resultSlide;
            var dataIG = resultIG;
            var outputSlide = new List<Models.Title>(); // create a list to hold the output objects
            var outputIG = new List<Models.Title>(); // create a list to hold the output objects
            if (resultsGlobal == null || resultsGlobal.FirstOrDefault() == null) { return null; }

            if (dataSlide != null)
            {
                var input = dataSlide; // assume this method returns the input object

                foreach (var item in input)
                {
                    // check if the title already exists in the output list
                    var title = outputSlide.FirstOrDefault(t => t.Name == item.ContentTitle);

                    // if the title doesn't exist, create a new one and add it to the output list
                    if (title == null)
                    {
                        title = new Models.Title
                        {
                            IdTitle = (int)item.IDContentTitle,
                            Name = item.ContentTitle,
                            Subtitles = new List<Models.Subtitle>()
                        };
                        outputSlide.Add(title);
                    }

                    // check if the subtitle already exists in the title
                    var subtitle = title.Subtitles.FirstOrDefault(s => s.Name == item.ContentSubtitle);


                    // if the subtitle doesn't exist, create a new one and add it to the title
                    if (subtitle == null && !string.IsNullOrEmpty(item.ContentSubtitle))
                    {
                        int bulletTypeID = 1;
                        Int32.TryParse(item.IDSubtitlePoints.ToString(), out bulletTypeID);
                        if (bulletTypeID == 0)
                            bulletTypeID = 1;
                        string bulletType = "bullet-default";

                        if (item.ClassContentSubtitlePoints != null)
                            bulletType = item.ClassContentSubtitlePoints;
						subtitle = new Models.Subtitle
                        {
                            IdSubtitle = (int)item.IDContentSubTitle,
                            Name = item.ContentSubtitle,
                            BulletType = bulletType,
							BulletTypeID = bulletTypeID,
                            Bullets = new List<Models.Bullet>(),
                            BulletUnicode = string.Format("&#x{0};", item.UnicodeSubtitlePoints != null ? item.UnicodeSubtitlePoints.Split('+')[1] : "2022")
                        };
                        title.Subtitles.Add(subtitle);
                    }

                    // if the subtitle exists and has bullets, add them to the subtitle object
                    if (subtitle != null && item.ContentSubtitleBullets != null)
                    {
						int bulletTypeID = 1;
						Int32.TryParse(item.IDBulletPoints.ToString(), out bulletTypeID);
						if (bulletTypeID == 0)
							bulletTypeID = 1;
						string bulletType = "bullet-default";
						if (item.ClassContentBulletPoints != null)
							bulletType = item.ClassContentBulletPoints;
						var bullet = new Models.Bullet
                        {
                            IdBullet = (int)item.IDContentSubtitleBullets,
                            Name = item.ContentSubtitleBullets,
                            BulletType = bulletType,
                            BulletTypeID = bulletTypeID,
                            BulletUnicode = string.Format("&#x{0};", item.UnicodeBulletPoints != null ? item.UnicodeBulletPoints.Split('+')[1] : "2022")
                        };
                        subtitle.Bullets.Add(bullet);
                    }
                }

            }
            else { outputSlide = null; }

            if (dataIG != null)
            {
                var input = dataIG; // assume this method returns the input object

                foreach (var item in input)
                {
                    // check if the title already exists in the output list
                    var title = outputIG.FirstOrDefault(t => t.Name == item.ContentTitle);

                    // if the title doesn't exist, create a new one and add it to the output list
                    if (title == null)
                    {
                        title = new Models.Title
                        {
                            IdTitle = (int)item.IDContentTitle,
                            Name = item.ContentTitle,
                            Subtitles = new List<Models.Subtitle>()
                        };
                        outputIG.Add(title);
                    }

                    // check if the subtitle already exists in the title
                    var subtitle = title.Subtitles.FirstOrDefault(s => s.Name == item.ContentSubtitle);

                    // if the subtitle doesn't exist, create a new one and add it to the title
                    if (subtitle == null && !string.IsNullOrEmpty(item.ContentSubtitle))
                    {
						int bulletTypeID = 1;
						Int32.TryParse(item.IDBulletPoints.ToString(), out bulletTypeID);
						if (bulletTypeID == 0)
							bulletTypeID = 1;
						string bulletType = "bullet-default";
						if (item.ClassContentBulletPoints != null)
							bulletType = item.ClassContentBulletPoints;
						subtitle = new Models.Subtitle
                        {
                            IdSubtitle = (int)item.IDContentSubTitle,
                            Name = item.ContentSubtitle,
                            BulletType = bulletType,
                            BulletTypeID = bulletTypeID,
                            Bullets = new List<Models.Bullet>(),
                            BulletUnicode = string.Format("&#x{0};", item.UnicodeSubtitlePoints != null ? item.UnicodeSubtitlePoints.Split('+')[1] : "U+2022")
                        };
                        title.Subtitles.Add(subtitle);
                    }

                    // if the subtitle exists and has bullets, add them to the subtitle object
                    if (subtitle != null && item.ContentSubtitleBullets != null)
                    {
						int bulletTypeID = 1;
						Int32.TryParse(item.IDBulletPoints.ToString(), out bulletTypeID);
						if (bulletTypeID == 0)
							bulletTypeID = 1;
						string bulletType = "bullet-default";
						if (item.ClassContentBulletPoints != null)
							bulletType = item.ClassContentBulletPoints;
						var bullet = new Models.Bullet
                        {
                            IdBullet = (int)item.IDContentSubtitleBullets,
                            Name = item.ContentSubtitleBullets,
                            BulletType = bulletType,
                            BulletTypeID = bulletTypeID,
                            BulletUnicode = string.Format("&#x{0};", item.UnicodeSubtitlePoints != null ? item.UnicodeSubtitlePoints.Split('+')[1] : "U+2022")
                        };
                        subtitle.Bullets.Add(bullet);
                    }
                }
            }
            else { outputSlide = null; }
            Models.ScenarioModel ScenarioModel = null;

            ScenarioModel = new Models.ScenarioModel
            {
                Id = id,
                Scenario_number = resultsGlobal.FirstOrDefault().ScenarioNumber != null ? resultsGlobal.FirstOrDefault().ScenarioNumber : null,
                Level_name = resultsGlobal.FirstOrDefault().Title != null ? resultsGlobal.FirstOrDefault().Title : null,
                Language = resultsGlobal.FirstOrDefault().LanguageCode != null ? resultsGlobal.FirstOrDefault().LanguageCode : null,
                Type = resultsGlobal.FirstOrDefault().SimulatorTypeCode != null ? resultsGlobal.FirstOrDefault().SimulatorTypeCode : null,
                IDLanguage = resultsGlobal.FirstOrDefault().IDLanguage != 0 ? resultsGlobal.FirstOrDefault().IDLanguage : 0,
                IDSimulatorType = resultsGlobal.FirstOrDefault().IDSimulatorType != 0 ? resultsGlobal.FirstOrDefault().IDSimulatorType : 0,
                ScenarioInfoId = resultsGlobal.FirstOrDefault().IDScenarioInfo != 0 ? resultsGlobal.FirstOrDefault().IDScenarioInfo : 0,
                IGList = outputIG.Count != 0 ? outputIG.OrderBy(x => x.IdTitle).ToList() : null,
                SlideList = outputSlide.Count != 0 ? outputSlide : null
            };
            if (resultIDSLIDE.FirstOrDefault() != null)
            {
                ScenarioModel.ScenarioSlideId = resultIDSLIDE.FirstOrDefault().IDScenarioSlide != 0 ? resultIDSLIDE.FirstOrDefault().IDScenarioSlide : 0;
            }
            if (resultIDIG.FirstOrDefault() != null)
            {
                ScenarioModel.ScenarioIGId = resultIDIG.FirstOrDefault().IDScenarioIG != 0 ? resultIDIG.FirstOrDefault().IDScenarioIG : 0;
            }
            return ScenarioModel;
        }

        public async Task<Models.ScenarioInfo> GetScenarioInfo(int id, string typeName, string languageName)
        {
            var error = true;
            var langues = GetLanguages();
            var typs = GetTypes();
            int langId = 0;
            int typeId = 0;
            foreach (var i in langues)
            {
                if (languageName == i.Value)
                {
                    langId = i.Key;
                    error = false;
                }
            }
            foreach (var i in typs)
            {
                if (typeName == i.Value)
                {
                    typeId = i.Key;
                    error = false;
                }
            }

            if (error == true)
            {
                return null;
            }

            var scenarioInfoController = new ScenarioInfoesController();
            var scenarioInfoes = await scenarioInfoController.GetScenarioInfoes().ToListAsync();
            var scenarioInfoObject = scenarioInfoes.Where(s => s.IDLanguage.Equals(langId) && s.IDScenario == id && s.IDSimulatorType == typeId).FirstOrDefault();

            List<ScenarioIG> scenarioIgs = scenarioInfoObject.BuildScenarioIgs();
            List<ScenarioSlide> scenarioSlides = scenarioInfoObject.BuildScenarioSlides();

            return new ScenarioInfo
            {
                IDScenarioInfo = scenarioInfoObject.IDScenarioInfo,
                IDLanguage = langId,
                IDScenario = scenarioInfoObject.IDScenario,
                IDSimulatorType = typeId,
                ScenarioIGs = scenarioIgs,
                ScenarioSlides = scenarioSlides,
                Title = scenarioInfoObject.Title,
            };
        }

        //[Route("api/APIScenario/ExportAllScenarioInfosToJson/{typeName}/{languageName}")]
        //[HttpGet]
        //public async System.Threading.Tasks.Task ExportScenarioInfosToFile(string typeName, string languageName)
        //{
        //    var message = string.Empty;
        //    var langues = GetLanguages();
        //    var typs = GetTypes();
        //    int langId = 0;
        //    int typeId = 0;
         
           
        //    var scenarios = await db.ScenarioInfoes.Where(x=> x.IDLanguage== langId && x.IDSimulatorType == typeId).ToListAsync();
        //    foreach (var scenario in scenarios) 
        //    {
        //        if (scenario.IDScenario != null && scenario.IDLanguage !=null && scenario.IDSimulatorType != null)
        //        {
        //            JsonResult<ScenarioInfo> json = await GetScenarioJson(scenario.IDScenario.Value, typeName, languageName);
        //            File.WriteAllText();
        //        }
               
        //    }
        //}

        [Route("api/APIScenario/GetJSON/{id}/{typeName}/{languageName}")]
        [HttpGet]
        public async Task<System.Web.Http.Results.JsonResult<ScenarioInfo>> GetScenarioJson(int id, string typeName, string languageName)
        {
            ScenarioInfo scenarioInfo = await GetScenarioInfo(id, typeName, languageName);

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = Json(scenarioInfo, settings);
            return json;
        }

        // Post api/APIScenario/all
        [Route("api/APIScenario/all/{searchTerm?}/{languages?}/{types?}/{duplicates?}")]
        [HttpGet]
        public Models.ScenarioListModel GetAll(string searchTerm = "", string languages = "", string types = "", string duplicates = "") {
            var languages1 = languages == "" || languages == null ? new string[] { } : languages.Split(',');
            var types1 = types == "" || types == null ? new string[] { } : types.Split(',');
            var results = from sc in db.Scenarios
                          join sci in db.ScenarioInfoes on sc.IDScenario equals sci.IDScenario
                          join st in db.SimulatorTypes on sci.IDSimulatorType equals st.IDSimulatorType
                          join lang in db.Languages on sci.IDLanguage equals lang.IDLanguage
                          select new
                          {
                              sc.IDScenario,
                              LanguageCode = lang.LanguageCode,
                              SimulatorTypeCode = st.SimulatorTypeCode,
                              sc.ScenarioNumber,
                              sci.Title,
                          };

            duplicates = duplicates == "" ? duplicates : (duplicates == "vs500" || duplicates == "vs600") ? duplicates : "";


            var ScenariosList = new Models.ScenarioListModel();

            var countt = 0;
            foreach (var i in results)
            {
                var Scenario = new Models.ScenariosForList
                {
                    Id = i.IDScenario,
                    Scenario_number = i.ScenarioNumber,
                    Type = i.SimulatorTypeCode,
                    Language = i.LanguageCode,
                    Level_name = i.Title,
                    index = countt
                };
                countt++;
                ScenariosList.ScenariosList.Add(Scenario);
            }

            if (searchTerm != "" && searchTerm != null)
            {
                ScenariosList.ScenariosList = ScenariosList.ScenariosList.Where(s =>
                                        s.Id.ToString().ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                                        s.Scenario_number.ToLower().Trim().Contains(searchTerm.ToLower().Trim()) ||
                                        s.Level_name.ToLower().Trim().Contains(searchTerm.ToLower().Trim())
                                    ).ToList();
            }

            if (languages1.Length > 0)
            {
                ScenariosList.ScenariosList = ScenariosList.ScenariosList.Where(s =>
                    languages1.Contains(s.Language.ToLower().Trim())
                ).ToList();
            }

            if (types1.Length > 0)
            {
                ScenariosList.ScenariosList = ScenariosList.ScenariosList.Where(s =>
                    types1.Contains(s.Type.ToLower().Trim())
                ).ToList();
            }
            var ScenariosList2 = new Models.ScenarioListModel();
            var count2 = 0;

            foreach (var i in ScenariosList.ScenariosList)
            {
                var Scenario = new Models.ScenariosForList
                {
                    Id = i.Id,
                    Scenario_number = i.Scenario_number,
                    Type = i.Type,
                    Language = i.Language,
                    Level_name = i.Level_name,
                    index = count2
                };
                count2++;
                if(duplicates != "")
                {
                    var find = ScenariosList.ScenariosList.Find(x => x.Id == i.Id && x.Scenario_number == i.Scenario_number && x.Type == duplicates);
                    if (find != null && i.Type == duplicates)
                    {
                        ScenariosList2.ScenariosList.Add(Scenario);
                    }
                    else if (find == null && i.Type != duplicates)
                    {
                        ScenariosList2.ScenariosList.Add(Scenario);
                    }
                } else
                {
                    ScenariosList2.ScenariosList.Add(Scenario);
                }
            }

            ScenariosList2.ScenariosList = ScenariosList2.ScenariosList
            .OrderBy(s => double.Parse(Regex.Match(s.Scenario_number, @"^\d+(\.\d+)?").Value))
            .ThenBy(s => s.Scenario_number)
            .ToList();

            return ScenariosList2;
        }

        // Post api/APIScenario/{id}/{typeName}/{languageName}
        [Route("api/APIScenario/FullCopy/{id}/{typeName}/{languageName}")]
        [HttpPost]
        public async Task<object> PostFullCopy(int id, string typeName, string languageName, [FromBody] ContentModel content)
        {
            var apiScenario = new ScenariosController();
            var apiScenarioInfo = new ScenarioInfoesController();
            var apiScenarioSlide = new ScenarioSlidesController();
            var apiScenarioIG = new ScenarioIGsController();

            //=> Scenario (id, Scenario_Number)
            if (apiScenario.ScenarioExists(content.id) != true)
            {
                if(apiScenario.ScenarioExistsNumber(content.scenarioNumber) != true)
                {
                    await apiScenario.PostScenario(new Models.Scenario
                    {
                        IDScenario = content.id,
                        ScenarioNumber = content.scenarioNumber
                    });
                } 
            }
            
            var type = 0;
            var lang = 0;
            var typesDB = GetTypes();
            var languagesDB = GetLanguages();

            foreach (var typ in typesDB)
            {
                if (content.type.Trim() == typ.Value)
                {
                    type = typ.Key;
                }
            }

            if(type == 0){type = 1;}

            foreach (var lan in languagesDB)
            {
                if (content.language == lan.Value)
                {
                    lang = lan.Key;
                }
            }

            if (apiScenarioInfo.ScenarioInfoExistsLangType(lang, type, content.id) == true)
            {
                if (content.applyToAllLanguages != true)
                {
                    ModelState.AddModelError("Error", "A scenario with this id, language and type already exists.");
                    return BadRequest(ModelState);
                }
            }
            Models.ScenarioInfo responseInfo = null;
            
            foreach (var lan in languagesDB)
            {
                var scenarioCopy = Get(id, typeName, lan.Value);
                if (apiScenarioInfo.ScenarioInfoExistsLangType(lan.Key, type, content.id) != true)
                {
                    responseInfo = await apiScenarioInfo.PostScenarioInfo(new Models.ScenarioInfo
                {
                    IDScenario = content.id,
                    IDLanguage = lan.Key,
                    Title = content.levelName,
                    IDSimulatorType = type,

                });
                if (content.ig == true)
                {
                    if (scenarioCopy.IGList != null)
                    {
                        var responseIG = await apiScenarioIG.PostScenarioIG(new Models.ScenarioIG
                        {
                            IDScenarioInfo = responseInfo.IDScenarioInfo
                        });
                        if (responseIG != null)
                        {
                            CopyIGDB(scenarioCopy, responseIG);
                        }
                    }
                }

                if (content.slide == true)
                {
                    if (scenarioCopy.SlideList != null)
                    {
                        var responseSlide = await apiScenarioSlide.PostScenarioSlide(new Models.ScenarioSlide
                        {
                            IDScenarioInfo = responseInfo.IDScenarioInfo
                        });
                        if (responseSlide != null)
                        {
                            CopySlideDB(scenarioCopy, responseSlide);
                        }
                    }
                }
                }
            }
            return content;
        }

        [Route("api/APIScenario/NewBlank")]
        [HttpPost]
        public async Task<object> PostNewBlank([FromBody] ContentModel content)
        {
            var apiScenario = new ScenariosController();
            var apiScenarioInfo = new ScenarioInfoesController();
            var type = 0;
            var lang = 0;
            var typesDB = GetTypes();
            var languagesDB = GetLanguages();

            foreach (var typ in typesDB)
            {
                if (content.type == typ.Value)
                {
                    type = typ.Key;
                }
            }

            foreach (var lan in languagesDB)
            {
                if (content.language == lan.Value)
                {
                    lang = lan.Key;
                }
            }

            if (apiScenarioInfo.ScenarioInfoExistsLangType(lang, type, content.id) == true)
            {
                ModelState.AddModelError("Error", "A scenario with this ID, Language and Type already exists.");
                return BadRequest(ModelState);
            }

            if (apiScenario.ScenarioExists(content.id) != true)
            {
                if (apiScenario.ScenarioExistsNumber(content.scenarioNumber) != true)
                {
                    var newScenario = new Models.Scenario
                    {
                        IDScenario = content.id,
                        ScenarioNumber = content.scenarioNumber
                    };
                    await apiScenario.PostScenario(newScenario);

                    foreach (var typ in typesDB)
                    {
                        if (content.type == typ.Value)
                        {
                            type = typ.Key;
                        }
                    }
                    foreach (var language in languagesDB)
                    {
                        if (apiScenarioInfo.ScenarioInfoExistsLangType(language.Key, type, content.id) != true)
                        {

                            var newScenarioInfo = new Models.ScenarioInfo
                            {
                                IDScenario = content.id,
                                IDLanguage = language.Key,
                                IDSimulatorType = type,
                                Title = content.levelName
                            };
                            await apiScenarioInfo.PostScenarioInfo(newScenarioInfo);
                        }
                    }
                } else {
                    ModelState.AddModelError("Error", "A scenario with this Scenario Number already exists");
                    return BadRequest(ModelState);
                }
            } else
            {
                ModelState.AddModelError("Error", "A scenario with this ID already exists.");
                return BadRequest(ModelState);
            }
            return content;
        }

        public object CopySlideDB(Models.ScenarioModel scenarioModel, Models.ScenarioSlide scenarioSlide)
        {
            foreach (var slide in scenarioModel.SlideList)
            {
                // Create a new ScenarioSlideTitles object
                var title = new Models.ScenarioSlideTitle
                {
                    IDScenarioSlide = scenarioSlide.IDScenarioSlide,
                    Content = slide.Name
                };

                // Insert the title into the ScenarioSlideTitles table
                db.ScenarioSlideTitles.Add(title);
                db.SaveChanges();

                foreach (var subtitle in slide.Subtitles)
                {
                    // Create a new ScenarioSlideSubTitles object
                    var subtitleObj = new Models.ScenarioSlideSubTitle
                    {
                        Content = subtitle.Name,
                        IDScenarioSlideTitle = title.IDScenarioSlideTitle,
                        IDBulletPoints = subtitle.BulletTypeID,
                    };

                    // Insert the subtitle into the ScenarioSlideSubTitles table
                    db.ScenarioSlideSubTitles.Add(subtitleObj);
                    db.SaveChanges();

                    foreach (var bullet in subtitle.Bullets)
                    {
                        // Create a new ScenarioSlideSubTitleBullets object
                        var bulletObj = new Models.ScenarioSlideSubTitleBullet
                        {
                            Content = bullet.Name,
                            IDScenarioSlideSubTitle = subtitleObj.IDScenarioSlideSubTitle,
							IDBulletPoints = 4,
						};

                        // Insert the bullet into the ScenarioSlideSubTitleBullets table
                        db.ScenarioSlideSubTitleBullets.Add(bulletObj);
                        db.SaveChanges();
                    }
                }
            }
            return scenarioModel;
        }

        public object CopyIGDB(Models.ScenarioModel scenarioModel, Models.ScenarioIG scenarioIG)
        {
            foreach (var ig in scenarioModel.IGList)
            {
                // Create a new ScenarioIGTitles object
                var title = new Models.ScenarioIGTitle
                {
                    IDScenarioIG = scenarioIG.IDScenarioIG,
                    Content = ig.Name
                };

                // Insert the title into the ScenarioIGTitles table
                db.ScenarioIGTitles.Add(title);
                db.SaveChanges();

                foreach (var subtitle in ig.Subtitles)
                {
                    // Create a new ScenarioIGSubTitles object
                    var subtitleObj = new Models.ScenarioIGSubTitle
                    {
                        Content = subtitle.Name,
                        IDScenarioIGTitle = title.IDScenarioIGTitle
                    };

                    // Insert the subtitle into the ScenarioIGSubTitles table
                    db.ScenarioIGSubTitles.Add(subtitleObj);
                    db.SaveChanges();

                    foreach (var bullet in subtitle.Bullets)
                    {
                        // Create a new ScenarioIGSubTitleBullets object
                        var bulletObj = new Models.ScenarioIGSubTitleBullet
                        {
                            Content = bullet.Name,
                            IDScenarioIGSubTitle = subtitleObj.IDScenarioIGSubTitle
                        };

                        // Insert the bullet into the ScenarioSlideSubTitleBullets table
                        db.ScenarioIGSubTitleBullets.Add(bulletObj);
                        db.SaveChanges();
                    }
                }
            }
            return scenarioModel;
        }

        public List<KeyValuePair<int, string>> GetLanguages()
        {
            List<Models.Language> languages = db.Languages.ToList();
            List<KeyValuePair<int, string>> formattedLanguages = new List<KeyValuePair<int, string>>();

            foreach (Models.Language language in languages)
            {
                formattedLanguages.Add(new KeyValuePair<int, string>(language.IDLanguage, language.LanguageCode));
            }

            return formattedLanguages;
        }

        public List<KeyValuePair<int, string>> GetTypes()
        {
            List<Models.SimulatorType> types = db.SimulatorTypes.ToList();
            List<KeyValuePair<int, string>> formattedTypes = new List<KeyValuePair<int, string>>();

            foreach (Models.SimulatorType type in types)
            {
                formattedTypes.Add(new KeyValuePair<int, string>(type.IDSimulatorType, type.SimulatorTypeCode));
            }

            return formattedTypes;
        }

        public List<KeyValuePair<int, string>> GetBulletPoints()
        {
            List<Models.BulletPoint> bullets = db.BulletPoints.ToList();
            List<KeyValuePair<int, string>> formattedBullets = new List<KeyValuePair<int, string>>();

            foreach (Models.BulletPoint bullet in bullets)
            {
                formattedBullets.Add(new KeyValuePair<int, string>(bullet.IDBulletPoints, string.Format("&#x{0};", bullet.Unicode.Split('+')[1])));
            }

            return formattedBullets;
        }

        // Post api/APIScenario/FullCopyNewLanguage/{Language}
        [Route("api/APIScenario/FullCopyNewLanguage/{Language}")]
        [HttpPost]
        public async Task<object> FullCopyNewLanguage(string Language)
        {
            var apiScenario = new ScenariosController();
            var apiScenarioInfo = new ScenarioInfoesController();
            var apiScenarioSlide = new ScenarioSlidesController();
            var apiScenarioIG = new ScenarioIGsController();
            var apiLanguages = new LanguagesController();

            var listofScenarios = apiScenarioInfo.GetScenarioInfoesWithOfLanguage(2);

            var languagecodeForSc = db.Languages.FirstOrDefault(e => e.LanguageCode == Language);

            if(languagecodeForSc == null)
            {
                Models.Language languageModel = new Models.Language{LanguageCode = Language};
                languagecodeForSc = apiLanguages.PostLanguage(languageModel);
            }

            foreach (var sc in listofScenarios)
            {

                //Create ScenarioInfo
                var languageForSc = db.Languages.FirstOrDefault(e => e.IDLanguage == sc.IDLanguage);
                var typeForSc = db.SimulatorTypes.FirstOrDefault(e => e.IDSimulatorType == sc.IDSimulatorType);

                Models.ScenarioInfo responseInfo = null;
                var scenarioCopy = Get((int)sc.IDScenario, typeForSc.SimulatorTypeCode, languageForSc.LanguageCode);
                if(!apiScenarioInfo.ScenarioInfoExistsLangType(languagecodeForSc.IDLanguage, (int)sc.IDSimulatorType, (int)sc.IDScenario))
                {
                    responseInfo = await apiScenarioInfo.PostScenarioInfo(new Models.ScenarioInfo
                    {
                        IDScenario = sc.IDScenario,
                        IDLanguage = languagecodeForSc.IDLanguage,
                        Title = sc.Title,
                        IDSimulatorType = sc.IDSimulatorType,

                    });

                    if (scenarioCopy.IGList != null)
                    {
                        var responseIG = await apiScenarioIG.PostScenarioIG(new Models.ScenarioIG
                        {
                            IDScenarioInfo = responseInfo.IDScenarioInfo
                        });
                        if (responseIG != null)
                        {
                            CopyIGDB(scenarioCopy, responseIG);
                        }
                    }

                    if (scenarioCopy.SlideList != null)
                    {
                        var responseSlide = await apiScenarioSlide.PostScenarioSlide(new Models.ScenarioSlide
                        {
                            IDScenarioInfo = responseInfo.IDScenarioInfo
                        });
                        if (responseSlide != null)
                        {
                            CopySlideDB(scenarioCopy, responseSlide);
                        }
                    }
                }
            }
            return null;
        }

        [Route("api/APIScenario/DeserializeJSONStringToScenarioInfo/{id}/{typeId}/{languageId}")]
        [HttpPut]
        public async Task<object> DeserializeJSONStringToScenarioInfo(int id, string typeId, string languageId, [FromBody]string content)
        {
            var obj = JsonConvert.DeserializeObject<ScenarioInfo>(content);

            var typesDB = GetTypes();
            var languagesDB = GetLanguages();
            var type = string.Empty;
            var language = string.Empty;
            try
            {
                type = typesDB.Where(x => x.Key.ToString() ==typeId).First().Value;
                language = languagesDB.Where(x => x.Key.ToString() == languageId).First().Value;
            }
            catch (Exception ex)
            {
                return BadRequest("parameter error: make sure to define the simulator type (vs600/vs500) and language (en/fr/es/ar)");
            }
            return await PutScenario(id, type, language, obj);
        }

        [Route("api/APIScenario/DeserializeJSONStringsToScenarioInfoList/")]
        [HttpPut]
        public async System.Threading.Tasks.Task DeserializeJSONStringsToScenarioInfoList( [FromBody] string content)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<List<ScenarioInfo>>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            await System.Threading.Tasks.Task.CompletedTask;

            //var typesDB = GetTypes();
            //var languagesDB = GetLanguages();
            //var type = string.Empty;
            //var language = string.Empty;
            //try
            //{
            //    type = typesDB.Where(x => x.Key.ToString() == typeId).First().Value;
            //    language = languagesDB.Where(x => x.Key.ToString() == languageId).First().Value;
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("parameter error: make sure to define the simulator type (vs600/vs500) and language (en/fr/es/ar)");
            //}
            //return await PutScenario(id, type, language, obj);
        }

        [Route("api/APIScenario/PutScenarioJson/{id}/{typeName}/{languageName}")]
        [HttpPut]
        public async Task<object> PutScenario(int id, string typeName, string languageName, [FromBody] ScenarioInfo scenarioInfo)
        {
            var apiScenario = new ScenariosController();
            var apiScenarioInfo = new ScenarioInfoesController();
            var apiScenarioSlide = new ScenarioSlidesController();
            var typesDB = GetTypes();
            var languagesDB = GetLanguages();
            var type = 0;
            var lang = 0;
            try
            {
                type = typesDB.Where(x => x.Value.Equals(typeName, StringComparison.OrdinalIgnoreCase)).First().Key;
                lang = languagesDB.Where(x => x.Value.Equals(languageName, StringComparison.OrdinalIgnoreCase)).First().Key;
            } catch (Exception ex)
            {
                return BadRequest("parameter error: make sure to define the simulator type (vs600/vs500) and language (en/fr/es/ar)");
            }

            var slides = apiScenarioSlide.GetScenarioSlides();

            if (scenarioInfo is null)
            {
                return BadRequest("scenarioInfo is null");
            }

            if (scenarioInfo.IDScenario != id)
            {
                return BadRequest("scenarioInfo ID is not equal to the parameter ID");
            }
           
            if (scenarioInfo.IDLanguage != lang)
            {
                return BadRequest("scenarioInfo language is not equal to the parameter language");
            }
            if (scenarioInfo.IDSimulatorType != type)
            {
                return BadRequest("scenarioInfo type is not equal to the parameter typeName");
            }
 
            try
            {
                db.Entry(scenarioInfo).State = System.Data.Entity.EntityState.Modified;
              
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var slide in scenarioInfo.ScenarioSlides)
            {
                try
                {

                    db.Entry(slide).State = System.Data.Entity.EntityState.Modified;
                   

                    foreach (var title in slide.ScenarioSlideTitles) 
                    {
                        db.Entry(title).State = EntityState.Modified;
                        foreach (var sub in title.ScenarioSlideSubTitles)
                        {
                            db.Entry(sub).State = EntityState.Modified;
                            foreach (var bullet in sub.ScenarioSlideSubTitleBullets)
                            {
                                db.Entry(bullet).State = EntityState.Modified;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            foreach (var ig in scenarioInfo.ScenarioIGs)
            {
                try
                {
                    db.Entry(ig).State = System.Data.Entity.EntityState.Modified;
                    foreach (var title in ig.ScenarioIGTitles)
                    {
                        db.Entry(title).State = EntityState.Modified;
                        if (title.ScenarioIGSubTitles != null)
                        {
                            foreach (var sub in title.ScenarioIGSubTitles)
                            {
                                db.Entry(sub).State = EntityState.Modified;
                                if (sub.ScenarioIGSubTitleBullets != null)
                                {
                                    foreach (var bullet in sub.ScenarioIGSubTitleBullets)
                                    {
                                        db.Entry(bullet).State = EntityState.Modified;
                                    }
                                }
                            }
                        }
                       
                    }
                }
                catch (Exception e)
                {
                    InternalServerError(e);
                }
            }
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.OK);
        }
    }
}

public class Title
{
    public string Name { get; set; }
    public List<Subtitle> Subtitles { get; set; }
}

public class Subtitle
{
    public string Name { get; set; }

    public string BulletType { get; set; }
    public List<string> Bullets { get; set; }
}

public class ContentModel
{
    public int id { get; set; }
    public string scenarioNumber { get; set; }
    public string language { get; set; }
    public string type { get; set; }
    public string levelName { get; set; }

    public bool slide { get; set; }

    public bool ig { get; set; }

    public bool applyToAllLanguages { get; set; } = true;
}

public class SearchModel
{
    public string searchTerm { get; set; }
}