#nullable disable
using ChinookSys.BLL;
using ChinookSys.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
#endregion

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Private variable ad DI constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly AboutServices _aboutServices;

        public IndexModel(ILogger<IndexModel> logger, 
                            AboutServices aboutservices)
        {
            _logger = logger;
            _aboutServices = aboutservices;
        }
        #endregion

        #region Feedback and Errorhandling
        [TempData]
        public string Feedback { get; set; }

        public bool HasFeedback => !string.IsNullOrWhiteSpace(Feedback);
        #endregion
        public void OnGet()
        {
            //consume a service
            DbVersionInfo info = _aboutServices.GetDbVersion();
            if (info == null)
            {
                Feedback = "Version Unknown";
            }
            else
            {
                Feedback = $"version: {info.Major}.{info.Minor}.{info.Build} " + $"Release date of{info.ReleaseDate.ToShortDateString()}";
            }
        }
    }
}