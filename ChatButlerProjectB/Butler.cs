namespace ChatButlerProjectB
{
    internal class Butler
    {
        public Butler()
        {

        }

        public string Greet()
        {
            return "Waarde heer, mevrouw. \n\nWelkom bij restuarant La Mouette. \n\nWaar kan ik u mee van dienst zijn?\n";
        }

        public string ShowComponents()
        {
            return "1: Een review bekijken van eerdere gasten\n" +
                   "2: Een reservering plaatsen\n" +
                   "3: Registreren\n" +
                   "4: Inloggen\n" +
                   "6: Bekijk membership\n" +
                   "5: Sluiten";
        }
    }
}