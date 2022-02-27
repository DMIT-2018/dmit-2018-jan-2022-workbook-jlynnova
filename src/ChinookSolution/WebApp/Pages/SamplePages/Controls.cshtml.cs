using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class ControlsModel : PageModel
    {
        [TempData]
        public string Feedback { get; set; }

        [BindProperty]
        public string EmailText { get; set; }
        [BindProperty]
        public string PasswordText { get; set; }
        [BindProperty]
        public DateTime DateTimeText { get; set; } = DateTime.Today;
        //public string DateTimeText { get; set; }
        public string[] RadioMeals = new[] { "breakfast", "lunch", "dinner/supper", "snacks" };
        //[BindProperty]
        //public string RadioMeal { get; set; }
        [BindProperty]
        public bool AcceptanceBox { get; set; } //remember value =  true on input control
        [BindProperty]
        public string MessageText { get; set; }
        [BindProperty]
        public int MyRide { get; set; }
        //pretend the collection is coing from the database
        //each row of the collection has two values: seletion value; selection txt
        //the class SelectionList will be used as the datatype for the collection
        public List<SelectionList> Rides { get; set; }
        [BindProperty]
        public string VacationSpot { get; set; }
        public List<String> VacationSpotList {get; set;}

        [BindProperty]
        public int RangeValue { get; set; }


        public void OnGet()
        {
            PopulateLists();
        }

        public void PopulateLists()
        {
            //pretending that this data comes from the database
            Rides = new List<SelectionList>();
            Rides.Add(new SelectionList() { ValidId = 3, DisplayText = "Bike" });
            Rides.Add(new SelectionList() { ValidId = 5, DisplayText = "Board" });
            Rides.Add(new SelectionList() { ValidId = 2, DisplayText = "Bus" });
            Rides.Add(new SelectionList() { ValidId = 1, DisplayText = "Car" });
            Rides.Add(new SelectionList() { ValidId = 4, DisplayText = "Motorcycle" });

            VacationSpotList = new List<string>();
            VacationSpotList.Add("California");
            VacationSpotList.Add("Caribbean");
            VacationSpotList.Add("Cruising");
            VacationSpotList.Add("Europe");
            VacationSpotList.Add("Florida");
            VacationSpotList.Add("Mexico");
        }

        public IActionResult OnPostText()
        {
            //this method is tied to teh specific button on the form via
            //  the asp-page-handler attribute
            //the form of teh method name is OnPost then concatenate the
            //value given to the handler attribute

            Feedback = $"Email {EmailText}; Password{PasswordText}; Date{DateTimeText}";
            return Page();
        }

        public IActionResult OnPostRadioCheckArea()
        {
            Feedback = $"Meal {RadioMeals}; Acceptance{AcceptanceBox}; Message{MessageText}";
            return Page();
        }
        public IActionResult OnPostListSlider()
        {
            Feedback = $"Ride {MyRide}; Vacation {VacationSpot}; Review Satification {RangeValue}";
            PopulateLists();
            return Page();
        }
        public class SelectionList
        {
            public int ValidID { get; set; }
            public string DisplayText { get; set; }
        }
    }
}
