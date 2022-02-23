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

        //the annotation [Temp Data] stores data until its read in another 
        //immediate request
        //this annotation has two methods called Keep(string) and
        //Peek(string) (used on Contect page)
        //kept in a dictionary (name/value pairs)
        //useful to redirect when data is required fo rmore than a single
        //request 
        //Implemented by providers using either cookies or session state
        //IMPORTANT -TempData is NOT  bound to any particular control like BindProperty

        public string Feedback { get; set; }


        //annotation of[BindProperty], ties a property in the PageModel class, directly to the a control on the Content page
        //there is a one to one association 
        //data is transferred between the two automatically
        //on teh content page the control to use this property will have 
        //  a helpertag call asp-for
        //
        //to retain the value in the control, tied to this property AND retained 
        //  via the @page use the SupportsGet attribute = true;
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

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

        //processing in response toa request from a form on a web page
        //is normally referred to as a POST (method="post")

        //General Post (OnPost())
        //a general post occurs whenan asp-page-handler is NOT used
        //theh return datatype can be void, however, you will normally
        //encounter the datatype IActionResult
        //the IActionResult requires some type of request action
        // on the return statemetn of the method OnPost()
        //typical actions:
        //Page()
        //  :does NOT issue a OnGet request
        // :remaind on teh current page
        //  :a good action for form processing involving validation
        //      and with the catch of a try/catch
        //  RedirectToPage()
        //  :DOES issue an OnGet request
        //  :is used to retain input value via the @page anf your BindProperty
        //          for controls on your form in the Content page


        public IActionResult OnPost()
        {
            //This line of code is used to cause a delay in processing
            //so we can see on the Network Activity some type of
            //simulated processing
            Thread.Sleep(2000);

            //retrieves data via the Request Obj
            //  Request: web page to server
            //  Response: serber to web page
            string buttonvalue = Request.Form["theButton"];
            Feedback = $"BUtton pressed is {buttonvalue} with numeric input of {id}";
            //  return Page(); //does NOT issue an OnGet(request)
            //return RedirectToPage(); //issues a request for OnGet()
            return RedirectToPage(new { id = id }); //creates anaonymous obj
        }
    }
}
