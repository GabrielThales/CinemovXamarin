using Cinemov.Domain.Entities;
using Cinemov.Domain.Interfaces;
using Cinemov.Infra.Base;
using Cinemov.Infra.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cinemov.Infra.Repositories
{
    public class AvaliacaoRepository : RepositoryBase<Avaliacao>, IAvaliacaoRepository
    {

        public AvaliacaoRepository() : base(new CinemovSQLiteContext("Filename=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "cinemov.db")))
        {
            /*{
                string dbPath = "Filename=";
                const string dbFileName = "cinemov.sqlite";

                switch (devicePlatform)
                {
                    case "UWP":
                        dbPath += Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFileName);
                        break;
                    case "iOS":
                        dbPath += Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "data", dbFileName);
                        break;
                    case "Android":
                        dbPath += Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dbFileName);
                        break;
                }*/

                //db = new CinemovSQLiteContext(dbPath);
            }
        }
    }
