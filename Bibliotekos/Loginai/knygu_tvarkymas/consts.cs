using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai.knygu_tvarkymas
{
    public class Consts
    {
        public Dictionary<int, string> genres = new Dictionary<int, string>();
        public Dictionary<int, string> quality = new Dictionary<int, string>();

        public Consts()
        {
            genres.Add(0, "-----");
            genres.Add(1, "Dalykinė literatūra");
            genres.Add(2, "Detektyvinė literatūra‎");
            genres.Add(3, "Epai");
            genres.Add(4, "Erotinė literatūra");
            genres.Add(5, "Fantastinė literatūra");
            genres.Add(6, "Jaunimo literatūra‎");
            genres.Add(7, "Kelionių literatūra");
            genres.Add(8, "Legendos");
            genres.Add(9, "Novelės");
            genres.Add(10, "Pasakos");
            genres.Add(11, "Poezija");
            genres.Add(12, "Publicistika");
            genres.Add(13, "Romanai");
            genres.Add(14, "Tragedijos");
            genres.Add(15, "Vaikų literatūra‎");
            quality.Add(0, "-----");
            quality.Add(1, "Labai Bloga");
            quality.Add(2, "Bloga");
            quality.Add(3, "Vidutine");
            quality.Add(4, "Gera");
            quality.Add(5, "Labai Gera");
        }
    }
}