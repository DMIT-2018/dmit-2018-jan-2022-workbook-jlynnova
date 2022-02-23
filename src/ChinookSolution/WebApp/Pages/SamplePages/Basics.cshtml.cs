using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class BasicsModel : PageModel
    {
        //basically this is an object, treat it as such

        //data fields
        public string MyName;
        //properties

        //constructors

        //behaviours aka methods
        public void OnGet()
        {
            //executes in response to a Get request from the browser (user)
            //when the page is "first" accessed teh browser issues a Get request
            //when the page is refreshed, WITHOUT a POST the browser issues a
            //Get request
            //when the page is processed in response to a forms POST request and using
            //  RedirectToPage() in teh response logic, a Get requet wil also 
            //  issue after the completion of the POST
            //IF NO RedirectToPage() is iused on the POST there is NO Get request issued

            //create some logic to display to the page
            Random random = new Random();
            int oddeven = random.Next(1, 100);
            if(oddeven % 2 == 0)
            {
                MyName = $"Jen is even {oddeven}";
            }
            else
            {
                MyName = null;
            }
        }
    }
}
