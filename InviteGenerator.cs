namespace DateInviteWeb
{
    public class InviteGenerator
    {
        private static readonly string[] Templates =
        {
            "Salam, {0}!\n\n{3}\n\nYer: {1}\nTarix: {2}\n\nGəlirsən?",
            "{0},\n\n{3}\n\nBizi {1}-da {2} tarixdə gözləyirəm.",
            "Hey {0}!\n\n{2} günü {1}-da birlikdə oturmaq istərdim.\n\n{3}"
        };

        public string Generate(DateInvite invite)
        {
            var random = new Random();
            string template = Templates[random.Next(Templates.Length)];

            return string.Format(
                template,
                invite.Name,
                invite.Place,
                invite.DateTime.ToString("dd MMMM yyyy, dddd",
                    new System.Globalization.CultureInfo("az-AZ")),
                invite.Message
            );
        }
    }
}