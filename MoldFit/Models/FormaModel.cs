using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoldFit.Models
{
    public class FormaModel
    {
        public FormaModel(int id)
        {
            MoldFitEntities ent = new MoldFitEntities();
            var fm = ent.Forma.Where(x => x.id == id).FirstOrDefault();
            fm.CopyProperties(this);
        }

        public FormaModel(string A, string B, string C, int ProjektId)
        {
            this.WymiarA = A;
            this.WymiarB = B;
            
        }

        public int id { get; set; }
        public string WymiarA { get; set; }
        public string WymiarB { get; set; }
        public string WymiarC { get; set; }
        public Nullable<int> ProjektId { get; set; }

        public ProjektModel Projekt { get { return GetProject(); } }

        protected ProjektModel GetProject()
        {
            if (!this.ProjektId.HasValue) return null;
            return new ProjektModel(this.ProjektId.Value);
        }

    }
}
