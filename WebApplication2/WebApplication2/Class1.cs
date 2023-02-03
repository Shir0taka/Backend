namespace WebApplication2
{
    public interface ITimeService
    {
        string GetTime();
    }
    class ShortTimeService: ITimeService
    {
        public string GetTime() {
            int hour = DateTime.Now.Hour;
            string result="";
            if (hour < 0 || hour > 24) {
                result = "Невірний час";
            } else if (hour < 6) {
                result = "Зараз ніч";
            } else if (hour < 12) {
                result = "Зараз ранок";
            } else if (hour < 18) {
                result = "Зараз обід";
            } else if (hour < 24) {
                result = "Зараз вечір";
            }
            return result; 
        }
    }

}
