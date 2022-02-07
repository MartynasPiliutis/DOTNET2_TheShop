namespace TheShop
{
    public class UserService
    {
        public int UserServiceCheckIfUserHasMoney(double userMoney)
        {
            int actionCode;
            double credit = userMoney;
            if (credit <= 0)
            {
                actionCode = 0;
            }
            else
            { actionCode = 1; }
            return actionCode;
        }
    }
}
