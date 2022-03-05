#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional NAmespaces
using ChinookSys.DAL;
using ChinookSys.Entities;
using ChinookSys.ViewModels;
#endregion

namespace ChinookSys.BLL
{
    public class AboutServices
    {
        //this class needs to be accessed by an "outside user" (WebApp)
        //therefore the class needs to be public

        #region Constructor and Context Dependancy
        private readonly ChinookContext _context;

        //obtain the context link from IServicesCollection when this
        //  set of services is injected intot he "outside user"

        internal AboutServices(ChinookContext context)
        {
            _context = context;
        }
        #endregion

        #region Services
        //services are methods

        //query to obtain the DbVersion data
        public DbVersionInfo GetDbVersion()
        {
            DbVersionInfo info = _context.DbVersions
                               .Select(x => new DbVersionInfo
                               {
                                   Major = x.Major,
                                   Minor = x.Minor,
                                   Build = x.Build,
                                   ReleaseDate = x.ReleaseDate
                               })
                               .SingleOrDefault();
            return info;
        }
        #endregion
    }
}
