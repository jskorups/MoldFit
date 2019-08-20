using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoldFit.Models
{
    public class ProjektModel
    {
        public ProjektModel(int id)
        {
            MoldFitEntities ent = new MoldFitEntities();
            var pr = ent.ProjektTest.Where(x => x.id == id).FirstOrDefault();
            pr.CopyProperties(this);
        }

        public ProjektModel(ProjektTest p)
        {
            p.CopyProperties(this);
        }

        public int id { get; set; }
        public string ProjektNazwa { get; set; }

        public List<FormaModel> Formy { get; set; }

        public static List<ProjektModel> GetProjectList()
        {
            MoldFitEntities ent = new MoldFitEntities();
            return ent.ProjektTest.ToList().Select(x => new ProjektModel(x)).ToList();
        }
    }
}
