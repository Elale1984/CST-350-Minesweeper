using CST_350_Minesweeper.Models;

namespace CST_350_Minesweeper.Services
{
    public class RegisterService
    {

        RegisterDAO registerDAO = new RegisterDAO();

        public bool IsValid(User user)
        {
            return registerDAO.RegisterUserAccount(user);
        }
    }
}
