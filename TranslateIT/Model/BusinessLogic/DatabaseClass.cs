using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslateIT.Model.Entity;

namespace TranslateIT.Model.BusinessLogic
{
    public class DatabaseClass
    {
        #region Entities
        public TranslateITEntities4 TranslateITEntities { get; set; }
        #endregion
        #region Constructor
        public DatabaseClass(TranslateITEntities4 translateITEntities) 
        {
            this.TranslateITEntities = translateITEntities;
        }
        #endregion
    }
}
