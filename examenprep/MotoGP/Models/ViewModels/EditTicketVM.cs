namespace MotoGP.Models.ViewModels
{
    public class EditTicketVM
    {
        public Ticket Ticket { get; set; }
        public Country Country { get; set; }
        public Race Race { get; set; }
        public int ticketID { get; set; }
        public bool Paid { get; set; }
    }
}
