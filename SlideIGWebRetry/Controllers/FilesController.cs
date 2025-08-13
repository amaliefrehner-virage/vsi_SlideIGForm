using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using SlideIGWebRetry.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SlideIGWebRetry.Controllers
{
    public class FilesController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<JsonResult<ScenarioInfo>> results = await GetResults();
            
            foreach (var result in results) 
            {
                string serializedObject = JsonConvert.SerializeObject(result.Content);

                var filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var fileName = $"{result.Content.IDScenario}_{ result.Content.IDLanguage}_{ result.Content.IDSimulatorType}.json";
                System.IO.File.WriteAllText(Path.Combine(filePath,"Downloads",fileName), serializedObject);
            }
            return View("");
        }
        public Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public async Task<List<JsonResult<ScenarioInfo>>> GetResults() 
        {
            var apicontroller = new APIScenarioController();
            List<JsonResult<ScenarioInfo>> ListOfScenarios = new List<JsonResult<ScenarioInfo>> { };
            List<string> listIDS = new List<string> { };
           

            for (int i = 1; i < 100; i++)
            {
                string listofIds = Request.Cookies["listofIds" + i]?.Value;
                if (listofIds != null)
                {
                    listIDS.Add(listofIds);
                }
                else
                {
                    break;
                }
            }
            if (listIDS.Count != 0 && listIDS[0] != "")
            {
                foreach (var h in listIDS)
                {
                    List<string> listIds = h.Split(',').ToList();
                    // Now you can use the 'listIds' variable as a list of IDs
                    foreach (var i in listIds)  // Iterate over 'listIds' instead of 'listofIds'
                    {
                        if (i.Contains("-"))
                        {
                            int i_id = Int32.Parse(i.Split('-')[0]);
                            string i_type = i.Split('-')[1];
                            string i_lang = i.Split('-')[2];
                            var ScenarioModel = await apicontroller.GetScenarioJson(i_id, i_type, i_lang);
                            ListOfScenarios.Add(ScenarioModel);
                        }
                    }
                }
            }
            else
            {
                var all = apicontroller.GetAll("", "en", "vs500");
                foreach (var i in all.ScenariosList)
                {
                    var ScenarioModel = await apicontroller.GetScenarioJson(i.Id, "vs500", "en");
                    ListOfScenarios.Add(ScenarioModel);
                }
            }
            return ListOfScenarios;
        }
    }

    public enum KnownFolder
    {
        Contacts,
        Downloads,
        Favorites,
        Links,
        SavedGames,
        SavedSearches
    }

    public static class KnownFolders
    {
        private static readonly Dictionary<KnownFolder, Guid> _guids = new Dictionary<KnownFolder, Guid>()
        {
            [KnownFolder.Contacts] = new Guid("56784854-C6CB-462B-8169-88E350ACB882"),
            [KnownFolder.Downloads] = new Guid("374DE290-123F-4565-9164-39C4925E467B"),
            [KnownFolder.Favorites] = new Guid("1777F761-68AD-4D8A-87BD-30B759FA33DD"),
            [KnownFolder.Links] = new Guid("BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968"),
            [KnownFolder.SavedGames] = new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"),
            [KnownFolder.SavedSearches] = new Guid("7D1D3A04-DEBB-4115-95CF-2F29DA2920DA")
        };

        public static string GetPath(KnownFolder knownFolder)
        {
            return SHGetKnownFolderPath(_guids[knownFolder], 0);
        }

        [DllImport("shell32",
            CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        private static extern string SHGetKnownFolderPath(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags,
            int hToken = 0);
    }

}