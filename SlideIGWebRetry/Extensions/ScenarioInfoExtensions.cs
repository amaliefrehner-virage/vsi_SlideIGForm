using Microsoft.Ajax.Utilities;
using SlideIGWebRetry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlideIGWebRetry.Extensions
{
    public static class ScenarioInfoExtensions
    {

        public static List<ScenarioIG> BuildScenarioIgs(this ScenarioInfo scenarioInfoObject)
        {
            List<ScenarioIG> scenarioIgs = new List<ScenarioIG>();
            foreach (var ig in scenarioInfoObject.ScenarioIGs)
            {
                List<ScenarioIGTitle> titles = new List<ScenarioIGTitle>();
               // ProcessScenarioTitles(ig.ScenarioIGTitles.ToList());
                foreach (var title in ig.ScenarioIGTitles.ToList())
                {
                    List<ScenarioIGSubTitle> subs = new List<ScenarioIGSubTitle>();
                    
                        foreach (var sub in title.ScenarioIGSubTitles.ToList())
                        {
                            List<ScenarioIGSubTitleBullet> subBullets = new List<ScenarioIGSubTitleBullet>();
                            if (sub.ScenarioIGSubTitleBullets != null)
                            {
                                foreach (var subBullet in sub.ScenarioIGSubTitleBullets)
                                {
                                    var idScenarioIgSubTitle = subBullet?.IDBulletPoints != null ? subBullet.IDBulletPoints : 1;

                                    subBullets.Add(new ScenarioIGSubTitleBullet
                                    {
                                        IDScenarioIGSubTitle = subBullet.IDScenarioIGSubTitle,
                                        IDScenarioIGSubTitleBullets = subBullet.IDScenarioIGSubTitleBullets,
                                        IDBulletPoints = subBullet.IDBulletPoints,
                                        Content = subBullet.Content,
                                    });
                                }
                            }

                            subs.Add(new ScenarioIGSubTitle
                            {
                                Content = sub.Content,
                                IDScenarioIGSubTitle = sub.IDScenarioIGSubTitle,
                                IDScenarioIGTitle = sub.IDScenarioIGTitle,
                                IDBulletPoints = sub.IDBulletPoints,
                                ScenarioIGSubTitleBullets = subBullets
                            });
                            
                        }
                    
                    
                    titles.Add(new ScenarioIGTitle
                    {
                        IDScenarioIGTitle = title.IDScenarioIGTitle,
                        IDScenarioIG = title.IDScenarioIG,
                        Content = title.Content,
                        ScenarioIGSubTitles = subs
                    });
                }
                scenarioIgs.Add(new ScenarioIG
                {
                    IDScenarioIG = ig.IDScenarioIG,
                    IDScenarioInfo = ig.IDScenarioInfo,
                    ScenarioIGTitles = titles,
                });
            }
            return scenarioIgs;
        }

        public static List<ScenarioSlide> BuildScenarioSlides(this ScenarioInfo scenarioInfoObject)
        {
            List<ScenarioSlide> scenarioSlides = new List<ScenarioSlide>();
            foreach (var slide in scenarioInfoObject.ScenarioSlides)
            {
                List<ScenarioSlideTitle> titles = new List<ScenarioSlideTitle>();
                foreach (var title in slide.ScenarioSlideTitles)
                {
                    List<ScenarioSlideSubTitle> subs = new List<ScenarioSlideSubTitle>();
                    if (title.ScenarioSlideSubTitles != null)
                    {
                        foreach (var sub in title.ScenarioSlideSubTitles)
                        {
                            List<ScenarioSlideSubTitleBullet> subBullets = new List<ScenarioSlideSubTitleBullet>();
                            if (sub.ScenarioSlideSubTitleBullets != null)
                            {
                                foreach (var subBullet in sub.ScenarioSlideSubTitleBullets)
                                {

                                    subBullets.Add(new ScenarioSlideSubTitleBullet
                                    {
                                        IDScenarioSlideSubTitle = subBullet.IDScenarioSlideSubTitle,
                                        IDScenarioSlideSubTitleBullets = subBullet.IDScenarioSlideSubTitleBullets,
                                        IDBulletPoints = subBullet.IDBulletPoints,
                                        Content = subBullet.Content,
                                    });
                                }
                            }
                            
                            subs.Add(new ScenarioSlideSubTitle
                            {
                                Content = sub.Content,
                                IDScenarioSlideSubTitle = sub.IDScenarioSlideSubTitle,
                                IDScenarioSlideTitle = sub.IDScenarioSlideTitle,
                                IDBulletPoints = sub.IDBulletPoints,
                                ScenarioSlideSubTitleBullets = subBullets
                            });
                        }
                    }
                    
                    titles.Add(new ScenarioSlideTitle
                    {
                        IDScenarioSlideTitle = title.IDScenarioSlideTitle,
                        IDScenarioSlide = title.IDScenarioSlide,
                        Content = title.Content,
                        ScenarioSlideSubTitles = subs
                    });
                }
                scenarioSlides.Add(new ScenarioSlide
                {
                    IDScenarioSlide = slide.IDScenarioSlide,
                    IDScenarioInfo = slide.IDScenarioInfo,
                    ScenarioSlideTitles = titles,
                });
            }
            return scenarioSlides;
        }

        private static void ProcessScenarioTitles(List<ScenarioIGTitle> titles)
        {
            foreach (var title in titles)
            {
                try
                {
                    foreach (var subtitle in title.ScenarioIGSubTitles)
                    {

                    }
                } catch (Exception ex)
                {
                    List<ScenarioIGSubTitle> subs = new List<ScenarioIGSubTitle>();
                    title.ScenarioIGSubTitles= subs;
                }
               
            }
        }
    }
}